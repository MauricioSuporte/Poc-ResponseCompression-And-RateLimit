namespace Poc_ResponseCompression_And_RateLimit.Domain;

public enum StatusDivida
{
    AguardandoNegociacao = 1,
    EmNegociacao = 2,
    AguardandoPagamento = 3,
    Concluido = 4,
    Bloqueada = 5,
}
