﻿
namespace Core.Tokens.Configuraiton;

public class CustomTokenOptions
{
    public string Issuer { get; set; }
    public List<string> Audience { get; set; }
    public int AccessTokenExpiration { get; set; }

    public string SecurityKey { get; set; }
}
