using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TlsClient.Model.ProtocolModel.ClientHelloExtension
{
    public class elliptic_curves
    {
        private byte[] _type = new byte[2];
        public byte[] Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private byte[] _length = new byte[2];
        public byte[] Length
        {
            get { return _length; }
            set { _length = value; }
        }

        private byte[] _ellipticCurvesLength = new byte[2];
        public byte[] EllipticCurvesLength
        {
            get { return _ellipticCurvesLength; }
            set { _ellipticCurvesLength = value; }
        }

        private byte[] _ellipticcurves = new byte[4];
        public byte[] Ellipticcurves
        {
            get { return _ellipticcurves; }
            set { _ellipticcurves = value; }
        }
    }
}
