using UnityEngine;
using Xprees.RuntimeAnchors.Base;

namespace Xprees.RuntimeAnchors.AutoProviders
{
    public class AutoGameObjectAnchorProvider : AutoAnchorProviderBase<GameObject>
    {
        protected override GameObject GetAnchorComponent() => gameObject;
    }
}