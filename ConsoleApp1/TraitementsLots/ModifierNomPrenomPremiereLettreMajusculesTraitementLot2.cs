using Entites;
using TraitementsLots;
namespace TraitementsLots.ModifierNomPrenomPremiereLettreMajuscules;
public class ModifierNomPrenomPremiereLettreMajusculesTraitementLot : ITraitementLot
{
    private IDepotClients m_depotClient;

    public ModifierNomPrenomPremiereLettreMajusculesTraitementLot(IDepotClients p_depotClient)
    {
        m_depotClient = p_depotClient;
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
                c.ChangerNomEtPrenomMajusculeClient();
            }
            if (!Char.IsUpper(prenom[0]))
            {
                c.ChangerNomEtPrenomMajusculeClient();
            }
            m_depotClient.ModifierClient(c);
        }
    }
}
