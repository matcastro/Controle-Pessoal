namespace Personal.Control.Models.Enums
{
    public enum ExceptionCodesEnum
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
        GenericError
    }
}
