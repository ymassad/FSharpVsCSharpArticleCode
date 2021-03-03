using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    public enum Language { CSharp, FSharp, FunctionalCSharp }

    [TestClass]
    public class Tests
    {
        [DataTestMethod]
        [DataRow("", "", Language.CSharp)]
        [DataRow("", "", Language.FSharp)]
        [DataRow("", "", Language.FunctionalCSharp)]
        [DataRow("1", "11", Language.CSharp)]
        [DataRow("1", "11", Language.FSharp)]
        [DataRow("1", "11", Language.FunctionalCSharp)]
        [DataRow("33", "23", Language.CSharp)]
        [DataRow("33", "23", Language.FSharp)]
        [DataRow("33", "23", Language.FunctionalCSharp)]
        [DataRow("11112222", "4142", Language.CSharp)]
        [DataRow("11112222", "4142", Language.FSharp)]
        [DataRow("11112222", "4142", Language.FunctionalCSharp)]
        [DataRow("1112334", "31122314", Language.CSharp)]
        [DataRow("1112334", "31122314", Language.FSharp)]
        [DataRow("1112334", "31122314", Language.FunctionalCSharp)]
        public void Test(string input, string expectedOutput, Language language)
        {
            var output = language switch
            {
                Language.CSharp => LookAndSayCSharp.Module1.LookAndSay(input),
                Language.FSharp => LookAndSayFSharp.Module1.lookAndSay(input),
                Language.FunctionalCSharp => LookAndSayFunctionalCSharp.Module1.LookAndSay(input),
            };
            
            Assert.AreEqual(expectedOutput, output);
        }
    }
}