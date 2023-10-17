using NUnit.Framework;
using System.Windows.Forms;

namespace Pacman.Tests
{
    [TestFixture]
    public class HighScoreTests
    {
        private HighScore highScore;

        [SetUp]
        public void SetUp()
        {
            highScore = new HighScore();
        }

        [Test]
        public void CreateHighScoreTest()
        {
            Form form = new Form();
            highScore.CreateHighScore(form);

            Assert.IsNotNull(highScore.HighScoreText);
            Assert.AreEqual(System.Drawing.Color.White, highScore.HighScoreText.ForeColor);
            Assert.AreEqual("Microsoft Sans Serif", highScore.HighScoreText.Font.Name); // Cambiado a Arial
            Assert.AreEqual(14, highScore.HighScoreText.Font.Size);
            Assert.AreEqual(23, highScore.HighScoreText.Top);
            Assert.AreEqual(170, highScore.HighScoreText.Left);
            Assert.AreEqual(20, highScore.HighScoreText.Height);
            Assert.AreEqual(100, highScore.HighScoreText.Width);
            Assert.AreEqual(form, highScore.HighScoreText.Parent);
            Assert.AreEqual(highScore.Score.ToString(), highScore.HighScoreText.Text);
        }

        [Test]
        public void UpdateHighScoreTest()
        {
            int newScore = 150;
            highScore.UpdateHighScore(newScore);

            Assert.AreEqual(newScore, highScore.Score);
            Assert.AreEqual(newScore.ToString(), highScore.HighScoreText.Text);
        }

        [Test]
        public void UpdateHighScoreWithDefaultTest()
        {
            highScore.UpdateHighScore();

            Assert.AreEqual(HighScore.InitalScore, highScore.Score);
            Assert.AreEqual(HighScore.InitalScore.ToString(), highScore.HighScoreText.Text);
        }
    }
}
