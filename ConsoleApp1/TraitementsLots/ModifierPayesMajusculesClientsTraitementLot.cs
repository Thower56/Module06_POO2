using Entites;
using TraitementsLots;
namespace TraitementsLots.ModifierNomPrenomPremiereLettreMajuscules;
public class ModifierNomPrenomPremiereLettreMajusculesTraitementLot : ITraitementLot
{
    private IDepotClients m_depotClient;
    public ModifierNomPrenomPremiereLettreMajusculesTraitementLot(IDepotClients p_depotClient){}
    public void Executer();
}
