namespace Personal.Control.Utils.Configs
{
    public class ValidationConfig
    {
        /// <summary>
        /// Minimum length that a password must have
        /// </summary>
        public short PasswordMinimumLength { get; set; }

        /// <summary>
        /// Maximum length that a password must have
        /// </summary>
        public short PasswordMaximumLength { get; set; }
    }
}