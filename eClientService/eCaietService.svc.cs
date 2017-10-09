using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace eClientService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "eCaietService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select eCaietService.svc or eCaietService.svc.cs at the Solution Explorer and start debugging.
    public class eCaietService : IeCaietService
    {
        public void DoWork()
        {
            throw new SyntaxErrorException();
        }
    }
}
