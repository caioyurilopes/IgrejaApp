using System.Text.RegularExpressions;

namespace IgrejaApp.UI.Utils.Formatters;

public static class CepFormatter
{
    public static string AplicarMascara(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        string digits = Regex.Replace(input, @"\D", "");
        if (digits.Length > 8)
            digits = digits[..8];

        return digits.Length switch
        {
            <= 5 => digits,
            <= 8 => $"{digits[..5]}-{digits[5..]}",
            _ => digits
        };
    }

    public static string RemoverMascara(string input)
    {
        return Regex.Replace(input ?? "", @"\D", "");
    }
}