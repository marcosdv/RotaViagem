using RotaViagem.Application.Queries.Rotas;

namespace RotaViagem.Tests.Application.Queries.Rotas;

[TestClass]
public class RotaGetMelhorRotaQueryTests
{
    [TestMethod]
    public void DadoUmaQueryValidoDeveRetornarSemErro()
    {
        var query = new RotaGetMelhorRotaQuery
        {
            Origem = "Origem",
            Destino = "Destino"
        };

        query.Validar();

        Assert.IsTrue(query.SemErro);
    }

    [TestMethod]
    public void DadoUmaQuerySemOrigemDeveRetornarExisteErro()
    {
        var query = new RotaGetMelhorRotaQuery
        {
            Destino = "Destino"
        };

        query.Validar();

        Assert.IsTrue(query.ExisteErro);
        Assert.IsTrue(query.Erros.Any());
    }

    [TestMethod]
    public void DadoUmaQuerySemDestinoDeveRetornarExisteErro()
    {
        var query = new RotaGetMelhorRotaQuery
        {
            Origem = "Origem"
        };

        query.Validar();

        Assert.IsTrue(query.ExisteErro);
        Assert.IsTrue(query.Erros.Any());
    }
}