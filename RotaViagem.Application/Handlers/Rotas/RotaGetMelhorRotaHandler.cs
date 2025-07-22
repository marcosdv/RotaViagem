using RotaViagem.Application.Commands;
using RotaViagem.Application.Commands.Results;
using RotaViagem.Application.Queries.Response;
using RotaViagem.Application.Queries.Results;
using RotaViagem.Application.Queries.Rotas;
using RotaViagem.Domain.Entities;
using RotaViagem.Domain.Repositories;

namespace RotaViagem.Application.Handlers.Rotas;

public class RotaGetMelhorRotaHandler : IQueryHandler<RotaGetMelhorRotaQuery>
{
    private readonly IRotaRepository _rotaRepository;

    public RotaGetMelhorRotaHandler(IRotaRepository rotaRepository)
    {
        _rotaRepository = rotaRepository;
    }

    public async Task<ICommandResult> Execute(RotaGetMelhorRotaQuery query)
    {
        query.Validar();
        if (query.ExisteErro)
        {
            return new CommandResult(false, "Dados de busca incorretos", query.Erros);
        }

        var rotas = await _rotaRepository.GetAllAsync();

        var melhorRota = GetMelhorRota(query, rotas.ToList());

        return new QueriesResult(true, melhorRota);
    }

    private MelhorRotaResponse? GetMelhorRota(RotaGetMelhorRotaQuery query, List<Rota> listaRotas)
    {
        var origem = query.Origem;
        var destino = query.Destino;

        var grafo = new Dictionary<string, List<Rota>>();
        var nodes = new HashSet<string>();

        foreach (var rota in listaRotas)
        {
            if (!grafo.ContainsKey(rota.Origem))
            {
                grafo[rota.Origem] = [];
            }

            grafo[rota.Origem].Add(rota);

            nodes.Add(rota.Origem);
            nodes.Add(rota.Destino);
        }

        var dist = new Dictionary<string, double>();
        var prev = new Dictionary<string, string?>();
        foreach (var node in nodes)
        {
            dist[node] = double.MaxValue;
            prev[node] = null;
        }
        dist[origem] = 0;

        var heap = new PriorityQueue<string, double>();
        foreach (var node in nodes)
        {
            heap.Enqueue(node, dist[node]);
        }

        var visitados = new HashSet<string>();

        while (heap.Count > 0)
        {
            var u = heap.Dequeue();
            if (visitados.Contains(u))
            {
                continue;
            }

            visitados.Add(u);

            if (u == destino)
            {
                break;
            }

            if (!grafo.ContainsKey(u))
            {
                continue;
            }

            foreach (var rota in grafo[u])
            {
                var alt = dist[u] + rota.Preco;
                if (alt < dist[rota.Destino])
                {
                    dist[rota.Destino] = alt;
                    prev[rota.Destino] = u;
                    heap.Enqueue(rota.Destino, alt);
                }
            }
        }

        if (dist[destino] == double.MaxValue)
        {
            return new MelhorRotaResponse
            {
                Resposta = $"Rota indisponível.",
            };
        }

        var caminho = new List<string>();
        string? atual = destino;
        while (atual != null)
        {
            caminho.Insert(0, atual);
            atual = prev[atual];
        }

        var rotaSugerida = string.Join(" - ", caminho);
        var precoTotal = dist[destino];
        return new MelhorRotaResponse
        {
            Resposta = $"{rotaSugerida} ao custo de ${precoTotal}.",
            Rota = rotaSugerida,
            PrecoTotal = precoTotal
        };
    }
}