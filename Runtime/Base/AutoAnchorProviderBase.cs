using UnityEngine;

namespace Xprees.RuntimeAnchors.Base
{
    public abstract class AutoAnchorProviderBase<T> : MonoBehaviour where T : Object
    {
        [SerializeField] protected RuntimeAnchorBase<T> anchor;

        [Header("Manual Reference - Optional")]
        [Tooltip("This will override the automatic reference. Not required.")]
        [SerializeField] protected T manualReference;

        protected virtual void Start() => ProvideAnchor();

        protected virtual void OnEnable() => ProvideAnchor();

        protected virtual void OnDisable()
        {
            if (anchor == null) return;
            anchor.Unset();
        }

        protected abstract T GetAutomaticallyAnchorComponent();

        protected void ProvideAnchor()
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