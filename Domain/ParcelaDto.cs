namespace Poc_ResponseCompression_And_RateLimit.Domain
{
    public class ParcelaDto
    {
        public int NumeroParcela { get; set; }

        public decimal? Valor { get; set; }

        public DateTime DataVencimento { get; set; }

        public bool Vencida { get; set; }

        public bool Paga { get; set; }
    }
}