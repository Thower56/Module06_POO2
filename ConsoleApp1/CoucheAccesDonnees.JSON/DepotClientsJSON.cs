using Entites;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;


namespace CoucheAccesDonnees.JSON
{
    public class DepotClientsJSON : IDepotClients
    {
        private string m_nomFichier;
        public DepotClientsJSON(string p_nomFichier)
        {
            this.m_nomFichier = p_nomFichier;
        }

        private List<ClientJSONDTO> ImportationListeClientsJson()
        {
            List<ClientJSONDTO> listJson;

            if (File.Exists(m_nomFichier))
            {
                string json = File.ReadAllText(m_nomFichier);
                listJson = JsonConvert.DeserializeObject<List<ClientJSONDTO>>(json);
            }
            else
            {
                listJson = new List<ClientJSONDTO>();
            }

            return listJson;
        }
        public void AjouterClient(Client p_client)
        {
            ClientJSONDTO newClient = new ClientJSONDTO(p_client);

            List<ClientJSONDTO> listJson = ImportationListeClientsJson();

            listJson.Add(newClient);

            string stringJson = JsonConvert.SerializeObject(listJson, Formatting.Indented);
            File.WriteAllText(m_nomFichier, stringJson);

        }
        public List<Client> ListerClients()
        {
            List<ClientJSONDTO> listJson = ImportationListeClientsJson();

            List<Client> listClient = listJson.ConvertAll(c => c.VersEntite()).ToList();
            return listClient;
        }
        public Client RechercherClient(Guid p_clientID)
        {
            List<ClientJSONDTO> listJson = ImportationListeClientsJson();

            return listJson.Where(c => c.ClientId == p_clientID).Select(c => c.VersEntite()).SingleOrDefault();
        }
        public void ModifierClient(Client p_client)
        {

            List<ClientJSONDTO> listJson = ImportationListeClientsJson();

            for (int i = 0; i < listJson.Count(); i++)
            {
                if (listJson[i].ClientId == p_client.ClientId)
                {
                    listJson[i] = new ClientJSONDTO(p_client);
                }
            }
            string stringJson = JsonConvert.SerializeObject(listJson, Formatting.Indented);
            File.WriteAllText(m_nomFichier, stringJson);
        }
    }
}