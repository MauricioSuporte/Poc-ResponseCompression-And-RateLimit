using Poc_ResponseCompression_And_RateLimit.Domain;
using Poc_ResponseCompression_And_RateLimit.Interfaces;

namespace Poc_ResponseCompression_And_RateLimit.Services;

public class DividaService : IDividaService
{
    public DividaDto GetDividaDto() => new();
}
