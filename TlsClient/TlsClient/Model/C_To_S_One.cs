using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TlsClient.Model.ProtocolModel;

namespace TlsClient.Model
{
    public class C_To_S_One
    {
        public Base Base { get; set; }
        public ClientHello ClientHello { get; set; }
    }
}
