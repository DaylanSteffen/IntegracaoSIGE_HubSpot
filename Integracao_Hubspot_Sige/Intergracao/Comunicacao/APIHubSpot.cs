using Integracao_Hubspot_Sige.Intergracao.Entidades;
using Integracao_Hubspot_Sige.Intergracao.Entidades.EntidadesHUBSPOT.RetornosAPI;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace Integracao_Hubspot_Sige.Intergracao.Comunicacao
{
    public class APIHubSpot : Request
    {
        public static RetornoGetAll GetAllContacts(string last_vid_offset)
        {
            HttpWebRequest req = null;
            if (string.IsNullOrEmpty(last_vid_offset))
            {
                req = (HttpWebRequest)WebRequest.Create(Metodos.GetAllContacts);
            }
            else
            {
                req = (HttpWebRequest)WebRequest.Create($"{Metodos.GetAllContacts}&vidOffset={last_vid_offset}");
            }

            req.Method = "GET";
            req.ContentType = "application/json; charset=utf-8";
            req.Accept = "application/json";
            req.Timeout = 3600000;
            req.Headers.Add("Accept-Language", "en-us,en;");

            var resultString = ReadResponse(req);
            var userData = JsonConvert.DeserializeObject<RetornoGetAll>(resultString);

            return userData;
        }

        public static RetornoGetByVid GetContact(string vid)
        {
            var req = (HttpWebRequest)WebRequest.Create(Metodos.GetContactByVid.Replace("***", vid));
            req.Method = "GET";
            req.ContentType = "application/json; charset=utf-8";
            req.Accept = "application/json";
            req.Timeout = 3600000;
            req.Headers.Add("Accept-Language", "en-us,en;");
            var resultString = ReadResponse(req);
            var userData = JsonConvert.DeserializeObject<RetornoGetByVid>(resultString);

            return userData;
        }

        public static bool AtualizarContato(Contato contato)
        {
            var contatoToJson = ToJsonHubSpot(contato);

            var req = (HttpWebRequest)WebRequest.Create(Metodos.UpdateContact.Replace("***", contato.IdHubSpot));
            req.Method = "POST";
            req.ContentType = "application/json; charset=utf-8";
            req.Accept = "application/json";
            req.Timeout = 3600000;
            req.Headers.Add("Accept-Language", "en-us,en;");
            WriteRequest(req, contatoToJson.json);
            var resultString = ReadResponse(req);

            return string.IsNullOrEmpty(resultString);
        }

        public static string CriarContato(Contato contato)
        {
            var contatoToJson = ToJsonHubSpot(contato);

            var req = (HttpWebRequest)WebRequest.Create(Metodos.CreateContact);
            req.Method = "POST";
            req.ContentType = "application/json; charset=utf-8";
            req.Accept = "application/json";
            req.Timeout = 3600000;
            req.Headers.Add("Accept-Language", "en-us,en;");
            WriteRequest(req, contatoToJson.json);
            var resultString = ReadResponse(req);

            var userData = JsonConvert.DeserializeObject<RetornoGetByVid>(resultString);

            return userData.vid;
        }

        public static ContatoToJsonHubSpot ToJsonHubSpot(Contato contato)
        {
            var contatoUpdate = new ContatoToJsonHubSpot();
            contatoUpdate.vid = contato.IdHubSpot;

            var stringBuilder = new StringBuilder();

            stringBuilder.Append("{");
            stringBuilder.Append("\"properties\": [");


            //cpf cnpxota
            stringBuilder.Append("{");
            stringBuilder.Append("\"property\": \"cpf_cnpj\",");
            stringBuilder.Append($"\"value\": \"{contato.CPF_CNPJ}\"");
            stringBuilder.Append("},");

            //email
            stringBuilder.Append("{");
            stringBuilder.Append("\"property\": \"email\",");
            stringBuilder.Append($"\"value\": \"{contato.Email}\"");
            stringBuilder.Append("},");

            //primeiro nome
            stringBuilder.Append("{");
            stringBuilder.Append("\"property\": \"firstname\",");
            stringBuilder.Append($"\"value\": \"{contato.Nome}\"");
            stringBuilder.Append("},");

            //ultimo nome
            stringBuilder.Append("{");
            stringBuilder.Append("\"property\": \"lastname\",");
            stringBuilder.Append($"\"value\": \"{contato.Sobrenome}\"");
            stringBuilder.Append("},");

            //telefone
            stringBuilder.Append("{");
            stringBuilder.Append("\"property\": \"phone\",");
            stringBuilder.Append($"\"value\": \"{contato.Telefone}\"");
            stringBuilder.Append("},");

            //endereco
            stringBuilder.Append("{");
            stringBuilder.Append("\"property\": \"address\",");
            stringBuilder.Append($"\"value\": \"{contato.Endereço}\"");
            stringBuilder.Append("},");

            //cidade
            stringBuilder.Append("{");
            stringBuilder.Append("\"property\": \"city\",");
            stringBuilder.Append($"\"value\": \"{contato.Cidade}\"");
            stringBuilder.Append("},");

            //estado
            stringBuilder.Append("{");
            stringBuilder.Append("\"property\": \"state\",");
            stringBuilder.Append($"\"value\": \"{contato.Estado}\"");
            stringBuilder.Append("},");

            //cep
            stringBuilder.Append("{");
            stringBuilder.Append("\"property\": \"cep\",");
            stringBuilder.Append($"\"value\": \"{contato.CEP}\"");
            stringBuilder.Append("}");

            stringBuilder.Append("]}");

            contatoUpdate.json = stringBuilder.ToString();
            return contatoUpdate;
        }

        public static class Metodos
        {
            private const string APIKEY = "";

            //GET
            public static string GetAllContacts = $"https://api.hubapi.com/contacts/v1/lists/all/contacts/all?hapikey={APIKEY}&count=100";
            public static string GetContactByVid = $"https://api.hubapi.com/contacts/v1/contact/vid/{"***"}/profile?hapikey={APIKEY}";

            //POST
            public static string UpdateContact = $"https://api.hubapi.com/contacts/v1/contact/vid/{"***"}/profile?hapikey={APIKEY}";
            public static string CreateContact = $"https://api.hubapi.com/contacts/v1/contact/?hapikey={APIKEY}";
        }

    }
}
