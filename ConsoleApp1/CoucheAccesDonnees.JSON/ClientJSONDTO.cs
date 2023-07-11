using Entites;

namespace CoucheAccesDonnees.JSON;
public class ClientJSONDTO
{
    public Guid ClientId {get; set;}
    public string Nom{get ; set;}
    public string Prenom{get; set;}
    public List<AdresseJSONDTO> Adresses{get; set;}

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
