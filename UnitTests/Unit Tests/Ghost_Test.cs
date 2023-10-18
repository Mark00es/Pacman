using System;
using System.Windows.Forms;
using NUnit.Framework;

namespace Pacman.Test
{
    [TestFixture]
    public class Ghost_Test
    {
        private Ghost ghost;
        private Form testForm;

        [SetUp]
        public void SetUp()
        {
            // Inicializa una nueva instancia de Ghost y un formulario de prueba
            ghost = new Ghost();
            testForm = new Form();
        }
        [TearDown]
        public void TearDown()
        {
            // Limpia los recursos después de cada prueba
            testForm.Dispose();
        }

        [Test]
        public void CreateGhostImageTest()
        {
            ghost.CreateGhostImage(testForm);
            for (int i = 0; i < ghost.Ghosts; i++)
            {
                Assert.IsNotNull(ghost.GhostImage[i]);
                Assert.AreEqual("GhostImage" + i, ghost.GhostImage[i].Name);
                Assert.AreEqual(PictureBoxSizeMode.AutoSize, ghost.GhostImage[i].SizeMode);
                Assert.AreSame(testForm, ghost.GhostImage[i].Parent);
            }
        }
    }
}
