using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace addressbook_web_tests.tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Random rnd = new Random();
            string[] s =
                {"January", "February", "March", "April", "May", "June", "July", "August", 
                "September", "October", "November", "December"};
            for (int i = 0; i < 30; i++) 
            {
                System.Console.WriteLine(s[rnd.Next(s.Length)]) ;

            }
        }
    }
}
