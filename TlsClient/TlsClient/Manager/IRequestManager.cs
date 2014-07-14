using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TlsClient.Manager
{
    interface IRequestManager
    {
        void InitPackage();

        MemoryStream InitStream();
    }
}
