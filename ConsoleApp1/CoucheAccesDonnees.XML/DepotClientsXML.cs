using CoucheAccesDonnees.JSON;
using Entites;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace CoucheAccesDonnees.XML
{
    public class DepotClientsXML : IDepotClients
    {
        private string m_nomFichier;
        public DepotClientsXML(string p_nomFichier)
        {
            m_nomFichier = p_nomFichier;
        }

        private List<ClientXMLDTO> ImportationClientXML()
        {
            List<ClientXMLDTO> listXML;

            XmlSerializer serializer = new XmlSerializer(typeof(List<ClientXMLDTO>),
                new Type[]
                {
                    typeof(ClientXMLDTO),
                    typeof(AdresseXMLDTO)
                });

            if (File.Exists(m_nomFichier))
            {
                using (FileStream r = new FileStream(m_nomFichier, FileMode.Open))
                {
                    listXML = (List<ClientXMLDTO>)serializer.Deserialize(r);
                }
            }
            else
            {
                listXML = new List<ClientXMLDTO>();
            }

            return listXML;
        }

        private void ExportationDeListeClientXml(List<ClientXMLDTO> p_listClient)
        {
            if (p_listClient == null)
            {
                throw new ArgumentNullException("La liste client ne doit pas etre null");
            }
            XmlSerializer serializer = new XmlSerializer(typeof(List<ClientXMLDTO>), 
                new Type[] 
                {
                    typeof(ClientXMLDTO),
                    typeof(AdresseXMLDTO) 
                });

            XmlWriterSettings setting = new XmlWriterSettings();
            setting.Indent = true;
            //setting.IndentChars = "\n";
            
             

            
            using (XmlWriter writer = XmlWriter.Create(m_nomFichier, setting))
            {
                writer.WriteStartDocument();
                if (p_listClient.Any())
                {
                    serializer.Serialize(writer, p_listClient);
                }
                else
                {
                    serializer.Serialize(writer, new List<ClientXMLDTO>());
                }
                writer.Dispose();
                writer.Close();
            }
            
            
        }
        public void AjouterClient(Client p_client)
        {
            if (p_client == null)
            {
                throw new ArgumentNullException("Le client ne doit pas etre null");
            }
            ClientXMLDTO newClient = new ClientXMLDTO(p_client);

            List<ClientXMLDTO> listeXML = ImportationClientXML();

            listeXML.Add(newClient);

            ExportationDeListeClientXml(listeXML);
            
        }
        public List<Client> ListerClients()
        {
            List<ClientXMLDTO> listeXML = ImportationClientXML();

            List<Client> listeClient = listeXML.ConvertAll(c => c.VersEntite());
            return listeClient;
        }
        public Client RechercherClient(Guid p_clientID)
        {
            if (p_clientID == null)
            {
                throw new ArgumentNullException("L'id du client ne doit pas etre null");
            }
            List<ClientXMLDTO> listeXML = ImportationClientXML();

            return listeXML.ConvertAll(c => c.VersEntite()).Find(c => c.ClientId == p_clientID);
        }
        public void ModifierClient(Client p_client)
        {
            if (p_client == null)
            {
                throw new ArgumentNullException("Le client ne doit pas etre null");
            }
            List<ClientXMLDTO> listeXML = ImportationClientXML();

            for (int i = 0; i < listeXML.Count(); i++) 
            {
                if (listeXML[i].ClientId == p_client.ClientId) 
                {
                    listeXML[i] = new ClientXMLDTO(p_client);
                }
            }
        }
    }
}