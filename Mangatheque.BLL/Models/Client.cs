namespace Mangatheque.BLL.Models;

public class Client
{
    public int ClientId { get; set; }
    public int NumClient { get; set; }
    public string Nom { get; set; } = string.Empty;
    public string Prenom { get; set; } = string.Empty;
    public int Tel { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool ACarteFidelite { get; set; }
    public bool Active { get; set; }
}