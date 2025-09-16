namespace IgrejaApp.UI.Utils.Formatters;

public static class CelularFormatter
{
    public static string AplicarMascara(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        string digits = Regex.Replace(input, @"\D", "");
        if (digits.Length > 11)
            digits = digits[..11];

        return digits.Length switch
        {
            <= 2 => $"({digits}",
            3 => $"({digits[..2]}) {digits[2]}",
            <= 6 => $"({digits[..2]}) {digits[2]} {digits[3..]}",
            <= 10 => $"({digits[..2]}) {digits[2]} {digits[3..7]}-{digits[7..]}",
            _ => $"({digits[..2]}) {digits[2]} {digits[3..7]}-{digits[7..11]}"
        };
    }

    public static string RemoverMascara(string input)
    {
        return Regex.Replace(input ?? "", @"\D", "");
    }
}