using NUnit.Framework;
using System.Windows.Forms;

namespace Pacman.Tests
{
    [TestFixture]
    public class FormElementsTest
    {
        private Form formInstance;
        private FormElements formElements;

        [SetUp]
        public void Initialize()
        {
            formInstance = new Form();
            formElements = new FormElements();
            formElements.CreateFormElements(formInstance);
        }

        [Test]
        public void CreateFormElements_CreatesPlayerOneScoreText()
        {
            Label playerOneScoreText = formElements.PlayerOneScoreText;

            Assert.IsNotNull(playerOneScoreText);
            Assert.AreEqual(System.Drawing.Color.White, playerOneScoreText.ForeColor);
            Assert.AreEqual(new System.Drawing.Font("Folio XBd BT", 14), playerOneScoreText.Font);
            Assert.AreEqual(5, playerOneScoreText.Top);
            Assert.AreEqual(20, playerOneScoreText.Left);
            Assert.AreEqual(20, playerOneScoreText.Height);
            Assert.AreEqual(100, playerOneScoreText.Width);
            Assert.AreEqual("1UP", playerOneScoreText.Text);
        }

        [Test]
        public void CreateFormElements_CreatesHighScoreText()
        {
            Label highScoreText = formElements.HighScoreText;

            Assert.IsNotNull(highScoreText);
            Assert.AreEqual(System.Drawing.Color.White, highScoreText.ForeColor);
            Assert.AreEqual(new System.Drawing.Font("Folio XBd BT", 14), highScoreText.Font);
            Assert.AreEqual(5, highScoreText.Top);
            Assert.AreEqual(155, highScoreText.Left);
            Assert.AreEqual(20, highScoreText.Height);
            Assert.AreEqual(200, highScoreText.Width);
            Assert.AreEqual("HIGH SCORE", highScoreText.Text);
        }
    }
}