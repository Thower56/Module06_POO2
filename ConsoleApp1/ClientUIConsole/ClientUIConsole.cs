using Entites;

namespace Application
{
    class ClientUiConsole
    {
        private IDepotClients m_depotClient;

        public ClientUiConsole(IDepotClients p_depotClient)
        {
            this.m_depotClient = p_depotClient;
        }

        public void AfficherMenu(){}
        public int SaisirChoixMenu(){}
        public void ExecuterUI(){}
        public Client SaisirClientAvecAdresse(){}
        public void AfficherClient(Client p_client){}
        public void RechercherETAfficherClientParId(){}
        public void ListerEtAfficherClients(){}
        private Adresse GenererAdresseAleatoire(){}

    }
}