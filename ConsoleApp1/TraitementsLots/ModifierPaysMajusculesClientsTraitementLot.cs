using Entites;
using TraitementsLots;

namespace TraitementsLots.ModifierPaysMajusculesClients;
public class ModifierPaysMajusculesClientsTraitementLot : ITraitementLot
{
    private IDepotClients m_depotClient;
    public ModifierPaysMajusculesClientsTraitementLot(IDepotClients p_depotClient)
    {
        
    }
    public void Executer() 
    {
        List<Client> listeClient = m_depotClient.ListerClients();

        foreach (Client c in listeClient)
        {
            string nom = c.Nom;
            string prenom = c.Prenom;
            if (!Char.IsUpper(nom[0]))
            {
                string nouveauNom;
                nouveauNom = nom[0].ToString().ToUpper(); ;
                nouveauNom += nom.Substring(1).ToLower();
                c.ChangerNomClient(nouveauNom);
                
            }
            if (!Char.IsUpper(prenom[0]))
            {
                string nouveauPrenom;
                nouveauPrenom = nom[0].ToString().ToUpper();
                nouveauPrenom += nom.Substring(1).ToLower();
                c.ChangerNomClient(nouveauPrenom);
            }
            m_depotClient.ModifierClient(c);
        }

        
    }
}
