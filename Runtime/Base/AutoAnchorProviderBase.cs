using UnityEngine;

namespace Xprees.RuntimeAnchors.Base
{
    public abstract class AutoAnchorProviderBase<T> : MonoBehaviour where T : Object
    {
        public RuntimeAnchorBase<T> anchor;

        private void Start() => ProvideAnchor();

        private void OnEnable() => ProvideAnchor();

        private void OnDisable()
        {
            if (anchor == null) return;
            anchor.Unset();
        }

        protected abstract T GetAnchorComponent();

        private void ProvideAnchor()
        {
            if (anchor == null) return;
            if (anchor.isSet) return;

            anchor.Provide(GetAnchorComponent());
        }

        private void OnValidate()
        {
            if (anchor == null) Debug.LogWarning($"Anchor on {name} has no {nameof(anchor)} set.");
        }
    }
}