namespace Mangatheque.DAL.Entities
{
    public class Client
    {
       
        public int ClientId { get; set; }
        public int NumClient { get; set; } 
        public string Prenom { get; set; }  = string.Empty; // la propriété est initialisée avec une chaine vide par défaut.
        public string Nom { get; set; } = string.Empty;
        public int Tel { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public bool ACarteFidelite { get; set; } = false;
        public bool Active { get; set; } = true;
    }
}