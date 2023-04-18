namespace Poc_ResponseCompression_And_RateLimit.Domain;

public class DividaDto
{
    public int Id { get; set; }

    public string? CodigoContrato { get; set; }

    public int CodigoCredor { get; set; }

    public string? Descricao { get; set; }

    public StatusDivida Status { get; set; }

    public DateTime DataOrigem { get; set; }

    public DateTime DataChegada { get; set; }

    public DateTime? DataLimiteNegociacao { get; set; }

    public DateTime DataUltimaAtualizacao { get; set; }

    public decimal ValorPrincipal { get; set; }

    public DateTime? DataLimitePagamento { get; set; }

    public DateTime DataValidade { get; set; }

    public decimal ValorTotal { get; set; }

    public decimal ValorAcrescimos { get; set; }

    public int QuantidadeIteracoesDisponiveis { get; set; }

    public List<ParcelaDto>? Parcelas { get; set; }

    public List<string>? Flags { get; set; }

    public string? Credor { get; set; }

    public string? Api { get; set; }

    public string? Produto { get; set; }

    public string? Loja { get; set; }

    public string? Icone { get; set; }

    public string? TipoNegociacao { get; set; }

    public string? Logo { get; set; }

    public object? Detalhe { get; set; }

    public string? FluxoNegociacao { get; set; }
}
