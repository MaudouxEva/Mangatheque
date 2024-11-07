using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Mangatheque.BLL.Interfaces;
using Mangatheque.BLL.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Mangatheque.BLL.Services;

public class AuthService : IAuthService
{
    
    // Configruation via l'injection de dépendances
    private readonly IConfiguration _config;

    public AuthService(IConfiguration config)
    {
        _config = config;
    }

    
    // Le package installé permet de créer des jetons JWT sécurisés en utilisant des clés de sécurité et des algorithmes de signature
    public string GenerateToken(Client client)
    {
        // Création des revendications (claims) pour le client
        // Claims = déclarations sur une entité (un user) incluses dans un jeton de sécurité (JWT - JSON Web Token) => utilisées pour transmettre des infos de manière sécurisée
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, client.ClientId.ToString()), // identifiant unique du client
            new Claim(ClaimTypes.Name, client.Nom), // nom du client
            new Claim(ClaimTypes.Email, client.Email), // email du client
            new Claim(ClaimTypes.Role, "Client"), // rôle du client
            new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddDays(1).ToString("o")), // date d'expiration du jeton
        };
        
        // Génération d'un jeton JWT sécurité via une clé secrète et des infos d'identification puis renvoie le jeton sous forme de chaine de caractères. Jeton utilisé pour être utilisé pour autentifier les users dans une app
        // Création de la clé de sécurité symétrique en utilisant une clé secrète définie dans la configuration (_config["Jwt:Key"]), encodée en UTF8
        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        // Création des informations d'identifcication de signature en utilisant la clé de sécurité symétrique et l'algorithme de hachage HMACSHA256
        SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        // Création d'un jeton JWT en utilisant les informations : émetteur (Jwt:Issuer), revendications contenant les infos de l'utilisateur, la date d'expiration du jeton et les infos d'identifications de signature pour signer le jeton
        JwtSecurityToken token = new JwtSecurityToken(
            _config["Jwt:Issuer"],
            _config["Jwt:Issuer"],
            claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: creds
        );
        // Gestionnaire de jetons JWT pour écrire (sérialiser) le jeton en une chaine de caractères et le renvoie
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    public string GenerateToken(Vendeur vendeur)
    {
        List<Claim> claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, vendeur.VendeurId.ToString()),
            new Claim(ClaimTypes.Name, vendeur.Nom),
            new Claim(ClaimTypes.Email, vendeur.Email),
            new Claim(ClaimTypes.Role, "Vendeur"),
            new Claim(ClaimTypes.Expiration, DateTime.UtcNow.AddDays(1).ToString("o")),
        };
        
        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        JwtSecurityToken token = new JwtSecurityToken(
            _config["Jwt:Issuer"],
            _config["Jwt:Issuer"],
            claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: creds
        );
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}