using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TlsClient.Model;

namespace TlsClient.Manager
{
    public class C_To_S_OneManager : IRequestManager
    {
        private C_To_S_One csOne;
        public C_To_S_OneManager()
        {
            if(csOne == null)
                csOne = new C_To_S_One();
        }

        public void InitPackage()
        {
            csOne.Base.ContentType = 22;
            csOne.Base.Version[0] = 3;
            csOne.Base.Version[1] = 1;
            csOne.Base.Length[0] = 0;
            csOne.Base.Length[1] = 72;
            csOne.ClientHello.HandshakeType = 1;
            csOne.ClientHello.Length[0] = 0;
            csOne.ClientHello.Length[1] = 0;
            csOne.ClientHello.Length[2] = 68;
            csOne.ClientHello.Version[0] = 3;
            csOne.ClientHello.Version[1] = 1;
            long seconds = (long)DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            csOne.ClientHello.Gmt_unix_time[3] = (byte)(seconds & 0xFF);
            csOne.ClientHello.Gmt_unix_time[2] = (byte)(seconds >> 8 & 0xFF);
            csOne.ClientHello.Gmt_unix_time[1] = (byte)(seconds >> 16 & 0xFF);
            csOne.ClientHello.Gmt_unix_time[0] = (byte)(seconds >> 24 & 0xFF);
            Random random = new Random();
            random.NextBytes(csOne.ClientHello.Random_bytes);
            csOne.ClientHello.SessionIDLength = 0;
            csOne.ClientHello.CipherSuitesLength[0] = 0;
            csOne.ClientHello.CipherSuitesLength[1] = 2;
            csOne.ClientHello.CipherSuites[0] = 0;
            csOne.ClientHello.CipherSuites[1] = 4;
            csOne.ClientHello.CompressionMethodsLength = 1;
            csOne.ClientHello.CompressionMethods = 0;
            csOne.ClientHello.ExtensionsLength[0] = 0;
            csOne.ClientHello.ExtensionsLength[1] = 25;
            csOne.ClientHello.Renegotiation_info.Type[0] = 255;
            csOne.ClientHello.Renegotiation_info.Type[1] = 1;
            csOne.ClientHello.Renegotiation_info.Length[0] = 0;
            csOne.ClientHello.Renegotiation_info.Length[1] = 1;
            csOne.ClientHello.Renegotiation_info.Renegotiationinfoextensionlength = 0;
            csOne.ClientHello.Elliptic_curves.Type[0] = 0;
            csOne.ClientHello.Elliptic_curves.Type[1] = 10;
            csOne.ClientHello.Elliptic_curves.Length[0] = 0;
            csOne.ClientHello.Elliptic_curves.Length[1] = 6;
            csOne.ClientHello.Elliptic_curves.EllipticCurvesLength[0] = 0;
            csOne.ClientHello.Elliptic_curves.EllipticCurvesLength[1] = 4;
            csOne.ClientHello.Elliptic_curves.Ellipticcurves[0] = 0;
            csOne.ClientHello.Elliptic_curves.Ellipticcurves[1] = 23;
            csOne.ClientHello.Elliptic_curves.Ellipticcurves[2] = 0;
            csOne.ClientHello.Elliptic_curves.Ellipticcurves[3] = 24;
            csOne.ClientHello.Ec_point_formats.Type[0] = 0;
            csOne.ClientHello.Ec_point_formats.Type[1] = 11;
            csOne.ClientHello.Ec_point_formats.Length[0] = 0;
            csOne.ClientHello.Ec_point_formats.Length[1] = 2;
            csOne.ClientHello.Ec_point_formats.ECpointformatsLength = 1;
            csOne.ClientHello.Ec_point_formats.ECpointformat = 0;
            csOne.ClientHello.SessionTicketTLS.Type[0] = 0;
            csOne.ClientHello.SessionTicketTLS.Type[1] = 35;
            csOne.ClientHello.SessionTicketTLS.Length[0] = 0;
            csOne.ClientHello.SessionTicketTLS.Length[1] = 0;
        }



        public MemoryStream InitStream()
        {
            MemoryStream stream = new MemoryStream();
            stream.WriteByte(csOne.Base.ContentType);
            stream.Write(csOne.Base.Version, 0, 2);
            stream.Write(csOne.Base.Length, 0, 2);
            stream.WriteByte(csOne.ClientHello.HandshakeType);
            stream.Write(csOne.ClientHello.Length, 0, 3);
            stream.Write(csOne.ClientHello.Version, 0, 2);
            stream.Write(csOne.ClientHello.Gmt_unix_time, 0, 4);
            stream.Write(csOne.ClientHello.Random_bytes, 0, 28);
            stream.WriteByte(csOne.ClientHello.SessionIDLength);
            stream.Write(csOne.ClientHello.CipherSuitesLength, 0, 2);
            stream.Write(csOne.ClientHello.CipherSuites, 0, 2);
            stream.WriteByte(csOne.ClientHello.CompressionMethodsLength);
            stream.WriteByte(csOne.ClientHello.CompressionMethods);
            stream.Write(csOne.ClientHello.ExtensionsLength, 0, 2);
            stream.Write(csOne.ClientHello.Renegotiation_info.Type, 0, 2);
            stream.Write(csOne.ClientHello.Renegotiation_info.Length, 0, 2);
            stream.WriteByte(csOne.ClientHello.Renegotiation_info.Renegotiationinfoextensionlength);
            stream.Write(csOne.ClientHello.Elliptic_curves.Type, 0, 2);
            stream.Write(csOne.ClientHello.Elliptic_curves.Length, 0, 2);
            stream.Write(csOne.ClientHello.Elliptic_curves.EllipticCurvesLength, 0, 2);
            stream.Write(csOne.ClientHello.Elliptic_curves.Ellipticcurves, 0, 4);
            stream.Write(csOne.ClientHello.Ec_point_formats.Type, 0, 2);
            stream.Write(csOne.ClientHello.Ec_point_formats.Length, 0, 2);
            stream.WriteByte(csOne.ClientHello.Ec_point_formats.ECpointformatsLength);
            stream.WriteByte(csOne.ClientHello.Ec_point_formats.ECpointformat);
            stream.Write(csOne.ClientHello.SessionTicketTLS.Type, 0, 2);
            stream.Write(csOne.ClientHello.SessionTicketTLS.Length, 0, 2);
            return stream;
        }
    }
}
