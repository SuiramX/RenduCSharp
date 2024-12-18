using System;
using Xunit;

namespace Geometrie.DAL.Tests
{
    public class Cercle_DALTest
    {
        [Fact]
        public void Constructeur_SansId_AssigneCorrectementLesValeurs()
        {
            // Arrange
            int centreX = 5;
            int centreY = 10;
            double rayon = 15.5;

            // Act
            var cercle = new Cercle_DAL(centreX, centreY, rayon);

            // Assert
            Assert.Null(cercle.Id);
            Assert.Equal(centreX, cercle.CentreX);
            Assert.Equal(centreY, cercle.CentreY);
            Assert.Equal(rayon, cercle.Rayon);
            Assert.Equal(DateTime.Now.Date, cercle.DateDeCreation.Date); // Vérifie la date de création
            Assert.Null(cercle.DateDeModification);
        }

        [Fact]
        public void Constructeur_AvecId_AssigneCorrectementLesValeurs()
        {
            // Arrange
            int id = 1;
            int centreX = 5;
            int centreY = 10;
            double rayon = 20.0;

            // Act
            var cercle = new Cercle_DAL(id, centreX, centreY, rayon);

            // Assert
            Assert.Equal(id, cercle.Id);
            Assert.Equal(centreX, cercle.CentreX);
            Assert.Equal(centreY, cercle.CentreY);
            Assert.Equal(rayon, cercle.Rayon);
        }

        [Fact]
        public void Propriete_DateDeModification_ModifiableApresCreation()
        {
            // Arrange
            var cercle = new Cercle_DAL(5, 10, 20.0);
            DateTime nouvelleDate = DateTime.Now;

            // Act
            cercle.DateDeModification = nouvelleDate;

            // Assert
            Assert.Equal(nouvelleDate, cercle.DateDeModification);
        }
    }
}
