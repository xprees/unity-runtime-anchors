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

        private UnityAction<T> _onValueChanged;

        /// Raised when the value is set, or when the anchor gets provided (anchor mode).
        /// The anchor is hooked on subscribe, not in the constructor: Unity deserializes the fields only after the constructor runs.
        public event UnityAction<T> OnValueChanged
        {
            add
            {
                _onValueChanged += value;
                HookAnchor();
            }
            remove
            {
                _onValueChanged -= value;
                if (_onValueChanged == null) UnhookAnchor();
            }
        }

        public AnchorReferenceBase()
        {
        }

        public AnchorReferenceBase(T value)
        {
            useInlined = true;
            inlinedValue = value;
        }

        public T Value
        {
            get => useInlined ? inlinedValue : anchor ? anchor.Value : null;
            set
            {
                if (!useInlined)
                {
                    // Provide raises onAnchorProvided -> OnAnchorProvided -> OnValueChanged
                    anchor.Provide(value);
                    return;
                }

                inlinedValue = value;
                OnOnValueChanged(value);
            }
        }

        public static implicit operator T(AnchorReferenceBase<T> reference) => reference?.Value;

        protected virtual void OnOnValueChanged(T value) => _onValueChanged?.Invoke(value);

        // Remove first so subscribing twice (or after the anchor cleared its listeners) never doubles the callback.
        private void HookAnchor()
        {
            if (useInlined || !anchor) return;

            anchor.onAnchorProvided -= OnAnchorProvided;
            anchor.onAnchorProvided += OnAnchorProvided;
        }

        private void UnhookAnchor()
        {
            if (anchor) anchor.onAnchorProvided -= OnAnchorProvided;
        }

        private void OnAnchorProvided() => OnOnValueChanged(anchor.Value);
    }
}