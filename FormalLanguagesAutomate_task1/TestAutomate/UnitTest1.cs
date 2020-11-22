using Microsoft.VisualStudio.TestTools.UnitTesting;

using FormalLanguagesAutomate_task1;
namespace TestAutomate
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAutomate1()
        {
            Lexem automate;
            automate = Program.GetLexem();
            Assert.AreEqual("[INT, 33]", automate.Move("33",0).ToString());
        }

        [TestMethod]
        public void TestAutomate2()
        {
            Lexem automate;
            automate = Program.GetLexem();
            Assert.AreEqual("[INT, -1]", automate.Move("-1", 0).ToString());
        }

        [TestMethod]
        public void TestAutomate3()
        {
            Lexem automate;
            automate = Program.GetLexem();
            Assert.AreEqual("[INT, +45]", automate.Move("+45", 0).ToString());
        }
    }
}
