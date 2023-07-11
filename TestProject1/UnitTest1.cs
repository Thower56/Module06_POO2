using CoucheAccesDonnees.JSON;
using Entites;
using Moq;
using TraitementsLots;
using TraitementsLots.ModifierNomPrenomPremiereLettreMajuscules;
using TraitementsLots.ModifierPaysMajusculesClients;

namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public void ModifierLeNomOPrenom_1Client_ChangerPremierLettre()
        {
            Mock<IDepotClients> depot = new Mock<IDepotClients>();
            depot.Setup(d => d.ListerClients()).Returns(new List<Client>()
            {
                new Client(Guid.NewGuid(), "grondin", "charles", new List<Adresse>()
                {
                    new Adresse(Guid.NewGuid(), "1","non","Lol Street", "Nord", "G0M 1R0", "St-Mock", "Texas", "Etat of Mock")
                })
            }
            );
            ITraitementLot traitement = new ModifierNomPrenomPremiereLettreMajusculesTraitementLot(depot.Object);
            List<Client> listeClient = depot.Object.ListerClients();
            traitement.Executer();

            depot.Verify(d => d.ListerClients(), Times.Exactly(2));
            Assert.Equal("Charles", listeClient[0].Prenom);
            Assert.Equal("Grondin", listeClient[0].Nom);
        }

        [Fact]
        public void ModifierLePays_1Client2Adresse_1PayChanger()
        {
            Mock<IDepotClients> depot = new Mock<IDepotClients>();
            depot.Setup(d => d.ListerClients()).Returns(new List<Client>()
            {
                new Client(Guid.NewGuid(), "grondin", "charles", new List<Adresse>()
                {
                    new Adresse(Guid.NewGuid(), "1","non","Lol Street", "Nord", "G0M 1R0", "St-Mock", "Texas", "canada"),
                    new Adresse(Guid.NewGuid(), "1","non","Lol Street", "Nord", "G0M 1R0", "St-Mock", "Texas", "ETATMOCK")
                })
            }
            );
            ITraitementLot traitement = new ModifierPaysMajusculesClientsTraitementLot(depot.Object);
            List<Client> listeClient = depot.Object.ListerClients();
            traitement.Executer();

            depot.Verify(d => d.ListerClients(), Times.Exactly(2));
            Assert.Equal("CANADA", listeClient[0].Adresses[0].Pays);
        }
    }
}