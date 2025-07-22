using RotaViagem.Application.Queries.Rotas;

namespace RotaViagem.Tests.Application.Queries.Rotas;

[TestClass]
public class RotaGetByIdQueryTests
{
    [TestMethod]
    public void DadoUmaQueryValidoDeveRetornarSemErro()
    {
        var query = new RotaGetByIdQuery
        {
            Id = Guid.NewGuid()
        };

        query.Validar();

        Assert.IsTrue(query.SemErro);
    }

    [TestMethod]
    public void DadoUmaQuerySemIdDeveRetornarExisteErro()
    {
        var query = new RotaGetByIdQuery();

        query.Validar();

        Assert.IsTrue(query.ExisteErro);
        Assert.IsTrue(query.Erros.Any());
    }
}