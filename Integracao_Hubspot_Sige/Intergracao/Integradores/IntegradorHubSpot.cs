using Integracao_Hubspot_Sige.Intergracao.Comunicacao;
using Integracao_Hubspot_Sige.Intergracao.Entidades;
using Integracao_Hubspot_Sige.Intergracao.Entidades.EntidadesHUBSPOT.RetornosAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integracao_Hubspot_Sige.Intergracao.Integradores
{
    public class IntegradorHubSpot
    {
        private static string last_vid_offset = string.Empty;

        public List<string> GetAllContatctsVID()
        {
            try
            {
                var vids = new List<string>();
                var hasMore = false;

                hasMore:
                var contactsVID = APIHubSpot.GetAllContacts(last_vid_offset);
                if (contactsVID.contacts.Any())
                {
                    vids.AddRange(contactsVID.contacts.Select(q => q.vid));
                }
                if (contactsVID.has_more)
                {
                    last_vid_offset = contactsVID.vid_offset;
                    goto hasMore;
                }
                return vids;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Contato GetContactByVid(string vid)
        {
            var contato = APIHubSpot.GetContact(vid);
            if (!ValidarContato(contato))
            {
                return null;
            }

            return contato.Contato();
        }

        public void AtualizarContato(Contato contato)
        {
            APIHubSpot.AtualizarContato(contato);
        }

        public void CriarContato(Contato contato)
        {
            APIHubSpot.CriarContato(contato);
        }

        public bool ValidarContato(RetornoGetByVid contato)
        {
            if (contato == null || contato.Properties == null || contato.Properties.cpf_Cnpj == null)
            {
                return false;
            }

            if (string.IsNullOrEmpty(contato.Properties.cpf_Cnpj.value))
            {
                return false;
            }
            else
            {
                contato.Properties.cpf_Cnpj.value = contato.Properties.cpf_Cnpj.onlyNumbers();
                if (contato.Properties.cpf_Cnpj.value.Length != 11 && contato.Properties.cpf_Cnpj.value.Length != 14)
                {
                    return false;
                }
            }

            return true;
        }

    }
}
