using Entites;

namespace CoucheAccesDonnees.XML
{
    public class AdresseXMLDTO
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

        public AdresseXMLDTO(){}
        public AdresseXMLDTO(Adresse p_client){}
        public Client VersEntite(){}
    }
}