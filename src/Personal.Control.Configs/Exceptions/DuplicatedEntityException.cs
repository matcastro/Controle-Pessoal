using System.Runtime.Serialization;

namespace Personal.Control.Utils.Exceptions
{
    /// <summary>
    /// Exception to be used if an entity is already in the database and should not have repeated values
    /// </summary>  
    [Serializable]
    public class DuplicatedEntityException : Exception
    {
        public DuplicatedEntityException() { }

        public DuplicatedEntityException(string message)
            : base(message) { }

        public DuplicatedEntityException(string message, string duplicatedValue)
            : this(string.Format(message, duplicatedValue)) { }

        protected DuplicatedEntityException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
