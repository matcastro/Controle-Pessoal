using System.Runtime.Serialization;

namespace Personal.Control.Utils.Exceptions
{
    /// <summary>
    /// Exception to be used if an entity doesn't exist in the current context
    /// </summary>  
    [Serializable]
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message) 
            : base(message) { }

        public EntityNotFoundException(string message, string entityName, string entityIdentifier)
            : this(string.Format(message, entityName, entityIdentifier)) { }

        protected EntityNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
