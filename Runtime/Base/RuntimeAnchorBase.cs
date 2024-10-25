using UnityEngine;
using UnityEngine.Events;
using Xprees.Core;
using Xprees.EditorTools.Attributes.ReadOnly;

namespace Xprees.RuntimeAnchors.Base
{
    public class RuntimeAnchorBase<T> : DescriptionBaseSO where T : Object
    {
        public UnityAction onAnchorProvided;

        [ReadOnly] [SerializeField] private T value;
        public T Value => value;

        [ReadOnly] public bool isSet; // Any script can check if the value is null before using it, by just checking this bool

        public void Provide(T providedValue)
        {
            if (providedValue == null)
            {
                Debug.LogError($"A null value was provided to the {name} runtime anchor.");
                return;
            }

            value = providedValue;
            isSet = true;

            onAnchorProvided?.Invoke();
        }

        public void Unset()
        {
            value = null;
            isSet = false;
        }

        private void OnDisable() => ResetState();

        public override void ResetState() => Unset();
    }
}