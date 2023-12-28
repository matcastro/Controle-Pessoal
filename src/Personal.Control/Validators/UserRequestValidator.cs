using Ardalis.GuardClauses;
using Personal.Control.Models.Requests;
using Personal.Control.Utils.Helpers;
using Personal.Control.Utils.Messages;
using System.Net.Mail;

namespace Personal.Control.Validators
{
    public static class UserRequestValidator
    {
        /// <summary>
        /// Validates an user request to ensure that there are no problems
        /// </summary>
        /// <param name="request">The resquest to be validated</param>
        /// <exception cref="ArgumentException">Some field of the request doesn't follow the requirements</exception>
        /// <exception cref="ArgumentOutOfRangeException">Password with less than minimum or more than maximum characters</exception>
        public static void Validate(this UserRequest request)
        {
            ValidateEmail(request.Email);
            ValidatePassword(request.Password);
        }

        public static void ValidateAllowNull(this UserRequest request)
        {
            if (!string.IsNullOrWhiteSpace(request.Email))
            {
                ValidateEmail(request.Email);
            }

            if (!string.IsNullOrWhiteSpace(request.Password))
            {
                ValidatePassword(request.Password);
            }
        }

        private static void ValidateEmail(string email)
        {
            Guard.Against.InvalidInput(email, nameof(email),
                e => MailAddress.TryCreate(e, out _), ValidationMessages.InvalidEmail);
        }

        private static void ValidatePassword(string password)
        {
            Guard.Against.OutOfRange(password.Length, nameof(password),
                ConfigurationHelper.Config.Validation.PasswordMinimumLength,
                ConfigurationHelper.Config.Validation.PasswordMaximumLength,
                ValidationMessages.PasswordOutOfRange);
            Guard.Against.InvalidInput(password, nameof(password),
                p => p.Any(char.IsDigit) && p.Any(char.IsUpper) && p.Any(char.IsLower) &&
                p.Any(c => "[!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~]+".Contains(c)),
                ValidationMessages.PasswordValidCharacters);
        }
    }
}
