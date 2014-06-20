using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TlsClient.Model.ProtocolModel.ClientHelloExtension
{
    public class ec_point_formats
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

        private string _eCpointformatsLength;
        public string ECpointformatsLength
        {
            get { return _eCpointformatsLength; }
            set { _eCpointformatsLength = value; }
        }

        private List<string> _ellipticcurvespointformats;
        public List<string> Ellipticcurvespointformats
        {
            get { return _ellipticcurvespointformats; }
            set { _ellipticcurvespointformats = value; }
        }
    }
}
