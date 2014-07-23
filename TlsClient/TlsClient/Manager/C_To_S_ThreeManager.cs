using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TlsClient.Model.ProtocolModel;

namespace TlsClient.Manager
{
    public class C_To_S_ThreeManager : IRequestManager
    {
         private Finished finished;
         public C_To_S_ThreeManager()
         {
             if (finished == null)
                 finished = new Finished();
         }

        public void InitPackage()
        {

        }

        public System.IO.MemoryStream InitStream()
        {
            throw new NotImplementedException();
        }
    }
}
