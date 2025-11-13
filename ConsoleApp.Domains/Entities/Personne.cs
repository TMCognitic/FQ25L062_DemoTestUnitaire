using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Domains.Entities
{
    public class Personne
    {
        public static Personne Create(string nom, string prenom, DateTime dateNaiss)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(nom);
            ArgumentException.ThrowIfNullOrWhiteSpace(prenom);

            if (dateNaiss < new DateTime(1970, 1, 1))
                throw new ArgumentException("Date de naissance invalide", nameof(dateNaiss));

            return new Personne(nom, prenom, dateNaiss);
        }

        public string Nom { get; }
        public string Prenom { get; }
        public DateTime DateNaiss { get; }

        private Personne(string nom, string prenom, DateTime dateNaiss)
        {
            Nom = nom;
            Prenom = prenom;
            DateNaiss = dateNaiss;
        }
    }
}
