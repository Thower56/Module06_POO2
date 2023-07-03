namespace Entites
{
    public interface IDepotClients
    {
        public void AjouterClient(Client p_client);
        public List<Client> ListerClients();
        public Client RechercherClient(Guid p_client);
        public void ModifierCLient(Client p_client);
    }
}