using System.ComponentModel.DataAnnotations;

namespace Metrica1.CustomAtributes;

public class PinValidationAttribute : ValidationAttribute
{
    public override bool IsValid(object value)
    {
        if (value == null)
        {
            return false;
        }

        string pin = value.ToString();
        return IsPinValid(pin);
    }

    private bool IsPinValid(string pin)
    {
        if (pin.Length != 7)
        {
            return false;
        }

        bool hasLetter = false;
        bool hasNumber = false;

        foreach (char c in pin)
        {
            if (char.IsLetter(c))
            {
                hasLetter = true;
            }
            else if (char.IsDigit(c))
            {
                hasNumber = true;
            }
        }

        return hasLetter && hasNumber;
    }
}
