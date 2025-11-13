using ConsoleApp.Domains.Entities;

namespace ConsoleApp.Domains.Tests
{

    public class CourantTest
    {
        private readonly Courant _courant;

        public CourantTest()
        {
            Personne personne = Personne.Create("Doe", "John", new DateTime(1981, 7, 28));
            _courant = Courant.Create("2025-12345678", personne);
        }

        [Fact]
        public void CreationTest()
        {
            //Arrange
            Personne personne = Personne.Create("Doe", "John", new DateTime(1981, 7, 28));
            
            //Act
            Courant courant = Courant.Create("1234-12345678", personne);

            //Assert
            Assert.Equal(0, courant.Solde);
            Assert.Equal(0, courant.LigneDeCredit);
            Assert.Equal(personne, courant.Titulaire);
            Assert.Equal("1234-12345678", courant.Numero);
        }

        [Fact]
        public void CreationAvecLigneDeCreditTest()
        {
            //Arrange
            Personne personne = Personne.Create("Doe", "John", new DateTime(1981, 7, 28));

            //Act
            Courant courant = Courant.Create("1234-12345678", personne, 300);

            //Assert
            Assert.Equal(0, courant.Solde);
            Assert.Equal(300, courant.LigneDeCredit);
            Assert.Equal(personne, courant.Titulaire);
            Assert.Equal("1234-12345678", courant.Numero);
        }

        [Fact]
        public void InvalideCreationAvecLigneDeCreditTest()
        {
            //Arrange
            Personne personne = Personne.Create("Doe", "John", new DateTime(1981, 7, 28));

            //Act
            Action action =  () => Courant.Create("1234-12345678", personne, -300);

            //Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void SetLigneDeCreditTest()
        {
            //Arrange
            Personne personne = Personne.Create("Doe", "John", new DateTime(1981, 7, 28));
            //Act
            _courant.LigneDeCredit = 500;

            //Assert
            Assert.Equal(500, _courant.LigneDeCredit);
        }

        [Fact]
        public void InvalidLigneDeCreditTest()
        {
            //Arrange
            Personne personne = Personne.Create("Doe", "John", new DateTime(1981, 7, 28));
            //Act
            Action action = () => _courant.LigneDeCredit = -500;

            //Assert
            Assert.Throws<InvalidOperationException>(action);
        }

        [Theory]
        [InlineData(null, typeof(ArgumentNullException))]
        [InlineData("123-12345678", typeof(ArgumentException))]
        [InlineData("1234-123456789", typeof(ArgumentException))]
        [InlineData("12345-12345678", typeof(ArgumentException))]
        [InlineData("1234-1234567", typeof(ArgumentException))]
        public void CourantInvalidCreationTest(string? numero, Type exceptionType)
        {
            //Arrange
            Personne personne = Personne.Create("Doe", "John", new DateTime(1981, 7, 28));

            //Act
            Action action = () => Courant.Create(numero, personne);

            //Assert
            Assert.Throws(exceptionType, action);
        }


        [Fact]
        public void DepotTest()
        {
            //Arrange
            double amount = 250;
            //Act
            _courant.Depot(amount);

            //Assert
            Assert.Equal(amount, _courant.Solde);
        }

        [Fact]
        public void InvalidDepotTest()
        {
            //Arrange
            double amount = -250;
            //Act
            Action action = () => _courant.Depot(amount);

            //Assert
            Assert.Throws<ArgumentException>(action);
        }

        [Fact]
        public void RetraitTest()
        {
            //Arrange
            double amount = 250;
            _courant.Depot(amount);
            //Act
            _courant.Retrait(100);

            //Assert
            Assert.Equal(150, _courant.Solde);
        }

        [Theory]
        [InlineData(-250, typeof(ArgumentException))]
        [InlineData(150, typeof(InvalidOperationException))]
        public void InvalidRetraitTest(double amount, Type exceptionType)
        {
            //Act
            Action action = () => _courant.Retrait(amount);
            //Assert
            Assert.Throws(exceptionType, action);
        }
    }
}
