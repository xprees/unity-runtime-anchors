using UnityEngine;
using Xprees.RuntimeAnchors.Base;

namespace Xprees.RuntimeAnchors
{
    [CreateAssetMenu(menuName = "Runtime Anchors/Transform", fileName = "TransformAnchor")]
    public class TransformAnchor : RuntimeAnchorBase<Transform>
    {
    }
}