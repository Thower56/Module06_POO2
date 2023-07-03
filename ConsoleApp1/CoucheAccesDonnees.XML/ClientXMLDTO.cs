using Entites;

namespace CoucheAccesDonnees.XML;
public class ClientXMLDTO
{
    public Guid ClientId {get; private set;}
    public string Nom{get ; private set;}
    public string Prenom{get; private set;}
    public List<Adresse> Adresses{get; private set;}

    public ClientXMLDTO(){}
    public ClientXMLDTO(Client p_client)
    {
        this.ClientId = p_client.ClientId;
        this.Nom = p_client.Nom;
        this.Prenom = p_client.Prenom;
        this.Adresses = p_client.Adresses;
    }
    public Client VersEntite(){}
}
