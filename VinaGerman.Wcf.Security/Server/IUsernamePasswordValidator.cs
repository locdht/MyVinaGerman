using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VinaGerman.Wcf.Security.Server
{
    public interface IUsernamePasswordValidator
    {
        bool Validate(string userName, string password);
    }
}
