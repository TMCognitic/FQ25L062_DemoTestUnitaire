using System.Text.RegularExpressions;

namespace ConsoleApp.Domains.Entities
{
    public class Courant
    {
        public static Courant Create(string numero, Personne titulaire, double ligneDeCredit = 0D)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(numero);
            ArgumentNullException.ThrowIfNull(titulaire);

            if(!Regex.IsMatch(numero, RegexPattern.AccountNumberPattern))
                throw new ArgumentException($"numero ne respecte pas le pattern '{RegexPattern.AccountNumberPattern}'", nameof(numero));            

            if (ligneDeCredit < 0)
                throw new ArgumentException("ligneDeCredit doit être positif", nameof(ligneDeCredit));


            return new Courant(numero, ligneDeCredit, titulaire);
        }


        private double _ligneDeCredit;
        public string Numero { get; }
        public double Solde { get; private set; }

        public double LigneDeCredit
        {
            get
            {
                return _ligneDeCredit;
            }

            set
            {
                if (value < 0)
                    throw new InvalidOperationException();

                _ligneDeCredit = value;
            }
        }

        public Personne Titulaire { get; }

        private Courant(string numero, double ligneDeCredit, Personne titulaire)
        {
            Numero = numero;
            LigneDeCredit = ligneDeCredit;
            Titulaire = titulaire;
        }

        public void Depot(double montant)
        {
            if (montant <= 0D)
                throw new ArgumentException("Montant invalide", nameof(montant));

            Solde += montant;
        }

        public void Retrait(double montant)
        {
            if (montant <= 0D)
                throw new ArgumentException("Montant invalide", nameof(montant));

            if (Solde - montant < -LigneDeCredit)
                throw new InvalidOperationException("Solde insuffisant");

            Solde -= montant;
        }
    }
}
