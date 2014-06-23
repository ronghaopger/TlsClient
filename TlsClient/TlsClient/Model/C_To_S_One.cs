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
        private Base _base = new Base();
        public Base Base { get { return _base; } }

        private ClientHello _clientHello = new ClientHello();
        public ClientHello ClientHello { get { return _clientHello; } }
    }
}
