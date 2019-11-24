
namespace Integracao_Hubspot_Sige.Intergracao.Entidades
{
    //Classe de meio de campo de contatos
    public class Contato
    {
        public string IdHubSpot { get; set; }
        public string IdSige { get; set; }

        public string CPF_CNPJ { get; set; }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string NomeCompleto { get { return $"{Nome} {Sobrenome}"; } }

        public string Endereço { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }

        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Grupo { get; set; }
    }


}
