using Personal.Control.Utils.Helpers;

namespace Personal.Control.Utils.Messages
{
    public static class ValidationMessages
    {
        public static readonly string InvalidEmail = "The email is in an invalid format.";

        public static readonly string PasswordOutOfRange = $"Passwords must be between {ConfigurationHelper.Config.Validation.PasswordMinimumLength} and {ConfigurationHelper.Config.Validation.PasswordMaximumLength}.";
        public static readonly string PasswordValidCharacters = "Passwords must contain at least an uppercase letter, a lowercase letter, a number and an special character.";
    }
}
