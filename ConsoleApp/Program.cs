// See https://aka.ms/new-console-template for more information
using ConsoleApp.Domains.Entities;

Personne personne = Personne.Create("Doe", "John", new DateTime(1984, 1, 1));
Courant courant = Courant.Create("2025-00000001", personne);


courant.Depot(500);
courant.Retrait(200);

Console.WriteLine(courant.Solde);