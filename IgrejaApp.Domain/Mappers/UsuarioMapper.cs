using IgrejaApp.Domain.DTOs.Requests.Secretaria.Membros;
using IgrejaApp.Domain.Entities;

namespace IgrejaApp.Domain.Mappers;

public static class UsuarioMapper
{
    public static Usuario ToEntity(this CadastrarMembroRequest request)
    {
        return new Usuario
        {
            NomeCompleto = request.NomeCompleto,
            Cpf = request.Cpf,
            Cep = request.Cep,
            Logradouro = request.Logradouro,
            Complemento = request.Complemento,
            Bairro = request.Bairro,
            Uf = request.Uf,
            Estado = request.Estado,
            Numero = request.Numero,
            Telefone = request.Telefone,
            DataNascimento = request.DataNascimento,
            Naturalidade = request.Naturalidade,
            Genero = request.Genero,
            EstadoCivil = request.EstadoCivil,
            TipoUsuario = request.TipoUsuario,
            ConjugeId = request.ConjugeId,
            NomeConjuge = request.NomeConjuge,
            DataCasamento = request.DataCasamento,
            NomePai = request.NomePai,
            NomeMae = request.NomeMae,
            Celular = request.Celular,
            Senha = request.Senha,
            DataAdmissao = request.DataAdmissao,
            MeioAdmissao = request.MeioAdmissao,
            Batismo = request.DataBatismo.HasValue || !string.IsNullOrEmpty(request.IgrejaBatismo)
                ? new Batismo
                {
                    Data = request.DataBatismo ?? default,
                    Igreja = request.IgrejaBatismo ?? string.Empty,
                    PastorId = request.PastorBatismoId,
                    PastorNomeManual = request.PastorBatismoNomeManual
                }
                : null
        };
    }
}