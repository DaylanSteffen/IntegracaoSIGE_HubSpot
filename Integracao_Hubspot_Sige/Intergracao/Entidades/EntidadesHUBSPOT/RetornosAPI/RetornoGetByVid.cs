using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Integracao_Hubspot_Sige.Intergracao.Entidades.EntidadesHUBSPOT.RetornosAPI
{
    public class RetornoGetByVid
    {
        public string vid { get; set; }

        [JsonProperty("properties")]
        public Properties Properties { get; set; }

        public Contato Contato()
        {
            var contato = new Contato();
            if (this == null)
            {
                return new Contato();
            }

            contato.IdHubSpot = this.vid;
            contato.CPF_CNPJ = this.Properties.cpf_Cnpj?.value;
            contato.Nome = this.Properties.firstname?.value;
            contato.Sobrenome = this.Properties.lastname?.value;
            contato.Endereço = this.Properties.address?.value;
            contato.Cidade = this.Properties.city?.value;
            contato.Estado = this.Properties.state?.value;
            contato.CEP = this.Properties.cep?.value;
            contato.Email = this.Properties.email?.value;
            contato.Telefone = this.Properties.phone?.value;

            return contato;
        }
    }

    public class Properties
    {
        public cpf_cnpj cpf_Cnpj { get; set; }
        public email email { get; set; }
        public firstname firstname { get; set; }
        public lastname lastname { get; set; }
        public phone phone { get; set; }
        public address address { get; set; }
        public city city { get; set; }
        public state state { get; set; }
        public cep cep { get; set; }
    }

    public class state
    {
        public string value { get; set; }
    }

    public class lastname
    {
        public string value { get; set; }
    }

    public class firstname
    {
        public string value { get; set; }
    }

    public class city
    {
        public string value { get; set; }
    }

    public class email
    {
        public string value { get; set; }
    }

    public class cpf_cnpj
    {
        public string value { get; set; }

        public string onlyNumbers()
        {
            return Regex.Replace(this.value, @"[^\d]", "");
        }
    }

    public class cep
    {
        public string value { get; set; }
    }

    public class address
    {
        public string value { get; set; }
    }

    public class phone
    {
        public string value { get; set; }
    }

    public class ContatoToJsonHubSpot
    {
        public string vid { get; set; }
        public string json { get; set; }
    }

}
