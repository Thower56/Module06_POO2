using Entites;

namespace CoucheAccesDonnees.JSON;
public class ClientJSONDTO
{
        public Guid ClientId {get; private set;}
        public string Nom{get ; private set;}
        public string Prenom{get; private set;}
        public List<Adresse> Adresses{get; private set;}

        public ClientJSONDTO(){}
        public ClientJSONDTO(Client p_client){}
        public Client VersEntite(){}
}
