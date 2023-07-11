using CoucheAccesDonnees.JSON;
using Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Module06_POO2.UnityContainer
{
    public class UnityContainer
    {
        private static Object _lock = new Object();
        private static IUnityContainer _unityContainer = null;
        public static IUnityContainer Conteneur
        {
            get
            {
                if (_unityContainer == null) 
                {
                    lock (_lock)
                    {
                        if (_unityContainer == null)
                        {
                            //_unityContainer = new UnityContainer();
                            EnregistrerDependaces();

                        }
                    }
                }
                return _unityContainer;
            }
        }

        private static void EnregistrerDependaces()
        {
            _unityContainer.RegisterType<IDepotClients, DepotClientsJSON>();
        }
    }
}
