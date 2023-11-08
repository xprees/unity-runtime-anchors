using UnityEngine;
using Xprees.RuntimeAnchors.Base;

namespace Xprees.RuntimeAnchors.AutoProviders
{
    public class AutoTransformAnchorProvider : AutoAnchorProviderBase<Transform>
    {
        protected override Transform GetAutomaticallyAnchorComponent() => transform;
    }
}