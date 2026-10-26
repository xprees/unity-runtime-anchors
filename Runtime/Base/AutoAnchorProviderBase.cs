using UnityEngine;
using Object = UnityEngine.Object;

namespace Xprees.RuntimeAnchors.Base
{
    public abstract class AutoAnchorProviderBase<T> : MonoBehaviour where T : Object
    {
        [SerializeField] protected RuntimeAnchorBase<T> anchor;

        [Header("Manual Reference - Optional")]
        [Tooltip("This will override the automatic reference. Not required.")]
        [SerializeField] protected T manualReference;

        [Header("Settings")]
        [Tooltip("Provides anchor during Awake() if set to true")]
        [SerializeField] protected bool provideInAwake = false;

        [Tooltip("Provides anchor OnEnable() if set to true")]
        [SerializeField] protected bool provideOnEnable = true;

        [Tooltip("Provides anchor during Start() if set to true")]
        [SerializeField] protected bool provideInStart = true;

        protected void Awake()
        {
            if (provideInAwake) ProvideAnchor();
        }

        protected virtual void OnEnable()
        {
            if (provideOnEnable) ProvideAnchor();
        }

        protected virtual void Start()
        {
            if (provideInStart) ProvideAnchor();
        }

        protected virtual void OnDisable()
        {
            if (!anchor) return;

            anchor.Unset();
        }

        protected abstract T GetAutomaticallyAnchorComponent();

        protected void ProvideAnchor()
        {
            if (!anchor) return;
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