﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;

namespace VinaGerman.Service.Implementation
{
    public class VinaGermanServiceHostFactory : ServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType,
         Uri[] baseAddresses)
        {
            //All the custom factory does is return a new instance
            //of our custom host class. The bulk of the custom logic should
            //live in the custom host (as opposed to the factory) 
            //for maximum
            //reuse value outside of the IIS/WAS hosting environment.
            return new VinaGermanServiceHost(serviceType, baseAddresses);
        }
    }
}
