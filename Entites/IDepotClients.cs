namespace Entites
{
    public interface IDepotClients
    {
        public AjouterClient(Client p_client);
        public List<Client> ListerClients();
        public Client RechercherClient(Client p_client);
        public ModifierCLient(Client p_client);
    }
}