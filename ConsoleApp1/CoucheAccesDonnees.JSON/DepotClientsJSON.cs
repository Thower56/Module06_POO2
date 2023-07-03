using Entites;
using Newtonsoft.Json;


namespace CoucheAccesDonnees.JSON
{
    public class DepotClientsJSON : IDepotClients
    {
        private string m_nomFichier;
        public DepotClientsJSON(){}
        public void AjouterClient(Client p_client){}
        public List<Client> ListerClients()
        {
            List<Client> listJson = JsonConvert.DeserializeObject<List<Client>>(m_nomFichier);
            return listJson;
        }
        public Client RechercherClient(Guid p_clientID)
        {
            List<Client> listJson = JsonConvert.DeserializeObject<List<Client>>(m_nomFichier);
            foreach (Client c in listJson) 
            {
                if (c.ClientId == p_clientID)
                {
                    return c;
                }
            }
            return null;
        }
        public void ModifierClient(Client p_client)
        {
            List<Client> listJson = JsonConvert.DeserializeObject<List<Client>>(m_nomFichier);

            for (int i = 0; i < listJson.Count(); i++)
            {
                if (listJson[i].ClientId == p_client.ClientId)
                {
                    listJson[i] = p_client;
                }
            }

        }
    }
}