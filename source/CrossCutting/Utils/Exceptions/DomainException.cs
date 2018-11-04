using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace Solution.CrossCutting.Utils
{
    [Serializable]
    public class DomainException : Exception
    {
        public DomainException()
        {
        }

        public DomainException(string message) : base(message)
        {
        }

        public DomainException(string message, Exception exception) : base(message, exception)
        {
        }

        protected DomainException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            ResourceReferenceProperty = info.GetString(nameof(ResourceReferenceProperty));
        }

        private string ResourceReferenceProperty { get; }

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException(nameof(info));
            }

            info.AddValue(nameof(ResourceReferenceProperty), ResourceReferenceProperty);

            base.GetObjectData(info, context);
        }
    }
}
