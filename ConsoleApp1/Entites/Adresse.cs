namespace Entites
{
    public class Adresse
    {
        public Guid AdresseId {get; private set;}
        public string NumeroCivique {get; private set;}
        public string InformationComplementaire {get; private set;}
        public string Odonyme {get; private set;}
        public string TypeVoie{get; private set;}
        public string CodePostal{get; private set;}
        public string NomMunicipalite{get; private set;}
        public string Etat{get; private set;}
        public string Pays{get; private set;}
    }
}