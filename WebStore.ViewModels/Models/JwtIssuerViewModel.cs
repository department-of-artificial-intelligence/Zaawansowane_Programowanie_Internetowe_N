namespace WebStore.ViewModels.Models;

public class JwtOptionsViewModel
{
    public string Issuer { get; set; } = default!;
    public string Audience { get; set; } = default!;
    public string SecretKey { get; set; }= default!;
    public int TokenExpirationMinutes { get; set; }
}