

using Entites;

namespace CoucheAccesDonnees.JSON
{
    public class AdresseJSONDTO
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

        public AdresseJSONDTO(){}
        public AdresseJSONDTO(Adresse p_client)
        {
            AdresseId = p_client.AdresseId;
            NumeroCivique = p_client.NumeroCivique;
            InformationComplementaire = p_client.InformationComplementaire;
            Odonyme = p_client.Odonyme;
            TypeVoie = p_client.TypeVoie;
            CodePostal = p_client.CodePostal;
            NomMunicipalite = p_client.NomMunicipalite;
            Etat = p_client.Etat;
            Pays = p_client.Pays;
        }
        public Adresse VersEntite()
        {
            Adresse versAdresse = new Adresse(AdresseId, NumeroCivique, InformationComplementaire, Odonyme, TypeVoie, CodePostal, NomMunicipalite, Etat, Pays);

            return versAdresse;
        }
    }
}