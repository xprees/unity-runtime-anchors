using System;
using UnityEngine.Events;
using Object = UnityEngine.Object;

namespace Xprees.RuntimeAnchors.Base.Reference
{
    [Serializable]
    public class AnchorReferenceBase<T> where T : Object
    {
        public bool useInlined = true;
        public T inlinedValue;
        public RuntimeAnchorBase<T> anchor;

        public event UnityAction<T> OnValueChanged;

        public AnchorReferenceBase()
        {
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            if (!useInlined && anchor != null) anchor.onAnchorProvided += OnAnchorProvided;
        }

        private void OnAnchorProvided() => OnValueChanged?.Invoke(anchor.Value);

        public AnchorReferenceBase(T value)
        {
            useInlined = true;
            inlinedValue = value;
        }

        public T Value
        {
            get => useInlined ? inlinedValue : anchor.Value;
            set
            {
                if (!useInlined)
                {
                    anchor.Provide(value);
                }
                else
                {
                    inlinedValue = value;
                }

                OnOnValueChanged(value);
            }
        }

        public static implicit operator T(AnchorReferenceBase<T> reference) => reference?.Value;

        protected virtual void OnOnValueChanged(T value) => OnValueChanged?.Invoke(value);
    }
}