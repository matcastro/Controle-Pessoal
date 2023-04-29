using Ardalis.GuardClauses;
using Personal.Control.Models.Requests;
using Personal.Control.Utils.Helpers;
using Personal.Control.Utils.Messages;
using System.Net.Mail;

namespace Personal.Control.Validators
{
    public static class UserRequestValidator
    {
        public static void Validate(this UserRequest request)
        {
            Guard.Against.InvalidInput(request.Email, nameof(request.Email), 
                e => MailAddress.TryCreate(e, out _), ValidationMessages.InvalidEmail);
            Guard.Against.OutOfRange(request.Password.Length, nameof(request.Password), 
                ConfigurationHelper.Config.Validation.PasswordMinimumLength, 
                ConfigurationHelper.Config.Validation.PasswordMaximumLength,
                ValidationMessages.PasswordOutOfRange);
            Guard.Against.InvalidInput(request.Password, nameof(request.Password),
                p => p.Any(char.IsDigit) && p.Any(char.IsUpper) && p.Any(char.IsLower) && 
                p.Any(c => "[!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~]+".Contains(c)),
                ValidationMessages.PasswordValidCharacters);
        }
    }
}
