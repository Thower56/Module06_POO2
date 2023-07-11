using Entites;
using TraitementsLots;

namespace TraitementsLots.ModifierPaysMajusculesClients;
public class ModifierPaysMajusculesClientsTraitementLot : ITraitementLot
{
    private IDepotClients m_depotClient;
    public ModifierPaysMajusculesClientsTraitementLot(IDepotClients p_depotClient)
    {
        m_depotClient = p_depotClient;
    }
    public void Executer() 
    {
        List<Client> listeClient = m_depotClient.ListerClients();

        foreach (Client c in listeClient)
        {
            c.Adresses
                .Where(a => a.Pays.Any(c => Char.IsLower(c)))
                .ToList()
                .ForEach(a => a.ChangerPayEnMajuscule());

            m_depotClient.ModifierClient(c);
        }

        
    }
}
