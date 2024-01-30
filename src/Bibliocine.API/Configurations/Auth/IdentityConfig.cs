namespace Bibliocine.API.Configurations.Auth;

public class IdentityConfig
{
    public string Secret { get; set; }
    public int ExpiracaoHoras { get; set; }
    public string Emissor { get; set; }
    public string ValidoEm { get; set; }
}