using UnityEngine;
using Xprees.RuntimeAnchors.Reference;

namespace Xprees.RuntimeAnchors
{
    public static class TransformAnchorExtensions
    {
        /// The camera on the anchored transform. Null when the anchor is unset or the transform has no camera. Not cached, keep the result in a field.
        public static Camera GetCamera(this TransformAnchor anchor) => anchor && anchor.Value ? anchor.Value.GetComponent<Camera>() : null;

        /// The camera on the transform of the reference (inline or anchor). Null when nothing is referenced yet. Not cached, keep the result in a field.
        public static Camera GetCamera(this TransformAnchorReference reference)
        {
            if (reference == null || (!reference.useInlined && !reference.anchor)) return null;

            var value = reference.Value;
            return value ? value.GetComponent<Camera>() : null;
        }
    }
}