namespace IgrejaApp.Domain.DTOs.Enums;

public enum EstadoCivil
{
    Solteiro = 0,
    Casado = 1,
    Viuvo = 2,
    Divorciado = 3
}

public static class EstadoCivilExtensions
{
    public static string ToDisplay(this EstadoCivil estadoCivil)
    {
        return estadoCivil switch
        {
            EstadoCivil.Solteiro => "Solteiro",
            EstadoCivil.Casado => "Casado",
            EstadoCivil.Viuvo => "Viúvo",
            EstadoCivil.Divorciado => "Divorciado"
        };
    }
}