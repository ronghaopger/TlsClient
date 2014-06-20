using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TlsClient.Model.ProtocolModel.ClientHelloExtension
{
    public class elliptic_curves
    {
        private string _type;
        public string Type
        {
            get { return _type; }
            set { _type = value; }
        }

        private string _length;
        public string Length
        {
            get { return _length; }
            set { _length = value; }
        }

        private string _ellipticCurvesLength;
        public string EllipticCurvesLength
        {
            get { return _ellipticCurvesLength; }
            set { _ellipticCurvesLength = value; }
        }

        private List<string> _ellipticcurves;
        public List<string> Ellipticcurves
        {
            get { return _ellipticcurves; }
            set { _ellipticcurves = value; }
        }
    }
}
