namespace Personal.Control.Models.Enums
{
    public enum ExceptionCodes
    {
        /// <summary>
        /// Some field is wrong on the request
        /// </summary>
        InvalidBody,

        /// <summary>
        /// Entity already exists
        /// </summary>
        AlreadyExists,

        /// <summary>
        /// Unmapped error
        /// </summary>
        GenericError,

        /// <summary>
        /// Field need by an operation is missing
        /// </summary>
        MissingMandatoryField,

        /// <summary>
        /// Entity was not found
        /// </summary>
        NotFound
    }
}
