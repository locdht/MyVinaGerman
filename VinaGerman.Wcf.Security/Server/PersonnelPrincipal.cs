using VinaGerman.Wcf.Security.Server;
using System;
using System.Security.Principal;

namespace VinaGerman.Wcf.Security.Server
{
    /// <summary>
    /// The <see cref="PersonnelPrincipal"/>
    /// class provides information about the roles available to the <see cref="PersonnelIdentity"/> that it exposes.
    /// </summary>
    public class PersonnelPrincipal : GenericPrincipal
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonnelPrincipal"/> class.
        /// </summary>
        /// <param name="identity">The identity.</param>
        /// <param name="roles">The roles.</param>
        public PersonnelPrincipal(PersonnelIdentity identity, String[] roles)
            : base(identity, roles)
        {
        }
    }
}