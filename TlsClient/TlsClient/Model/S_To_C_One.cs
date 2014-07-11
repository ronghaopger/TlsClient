using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TlsClient.Model.ProtocolModel;

namespace TlsClient.Model
{
    public class S_To_C_One
    {
        private Base _base = new Base();
        public Base Base { get { return _base; } }

        private ServerHello _serverHello = new ServerHello();
        public ServerHello ServerHello { get { return _serverHello; } }
    }
}
