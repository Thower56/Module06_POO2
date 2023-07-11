namespace Entites
{
    public class Adresse
    {
        public Adresse(Guid adresseId, string numeroCivique, string informationComplementaire, string odonyme, string typeVoie, string codePostal, string nomMunicipalite, string etat, string pays)
        {
            AdresseId = adresseId;
            NumeroCivique = numeroCivique;
            InformationComplementaire = informationComplementaire;
            Odonyme = odonyme;
            TypeVoie = typeVoie;
            CodePostal = codePostal;
            NomMunicipalite = nomMunicipalite;
            Etat = etat;
            Pays = pays;
        }
        public Adresse() { }
        public Guid AdresseId {get; private set;}
        public string NumeroCivique {get; private set;}
        public string InformationComplementaire {get; private set;}
        public string Odonyme {get; private set;}
        public string TypeVoie{get; private set;}
        public string CodePostal{get; private set;}
        public string NomMunicipalite{get; private set;}
        public string Etat{get; private set;}
        public string Pays{get; private set;}

        public void ChangerPayEnMajuscule()
        {
            if (Pays.Any(p => Char.IsLower(p)))
            {
                Pays = Pays.ToUpper();
            }
        }
        public override string ToString()
        {
            return $"{AdresseId} : {NumeroCivique} : {InformationComplementaire} : {Odonyme} : {TypeVoie} : {CodePostal} : {NomMunicipalite} : {Etat} : {Pays}\n";
        }
    }
}