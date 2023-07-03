using Entites;

namespace CoucheAccesDonnees.XML
{
    public class DepotClientsXML : IDepotClients
    {
        private string m_nomFichier;
        public DepotClientsJSON(){}
        public void AjouterClient(Client p_client){}
        public List<Client> ListerCLients(){}
        public Client RechercherClient(Guid p_clientID){}
        public void ModifierClient(Client p_client){}
    }
}