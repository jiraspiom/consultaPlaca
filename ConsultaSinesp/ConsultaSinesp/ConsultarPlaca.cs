using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace ConsultaSinesp
{
    public class ConsultarPlaca
    {
        private string secret = "#8.1.0#g8LzUadkEHs7mbRqbX5l";
        private string url = "https://189.9.194.154/sinesp-cidadao/mobile/consultar-placa/v4";

        public string Consultar(string placa)
        {
            XmlDocument document = new XmlDocument();
            XmlDocument doc = new XmlDocument();
            try
            {
                int nErros = 0;

                Uri urlpost = new Uri(url);
                HttpWebRequest httpPostConsulta = (HttpWebRequest)HttpWebRequest.Create(urlpost);
                string key = placa + secret;
                System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
                byte[] keyByte = encoding.GetBytes(key);
                HMACSHA1 hmacsha1 = new HMACSHA1(keyByte);
                byte[] messageBytes = encoding.GetBytes(placa);

                byte[] hashmessage = hmacsha1.ComputeHash(messageBytes);

                string hmac2 = ByteToString(hashmessage).ToLower();
                //Xml que vai para o servidor do sinesp cidadao
                StringBuilder postConsultaComParametros = new StringBuilder();

                postConsultaComParametros.Append("<v:Envelope xmlns:i='http://www.w3.org/2001/XMLSchema-instance' xmlns:d='http://www.w3.org/2001/XMLSchema' xmlns:c='http://schemas.xmlsoap.org/soap/encoding/' xmlns:v='http://schemas.xmlsoap.org/soap/envelope/'>");
                postConsultaComParametros.Append("<v:Header>                                                                  ");
                postConsultaComParametros.Append("<b>Google Android SDK built for x86</b>                                                     ");
                postConsultaComParametros.Append("<c>ANDROID</c>                                                              ");
                postConsultaComParametros.Append("<d>8.1.0</d>                                                                ");

                postConsultaComParametros.Append("<e>4.3.2</e>                                                                ");
                postConsultaComParametros.Append("<f>10.0.2.15</f>                                                             ");
                postConsultaComParametros.Append("<g>" + hmac2 + "</g>                                                                   ");

                postConsultaComParametros.Append("<h>0.0</h>                                                                   ");
                postConsultaComParametros.Append("<i>0.0</i>                                                                   ");
                postConsultaComParametros.Append("<k></k>                                                                     ");
                postConsultaComParametros.Append("<l>" + String.Format("{0:yyyy-MM-dd HH:mm:ss}", DateTime.Now) + "</l>");
                postConsultaComParametros.Append("<m>8797e74f0d6eb7b1ff3dc114d4aa12d3</m>                                     ");
                postConsultaComParametros.Append("</v:Header>                                                                 ");
                postConsultaComParametros.Append("<v:Body>                                                                    ");
                postConsultaComParametros.Append("<n0:getStatus xmlns:n0='http://soap.ws.placa.service.sinesp.serpro.gov.br/'>");
                postConsultaComParametros.Append("<a>" + placa + "</a>");
                postConsultaComParametros.Append("</n0:getStatus>");
                postConsultaComParametros.Append("</v:Body>");
                postConsultaComParametros.Append("</v:Envelope>");

                var data = Encoding.ASCII.GetBytes(postConsultaComParametros.ToString());
                httpPostConsulta.Method = "POST";
                httpPostConsulta.ContentType = "text/xml;charset=utf-8";
                httpPostConsulta.ContentLength = data.Length;
                httpPostConsulta.KeepAlive = false;

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

                // Skip validation of SSL/TLS certificate
                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                using (var stream = httpPostConsulta.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                var response = (HttpWebResponse)httpPostConsulta.GetResponse();

                var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

                return responseString.ToString();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
         
        }

        private string ByteToString(byte[] buff)
        {
            string sbinary = "";

            for (int i = 0; i < buff.Length; i++)
            {
                sbinary += buff[i].ToString("X2"); // hex format
            }
            return (sbinary);
        }
       
    }
}
