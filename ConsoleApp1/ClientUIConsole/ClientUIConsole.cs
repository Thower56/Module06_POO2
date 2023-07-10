using Entites;
using System;
using Bogus;
namespace Application
{
    class ClientUiConsole
    {
        private IDepotClients m_depotClient;

        public ClientUiConsole(IDepotClients p_depotClient)
        {
            this.m_depotClient = p_depotClient;
        }

        public void AfficherMenu()
        {
            Console.WriteLine("1- Saisir un nouveau Client\n" +
                "2- Afficher un clients par ID\n" +
                "3- Rechercher et afficher Client par Id \n" +
                "4- Lister et afficher Clients");

        }
        public int SaisirChoixMenu()
        {
            int choix;
            bool bonChoix = false;
            do
            {
                bonChoix = int.TryParse(Console.ReadLine(), out choix);
            }
            while (!bonChoix);

            return choix;
        }
        public void ExecuterUI(){}

        public Client SaisirClientAvecAdresse()
        {
            Guid id = Guid.NewGuid();
            string prenom;
            string nom;
            Console.WriteLine("Entrez les informations du Client");
            Console.Write("Nom :");
            prenom = Console.ReadLine();
            Console.Write("Prenom :");
            nom = Console.ReadLine();

            List<Adresse> listAdresse = new List<Adresse>();
            listAdresse.Add(GenererAdresseAleatoire());
            
            return new Client(id, prenom, nom, listAdresse);

        }

        public void AfficherClient(Client p_client)
        {
            string infoClient = @$"
            ID Client :{p_client.ClientId}
            Nom       :{p_client.Nom}
            Prenom    :{p_client.Adresses}";
            foreach (Adresse a in p_client.Adresses)
            {
                infoClient += $@"
            Adresse   :{a.AdresseId} - {a.NumeroCivique} - {a.InformationComplementaire} - {a.Odonyme} - {a.TypeVoie} - {a.CodePostal} - {a.NomMunicipalite} - {a.Etat} - {a.Pays}";
            }
            Console.WriteLine(infoClient);
        }


        public void RechercherETAfficherClientParId(Guid p_ClientID)
        {
            List<Client> listClient = m_depotClient.ListerClients();

            Console.WriteLine(listClient.Find(c => c.ClientId == p_ClientID).ToString());
        }
        public void ListerEtAfficherClients()
        {
            List<Client> listClient = m_depotClient.ListerClients();

            foreach (Client c in listClient)
            {
                Console.WriteLine(c.ToString());
            }
        }
        private Adresse GenererAdresseAleatoire()
        {
            Faker<Adresse> fakeAdresse;

            Randomizer.Seed = new Random(123);

            fakeAdresse = new Faker<Adresse>()
                .RuleFor(u => u.AdresseId, f => f.Random.Guid())
                .RuleFor(u => u.NumeroCivique, f => f.Random.Int(1, 1000).ToString())
                .RuleFor(u => u.InformationComplementaire, f => f.Address.Direction())
                .RuleFor(u => u.Odonyme, f => f.Address.StreetName())
                .RuleFor(u => u.TypeVoie, f => f.Address.StreetSuffix())
                .RuleFor(u => u.CodePostal, f => f.Address.ZipCode())
                .RuleFor(u => u.NomMunicipalite, f => f.Address.City())
                .RuleFor(u => u.Etat, f => f.Address.State())
                .RuleFor(u => u.Pays, f => f.Address.Country());

            
            return fakeAdresse;
        }

        
    }
}