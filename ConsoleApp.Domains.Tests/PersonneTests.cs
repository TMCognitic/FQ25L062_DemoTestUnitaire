using ConsoleApp.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Domains.Tests
{
    public class PersonneTests
    {
        [Fact]
        public void ValidPersonneTest()
        {
            //Arrange
            Personne? personne = null;
            //Act
            personne = Personne.Create("Doe", "Jane", new DateTime(1981, 7, 28));

            //Assert
            Assert.NotNull(personne);
            Assert.Equal("Doe", personne.Nom);
            Assert.Equal("Jane", personne.Prenom);
            Assert.Equal(new DateTime(1981, 7, 28), personne.DateNaiss);
        }

        [Fact]
        public void NomIsNullTest()
        {
            //Arrange
            Personne? personne = null;
            
            //Act
            Action action = () => personne = Personne.Create(null, "Jane", new DateTime(1981, 7, 28));

            //Assert
            Assert.Throws<ArgumentNullException>(action);
        }

        [Fact]
        public void InvalidDateNaissTest()
        {
            //Arrange
            Personne? personne = null;

            //Act
            Action action = () => personne = Personne.Create("Doe", "Jane", new DateTime(1919, 7, 28));

            //Assert
            Assert.Throws<ArgumentException>(action);            
        }
    }
}
