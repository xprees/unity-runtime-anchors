using System;
using Object = UnityEngine.Object;

namespace Xprees.RuntimeAnchors.Base.Reference
{
    [Serializable]
    public class AnchorReferenceBase<T> where T : Object
    {
        public bool useInlined = true;
        public T inlinedValue;
        public RuntimeAnchorBase<T> anchor;

        public AnchorReferenceBase()
        {
        }

        public AnchorReferenceBase(T value)
        {
            useInlined = true;
            inlinedValue = value;
        }

        public T Value
        {
            get => useInlined ? inlinedValue : anchor.Value;
            set
            {
                if (useInlined)
                {
                    inlinedValue = value;
                    return;
                }

                anchor.Provide(value);
            }
        }

        public static implicit operator T(AnchorReferenceBase<T> reference) => reference?.Value;
    }
}