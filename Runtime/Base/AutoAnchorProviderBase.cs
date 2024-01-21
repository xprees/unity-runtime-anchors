using UnityEngine;

namespace Xprees.RuntimeAnchors.Base
{
    public abstract class AutoAnchorProviderBase<T> : MonoBehaviour where T : Object
    {
        public RuntimeAnchorBase<T> anchor;

        [Header("Manual Reference - Optional")]
        [Tooltip("This will override the automatic reference. Not required.")]
        [SerializeField] private T manualReference;

        private void Start() => ProvideAnchor();

        private void OnEnable() => ProvideAnchor();

        private void OnDisable()
        {
            if (anchor == null) return;
            anchor.Unset();
        }

        protected abstract T GetAutomaticallyAnchorComponent();

        private void ProvideAnchor()
        {
            if (anchor == null) return;
            if (anchor.isSet) return;

            var value = manualReference != null ? manualReference : GetAutomaticallyAnchorComponent();
            anchor.Provide(value);
        }

        private void OnValidate()
        {
            // Check that the GameObject is present in the scene and not a prefab
            if (gameObject.scene.rootCount == 0) return;
            if (anchor == null) Debug.LogWarning($"Anchor on {name} has no {nameof(anchor)} set.");
        }
    }
}