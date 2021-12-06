using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    internal class Validator
    {
        internal static bool IsStringValid(string stringInput)
        {
            foreach (char c in stringInput)
            {
                if (!Char.IsLetter(c) && c != '/')
                    return false;
            }

            if (String.IsNullOrEmpty(stringInput))
            {
                return false;
            }

            return true;
        }

        internal static bool IsIdValid(string stringInput)
        {
            foreach (char c in stringInput)
            {
                if (!Char.IsDigit(c))
                    return false;
            }

            if (String.IsNullOrEmpty(stringInput))
            {
                return false;
            }

            return true;
        }

        internal static bool IsPhoneValid(string stringInput)
        {
            foreach (char c in stringInput)
            {
                if (!Char.IsDigit(c))
                    return false;
            }

            if (String.IsNullOrEmpty(stringInput))
            {
                return false;
            }

            return true;
        }
    }
}
