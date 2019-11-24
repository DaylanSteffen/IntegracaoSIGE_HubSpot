using Integracao_Hubspot_Sige.Intergracao.Entidades;
using Integracao_Hubspot_Sige.Intergracao.Integradores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integracao_Hubspot_Sige.Intergracao.Tasks
{
    public class TarefasHubSpot
    {
        IntegradorHubSpot integradorHubSpot = new IntegradorHubSpot();

        public void Teste()
        {
            try
            {
                var contato = integradorHubSpot.GetContactByVid("150601");
                contato.Email = "daylanzito@gmail.com";
                contato.Nome = "Daylan Teste API UPDATE";
                contato.Sobrenome = "Steffenzito";
                integradorHubSpot.AtualizarContato(contato);

                contato.Email = "daylanzito@criarContato.com";
                contato.Nome = "Daylan Teste API Criar";
                contato.Sobrenome = "Steffenzito";
                integradorHubSpot.CriarContato(contato);

            }
            catch (Exception ex)
            {

            }

        }

        public List<Contato> BuscarTodosContatos()
        {
            var contatos = new List<Contato>();
            var vids = integradorHubSpot.GetAllContatctsVID();

            foreach (var vid in vids)
            {
                try
                {
                    var contato = integradorHubSpot.GetContactByVid(vid);
                    if (contato == null)
                    {
                        continue;
                    }

                    contatos.Add(contato);
                }
                catch (Exception ex)
                {
                    continue;
                }

            }

            return contatos;
        }

    }
}
