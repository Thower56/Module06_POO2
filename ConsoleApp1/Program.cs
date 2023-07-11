using Application;
using CoucheAccesDonnees.JSON;
using CoucheAccesDonnees.XML;
using Entites;
using Unity;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var container = new UnityContainer();
            string fichierJson = @"C:\test.json";
            string ficherXML = @"C:\test.xml";

            if (args.Count() >= 1 && args[0] == "xml")
            {
                container.RegisterType<IDepotClients, DepotClientsXML>(TypeLifetime.Singleton, new Unity.Injection.InjectionConstructor(new object[] { ficherXML }));
            }
            else
            {
                container.RegisterType<IDepotClients, DepotClientsJSON>(TypeLifetime.Singleton, new Unity.Injection.InjectionConstructor(new object[] { fichierJson }));
            }

            var ui = container.Resolve<ClientUiConsole>();

            bool on = true;
            int choix;
            while (on)
            {
                ui.AfficherMenu();
                choix = ui.SaisirChoixMenu();

                switch (choix)
                {
                    case 1:
                        ui.SaisirClientAvecAdresse();
                        break;
                    case 2:
                        //ui.RechercherETAfficherClientParId();
                        break;
                    case 3:
                        break;
                    case 4:
                        ui.ListerEtAfficherClients();
                        break;
                }
            }
        }
    }
}