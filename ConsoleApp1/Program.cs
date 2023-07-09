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
            container.RegisterType<IDepotClients, DepotClientsJSON>();
            container.RegisterType<IDepotClients, DepotClientsXML>();

            var ui = container.Resolve<ClientUiConsole>();

            bool on = true;
            int choix;
            while (on)
            {
                ui.AfficherMenu();
                choix = ui.SaisirChoixMenu();

                switch (choix)
                {

                }
            }
        }
    }
}