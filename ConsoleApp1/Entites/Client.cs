namespace Entites;
public class Client
{
    public Guid ClientId {get; private set;}
    public string Nom{get ; private set;}
    public string Prenom{get; private set;}
    public List<Adresse> Adresses{get; private set;}

    public Client(Guid p_clientId, string p_nom, string p_Prenom, List<Adresse> p_adresse)
    {
        ClientId = p_clientId;
        Nom = p_nom;
        Prenom = p_Prenom;
        Adresses = p_adresse;
    }

    public void ChangerNomEtPrenomMajusculeClient()
    {
        string nom = Nom;
        string prenom = Prenom;
        if (!Char.IsUpper(nom[0]))
        {
            string nouveauNom;
            nouveauNom = nom[0].ToString().ToUpper(); ;
            nouveauNom += nom.Substring(1).ToLower();
            Nom = nouveauNom;

        }
        if (!Char.IsUpper(prenom[0]))
        {
            string nouveauPrenom;
            nouveauPrenom = nom[0].ToString().ToUpper();
            nouveauPrenom += nom.Substring(1).ToLower();
            Prenom = nouveauPrenom;
        }
    }

    public void ChangerPayEnMajuscule() { }
    public void ChangerPrenomClient(string p_prenom)
    {
        this.Prenom = p_prenom;
    }
    public void AjouterModifierAdresse(Adresse p_adresse)
    {
        bool existe = false;
        for(int i=0; i < Adresses.Count; ++i)
        {
            if (p_adresse.AdresseId == Adresses[i].AdresseId)
            {
                Adresses[i] = p_adresse;
                existe = true;
            }
        }
        if(!existe)
        {
            Adresses.Add(p_adresse);
        }
    }

    public override string ToString()
    {
        string client = $"ID      : {ClientId}\n" +
               $"Nom     : {Nom} \n" +
               $"Prenom  : {Prenom}\n" +
               $"Adresses: ";
        foreach (Adresse a in Adresses)
        {
            client += a.ToString();
        }

        return client;
    }
}
