using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace eClientService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IeCaietService" in both code and config file together.
    [ServiceContract]
    public interface IeCaietService
    {
        [OperationContract]
        void DoWork();
    }
}
