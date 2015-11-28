using PortableIoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinaGerman.Entity
{
    public static class Factory
    {
        private static IPortableIoC _instance = new PortableIoc();
        
        public static T Resolve<T>(bool createNew = true)
        {
            return _instance.Resolve<T>(createNew);
        }
        public static void Register<T, C>() where C : T, new()
        {
            if (!_instance.CanResolve<T>())
                _instance.Register<T>(ins => new C());
        }
    }
}
