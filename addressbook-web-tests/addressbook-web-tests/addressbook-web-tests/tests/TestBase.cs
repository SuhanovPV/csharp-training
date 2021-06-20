using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class TestBase
    {
        protected ApplicationManager app;

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstance();
        }

        public static Random rnd = new Random();
        public static string GenerateRandomString(int max)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++) 
            {
                builder.Append(Convert.ToChar(Convert.ToInt32(rnd.NextDouble() * 65 + 32)));
            }
            return builder.ToString();
        }

        public static string GenerateRandomPhone() 
        {
            char[] letters = "0123456789 -()+".ToCharArray();
            string phone = "";
            for (int i = 0; i < 10; i++) 
            {
                int letter_num = rnd.Next(letters.Length-1);
                phone += letters[letter_num];
            }
            return phone;
        }
        public static string GenerateRandomDay()
        {
            int day = rnd.Next(32);
            if (day == 0) 
            {
                return "";
            }
            return day.ToString();
        }

        public static string GenerateRandomMonth()
        {
            string[] s = {"January", "February", "March", "April", "May", "June", "July", "August",
                "September", "October", "November", "December"};
            return s[rnd.Next(s.Length)];
        }

        public static string GenerateRandomYear()
        {
            int year = rnd.Next(1900,3000);
            return year.ToString();
        }
    }
}
