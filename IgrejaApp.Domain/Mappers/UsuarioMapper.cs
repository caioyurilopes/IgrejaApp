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

    public static VisualizarMembroResponse ToResponse(this Usuario usuario)
    {
        return new VisualizarMembroResponse
        {
            Id = usuario.Id,
            NomeCompleto = usuario.NomeCompleto,
            Cpf = usuario.Cpf,
            Cep = usuario.Cep,
            Logradouro = usuario.Logradouro,
            Complemento = usuario.Complemento,
            Bairro = usuario.Bairro,
            Uf = usuario.Uf,
            Estado = usuario.Estado,
            Numero = usuario.Numero,
            Telefone = usuario.Telefone,
            DataNascimento = usuario.DataNascimento,
            Naturalidade = usuario.Naturalidade,
            Genero = usuario.Genero,
            EstadoCivil = usuario.EstadoCivil,
            TipoUsuario = usuario.TipoUsuario,
            NomePai = usuario.NomePai,
            NomeMae = usuario.NomeMae,

            ConjugeId = usuario.ConjugeId,
            Conjuge = usuario.Conjuge is not null
                ? new ConjugeResponse
                {
                    Id = usuario.Conjuge.Id,
                    NomeCompleto = usuario.Conjuge.NomeCompleto,
                    Telefone = usuario.Conjuge.Telefone
                }
                : null,

            Batismo = usuario.Batismo is not null
                ? new BatismoResponse
                {
                    Id = usuario.Batismo.Id,
                    Data = usuario.Batismo.Data,
                    Igreja = usuario.Batismo.Igreja,
                    PastorId = usuario.Batismo.PastorId,
                    PastorNomeManual = usuario.Batismo.PastorNomeManual,
                    Pastor = usuario.Batismo.Pastor is not null
                        ? new PastorResponse
                        {
                            Id = usuario.Batismo.Pastor.Id,
                            NomeCompleto = usuario.Batismo.Pastor.NomeCompleto
                        }
                        : null
                }
                : null
        };
    }
}