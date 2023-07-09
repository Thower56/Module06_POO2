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
                nouveauNom = nom[0].ToString();
                nouveauNom += nom.Substring(1);

            }
        }
    }
}
