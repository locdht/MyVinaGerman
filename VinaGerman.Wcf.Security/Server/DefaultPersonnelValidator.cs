using System;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using VinaGerman.Entity;

namespace VinaGerman.Wcf.Security.Server
{
    /// <summary>
    /// The <see cref="DefaultPersonnelValidator"/>
    /// class provides a default username password validation implementation.
    /// </summary>
    /// <remarks>
    /// The <see cref="UserNamePasswordValidator"/> ensures that a username value has been supplied. No further validation on the username is done.
    /// Any password will pass this validator.
    /// </remarks>
    public class DefaultPersonnelValidator : UserNamePasswordValidator
    {
        /// <summary>
        /// Validates the specified username and password.
        /// </summary>
        /// <param name="userName">The username to validate.</param>
        /// <param name="password">The password to validate.</param>
        /// <remarks>
        /// The <see cref="UserNamePasswordValidator"/> ensures that a username value has been supplied. No further validation on the username is done.
        /// Any password will pass this validator.
        /// </remarks>
        /// <exception cref="SecurityTokenException">No username has been supplied.</exception>
        public override void Validate(String userName, String password)
        {
            // Check if the username exists
            if (String.IsNullOrEmpty(userName))
            {
                throw new SecurityTokenException("Username can't be empty");
            }
            
            if (Factory.Resolve<IUsernamePasswordValidator>() != null)
            {
                bool isValid = Factory.Resolve<IUsernamePasswordValidator>().Validate(userName, password);
                if (!isValid)
                {
                    throw new SecurityTokenException("Invalid username and password");
                }
            }
        }
    }
}