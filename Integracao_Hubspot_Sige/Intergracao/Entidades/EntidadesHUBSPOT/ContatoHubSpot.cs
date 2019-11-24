//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Integracao_Hubspot_Sige.Intergracao.Entidades.EntidadesHUBSPOT
//{
//    public class ContatoHubSpot
//    {
//        public string vid { get; set; }
//        public string cpf_cnpj { get; set; }
//        public string email { get; set; }
//        public string firstname { get; set; }
//        public string lastname { get; set; }
//        public string phone { get; set; }
//        public string address { get; set; }
//        public string city { get; set; }
//        public string state { get; set; }
//        public string cep { get; set; }

//        public Contato Contato()
//        {
//            var contato = new Contato();
//            if (this == null)
//            {
//                return new Contato();
//            }

//            contato.IdHubSpot = this.vid;
//            contato.CPF_CNPJ = this.cpf_cnpj;
//            contato.Nome = this.firstname;
//            contato.Sobrenome = this.lastname;
//            contato.Endereço = this.address;
//            contato.Cidade = this.city;
//            contato.Estado = this.state;
//            contato.CEP = this.cep;
//            contato.Email = this.email;
//            contato.Telefone = this.phone;

//            return contato;
//        }
//    }

//}
