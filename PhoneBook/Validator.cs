namespace PhoneBook;

internal class Validator
{
    internal static bool IsStringValid(string stringInput)
    {
        foreach (char c in stringInput)
        {
            if (!char.IsLetter(c) && c != '/')
                return false;
        }

        if (string.IsNullOrEmpty(stringInput))
        {
            return false;
        }

        return true;
    }

    internal static bool IsIdValid(string stringInput)
    {
        foreach (char c in stringInput)
        {
            if (!char.IsDigit(c))
                return false;
        }

        if (string.IsNullOrEmpty(stringInput))
        {
            return false;
        }

        return true;
    }

    internal static bool IsPhoneValid(string stringInput)
    {
        foreach (char c in stringInput)
        {
            if (!char.IsDigit(c))
                return false;
        }

        if (string.IsNullOrEmpty(stringInput))
        {
            return false;
        }

        return true;
    }

    internal static bool IsUpdateStringValid(string stringInput)
    {
        foreach (char c in stringInput)
        {
            if ((!char.IsLetter(c) && c != '/' && c != '0') )
                return false;
        }

        if (string.IsNullOrEmpty(stringInput))
        {
            return false;
        }

        return true;
    }
}
