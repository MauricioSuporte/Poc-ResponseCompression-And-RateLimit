namespace Poc_ResponseCompression_And_RateLimit.Domain;

public class DividaDto
{
    private static readonly decimal ValorPrincipalDivida = decimal.Parse((Random.Shared.NextDouble() * 10000).ToString("0.00"));
    private static readonly decimal ValorJurosDivida = decimal.Parse((Random.Shared.NextDouble() * 1000).ToString("0.00"));
    private static readonly decimal ValorTotalDivida = ValorPrincipalDivida + ValorJurosDivida;
    private static readonly short QuantidadeParcela = 12;
    private static readonly decimal ValorParcela = decimal.Parse((ValorTotalDivida / QuantidadeParcela).ToString("0.00"));

    public DividaDto()
    {
        Id = Random.Shared.Next(1, 1000);
        CodigoContrato = Random.Shared.Next(1, 1000).ToString();
        CodigoCredor = Random.Shared.Next(1, 1000);
        Descricao = "ExempleDescricao";
        Status = StatusDivida.AguardandoPagamento;
        DataOrigem = DateTime.Now.AddMonths(-1);
        DataChegada = DateTime.Now;
        DataLimiteNegociacao = DateTime.Now.AddHours(1);
        DataUltimaAtualizacao = DateTime.Now;
        DataLimitePagamento = DateTime.Now.AddDays(1).Date;
        DataValidade = DateTime.Now.AddHours(1);
        ValorPrincipal = ValorPrincipalDivida;
        ValorJuros = ValorJurosDivida;
        ValorTotal = ValorTotalDivida;
        QuantidadeIteracoesDisponiveis = 1;
        Credor = "CredorExemple";
        Api = "ApiExemple";
        Produto = "ProdutoExemple";
        Loja = "LojaExemple";
        Icone = "IconeExemple";
        TipoNegociacao = "TipoNegociacaoExemple";
        Logo = "LogoExemple";
        Detalhe = "DetalheExemple";
        FluxoNegociacao = "FluxoNegociacaoExemple";
        Parcelas = Enumerable.Range(1, QuantidadeParcela).Select(index => new ParcelaDto
        {
            Valor = ValorParcela,
            NumeroParcela = index,
            DataVencimento = DateTime.Now.AddDays(1).AddMonths(index).Date,
            Paga = false,
            Vencida = false,
        })
        .ToList();
        Flags = Enumerable.Range(1, 12)
            .Select(numero => $"Flag {numero}º")
            .ToList();
    }

    public int Id { get; set; }

    public string? CodigoContrato { get; set; }

    public int CodigoCredor { get; set; }

    public string? Descricao { get; set; }

    public StatusDivida Status { get; set; }

    public DateTime DataOrigem { get; set; }

    public DateTime DataChegada { get; set; }

    public DateTime? DataLimiteNegociacao { get; set; }

    public DateTime DataUltimaAtualizacao { get; set; }

    public DateTime? DataLimitePagamento { get; set; }

    public DateTime DataValidade { get; set; }

    public decimal ValorPrincipal { get; set; }

    public decimal ValorJuros { get; set; }

    public decimal ValorTotal { get; set; }

    public int QuantidadeIteracoesDisponiveis { get; set; }

    public string? Credor { get; set; }

    public string? Api { get; set; }

    public string? Produto { get; set; }

    public string? Loja { get; set; }

    public string? Icone { get; set; }

    public string? TipoNegociacao { get; set; }

    public string? Logo { get; set; }

    public object? Detalhe { get; set; }

    public string? FluxoNegociacao { get; set; }

    public List<ParcelaDto>? Parcelas { get; set; }

    public List<string>? Flags { get; set; }
}
