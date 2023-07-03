using Entites;
using TraitementsLots;

namespace TraitementsLots.ModifierPaysMajusculesClients;
public class ModifierPaysMajusculesClientsTraitementLot : ITraitementLot
{
    private IDepotClients m_depotClient;
    public ModifierPaysMajusculesClientsTraitementLot(IDepotClients p_depotClient){}
    public void Executer();
}
