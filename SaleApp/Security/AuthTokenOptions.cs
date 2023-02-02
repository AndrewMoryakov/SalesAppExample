namespace SaleAppExample.Security;

public class AuthTokenOptions
{
    public string Audience { get; set; }
    public string Issuer { get; set; }
    public string Secret { get; set; }
    public int Lifetime { get; set; }
}