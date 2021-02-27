using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    public enum Language { CSharp, FSharp }

    [TestClass]
    public class Tests
    {
        [DataTestMethod]
        [DataRow("1", "11", Language.CSharp)]
        [DataRow("1", "11", Language.FSharp)]
        [DataRow("33", "23", Language.CSharp)]
        [DataRow("33", "23", Language.FSharp)]
        [DataRow("11112222", "4142", Language.CSharp)]
        [DataRow("11112222", "4142", Language.FSharp)]
        [DataRow("1112334", "31122314", Language.CSharp)]
        [DataRow("1112334", "31122314", Language.FSharp)]
        public void Test(string input, string expectedOutput, Language language)
        {
            var output = language == Language.CSharp
                ? LookAndSayCSharp.Module1.LookAndSay(input)
                : LookAndSayFSharp.Module1.lookAndSay(input);
            
            Assert.AreEqual(expectedOutput, output);
        }
    }
}