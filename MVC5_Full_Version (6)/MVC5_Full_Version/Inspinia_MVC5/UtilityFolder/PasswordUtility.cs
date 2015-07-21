using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inspinia_MVC5.UtilityFolder
{
    public class PasswordUtility
    {
        public static string GenRandPassword(int n)
        {
            // # $ % : ; ? @
            int number;
            char code;
            string password = String.Empty;

            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                number = random.Next(74) + 48;
                while ((number > 90 && number < 97) || (number > 57 && number < 65))
                    number = random.Next(74) + 48;

                code = (char)number;

                password += code.ToString();
            }

            return password;
        }
    }
}