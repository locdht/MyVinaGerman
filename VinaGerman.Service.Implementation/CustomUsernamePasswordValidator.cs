using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Wcf.Security.Server;

namespace VinaGerman.Service.Implementation
{
    class CustomUsernamePasswordValidator : IUsernamePasswordValidator
    {
        public bool Validate(string username, string password)
        {
            return Entity.Factory.Resolve<VinaGerman.Business.IUserBL>().Login(username, password);
        }
    }
}
