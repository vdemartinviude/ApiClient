namespace Classlib;

public class AuthenticateResult
{
    public string? token_type {get; set;}
    public int expires_in { get; set; }
    public string? consented_on { get; set; }
    public string? scope { get; set; }
    public string? access_token { get; set; }
    public string? refresh_token { get; set; }

}
