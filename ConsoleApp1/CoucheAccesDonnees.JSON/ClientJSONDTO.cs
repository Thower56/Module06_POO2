using Entites;

namespace CoucheAccesDonnees.JSON;
public class ClientJSONDTO
{
    public Guid ClientId {get; private set;}
    public string Nom{get ; private set;}
    public string Prenom{get; private set;}
    public List<AdresseJSONDTO> Adresses{get; private set;}

    public ClientJSONDTO(){}
    public ClientJSONDTO(Client p_client)
    {
        this.ClientId = p_client.ClientId;
        this.Nom = p_client.Nom;
        this.Prenom = p_client.Prenom;
        this.Adresses = p_client.Adresses.Select(a => new AdresseJSONDTO(a)).ToList();
        
    }
    public Client VersEntite()
    {
        Client versClient = new Client
            (
                ClientId,
                Nom,
                Prenom,
                Adresses.ConvertAll(c => c.VersEntite()).ToList()
            ) ;

        return versClient;
    }
}
