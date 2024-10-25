using UnityEngine;
using Xprees.RuntimeAnchors.Base;

namespace Xprees.RuntimeAnchors.AutoProviders
{
    public class ParticleSystemAnchorProvider : AutoAnchorProviderBase<ParticleSystem>
    {
        protected override ParticleSystem GetAutomaticallyAnchorComponent() => GetComponent<ParticleSystem>();
    }
}