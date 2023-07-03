namespace Entites;
public class Client
{
    public Guid ClientId {get; private set;}
    public string Nom{get ; private set;}
    public string Prenom{get; private set;}
    public List<Adresse> Adresses{get; private set;}

    public Client(Guid p_clientId, string p_nom, string p_Prenom, IEnumerable<Adresse> p_adresse)
    {
        ClientId = p_clientId;
        Nom = p_nom;
        Prenom = p_Prenom;
        Adresses = p_adresse;
    }
    public void AjouterModifierAdresse(Adresse p_adresse)
    {
        bool existe = false;
        foreach(Adresse a in Adresses)
        {
            if(a.AdresseId == p_adresse.AdresseId)
            {
                a. = p_adresse;
                existe = true;
            }   
        }
        if(!existe)
        {
            Adresses.Add(p_adresse);
        }
    }
}
