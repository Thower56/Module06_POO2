using Entites;

namespace CoucheAccesDonnees.XML;
public class ClientXMLDTO
{
    public Guid ClientId {get; private set;}
        public string Nom{get ; private set;}
        public string Prenom{get; private set;}
        public List<Adresse> Adresses{get; private set;}

        public ClientXMLDTO(){}
        public ClientXMLDTO(Client p_client){}
        public Client VersEntite(){}
}
