namespace IgrejaApp.UI.Utils.Formatters;

public static class CpfCnpjFormatter
{
    public static string AplicarMascara(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        string digits = Regex.Replace(input, @"\D", "");

        if (digits.Length <= 11)
            return AplicarMascaraCpf(digits);
        else
            return AplicarMascaraCnpj(digits);
    }

    private static string AplicarMascaraCpf(string digits)
    {
        if (digits.Length > 11)
            digits = digits[..11];

        return digits.Length switch
        {
            <= 3 => digits,
            <= 6 => $"{digits[..3]}.{digits[3..]}",
            <= 9 => $"{digits[..3]}.{digits[3..6]}.{digits[6..]}",
            _ => $"{digits[..3]}.{digits[3..6]}.{digits[6..9]}-{digits[9..]}"
        };
    }

    private static string AplicarMascaraCnpj(string digits)
    {
        if (digits.Length > 14)
            digits = digits[..14];

        return digits.Length switch
        {
            <= 2 => digits,
            <= 5 => $"{digits[..2]}.{digits[2..]}",
            <= 8 => $"{digits[..2]}.{digits[2..5]}.{digits[5..]}",
            <= 12 => $"{digits[..2]}.{digits[2..5]}.{digits[5..8]}/{digits[8..]}",
            _ => $"{digits[..2]}.{digits[2..5]}.{digits[5..8]}/{digits[8..12]}-{digits[12..14]}"
        };
    }

    public static string RemoverMascara(string input)
    {
        return Regex.Replace(input ?? "", @"\D", "");
    }
}