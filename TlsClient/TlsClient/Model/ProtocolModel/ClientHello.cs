using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TlsClient.Model.ProtocolModel.ClientHelloExtension;

namespace TlsClient.Model.ProtocolModel
{
    public class ClientHello : Handshake
    {
        private byte[] _gmt_unix_time = new byte[4];
        public byte[] Gmt_unix_time
        {
            get { return _gmt_unix_time; }
            set { _gmt_unix_time = value; }
        }

        private byte[] _random_bytes = new byte[28];
        public byte[] Random_bytes
        {
            get { return _random_bytes; }
            set { _random_bytes = value; }
        }

        private byte _sessionIDLength;
        public byte SessionIDLength
        {
            get { return _sessionIDLength; }
            set { _sessionIDLength = value; }
        }

        private byte[] _cipherSuitesLength = new byte[2];
        public byte[] CipherSuitesLength
        {
            get { return _cipherSuitesLength; }
            set { _cipherSuitesLength = value; }
        }

        private byte[] _cipherSuites = new byte[2];
        public byte[] CipherSuites
        {
            get { return _cipherSuites; }
            set { _cipherSuites = value; }
        }

        private byte _compressionMethodsLength;
        public byte CompressionMethodsLength
        {
            get { return _compressionMethodsLength; }
            set { _compressionMethodsLength = value; }
        }

        private byte _compressionMethods;
        public byte CompressionMethods 
        {
            get { return _compressionMethods; }
            set { _compressionMethods = value; }
        }

        private byte[] _extensionsLength = new byte[2];
        public byte[] ExtensionsLength
        {
            get { return _extensionsLength; }
            set { _extensionsLength = value; }
        }

        private renegotiation_info _renegotiation_info = new renegotiation_info();
        public renegotiation_info Renegotiation_info
        {
            get { return _renegotiation_info; }
            set { _renegotiation_info = value; }
        }

        private elliptic_curves _elliptic_curves = new elliptic_curves();
        public elliptic_curves Elliptic_curves
        {
            get { return _elliptic_curves; }
            set { _elliptic_curves = value; }
        }

        private ec_point_formats _ec_point_formats = new ec_point_formats();
        public ec_point_formats Ec_point_formats
        {
            get { return _ec_point_formats; }
            set { _ec_point_formats = value; }
        }


        private SessionTicketTLS _sessionTicketTLS = new SessionTicketTLS();
        public SessionTicketTLS SessionTicketTLS
        {
            get { return _sessionTicketTLS; }
            set { _sessionTicketTLS = value; }
        }
    }
}
