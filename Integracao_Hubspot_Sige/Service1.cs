using Integracao_Hubspot_Sige.Intergracao.Tasks;
using System.ServiceProcess;
using System.Threading.Tasks;

namespace Integracao_Hubspot_Sige
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
            Start();
        }

        protected override void OnStart(string[] args)
        {

        }

        protected override void OnStop()
        {
        }

        private async Task Start()
        {
            var tarefasHub = new TarefasHubSpot();
            tarefasHub.Teste();

        }

    }
}
