namespace Mangatheque.BLL.CustomExceptions
{
    
    public class AlreadyExistsException : Exception
    {
        // On créé une classe qui hérite de la classe Exception pour avoir une exception custom. On fournira un message au moment de son instanciation 
        public AlreadyExistsException(string message) : base (message)
        { 

        }

        public AlreadyExistsException()
        {

        }
    }
}

