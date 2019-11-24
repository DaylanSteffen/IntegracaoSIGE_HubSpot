using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Integracao_Hubspot_Sige.Intergracao.Comunicacao
{
    public  class Request
    {
        public static void WriteRequest(HttpWebRequest httpWebRequest, string requestContent)
        {
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(requestContent);
                streamWriter.Flush();
                streamWriter.Close();
            }
        }

        public static string ReadResponse(HttpWebRequest req)
        {
            var webResponse = req.GetResponse();
            var rd = new StreamReader(webResponse.GetResponseStream());
            return rd.ReadToEnd();
        }
    }
}
