using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VinaGerman.Wcf.Security.Client
{
    public static class ClientPersonnelHeaderContext
    {
        public static PersonnelHeader HeaderInformation;

        static ClientPersonnelHeaderContext()
        {
            HeaderInformation = new PersonnelHeader();
        }
    }
}
