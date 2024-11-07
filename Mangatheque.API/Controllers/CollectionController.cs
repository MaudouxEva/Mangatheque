using Mangatheque.BLL.CustomExceptions;
using Mangatheque.BLL.Interfaces;
using Mangatheque.DTOs;
using Mangatheque.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mangatheque.Controllers;

// Définit le modèle de routage pour le contrôleur; [controller] = est un espace réservé qui sera remplacé par le nom du controlleur. Ici ca sera du coup api/collection
[Route("api/[controller]")]
// Indique que c'est un contrôleur d'API; active plusieurs comportements spécifiques aux API comme valisation automatique des modèles et réponses automatiques en cas d'erreur
[ApiController]
public class CollectionController : ControllerBase
{
    
    private readonly ICollectionService _collectionService;
    public CollectionController(ICollectionService collectionService)
    {
        _collectionService = collectionService;
    }
    
    // Récupère toutes les collections
    
    // Indique que cette méthode répond à une requête HTTP GET : cete méthode sera appelée quand le client enverra une requête GET à l'URL api/collection
    [HttpGet]
    // Cette méthode peut retourner un code de statut 200 (OK) et le type de retour sera un IEnumerable de CollectionDTO
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CollectionDTO>))]
    // Retourne un IActionResult => représente le résultat d'une action de contrôleur
    public IActionResult GetAll()
    {
        // collections contiendra la liste des collections après leur récupération et transformation en CollectionDTO
        IEnumerable<CollectionDTO> collections;
        try
        {
            // Appel de la méthode du service pour récupérer les informations BLL
            // LINQ pour transformer chaque modèle de collection récupéré en objet CollectionDTO avec la méthode MapToDTO
            collections = _collectionService.GetAllCollections().Select(collectionModel => collectionModel.MapToDTO());
            // retourne une réponse 200 avec la liste des collections sous forme de CollectionDTO
            return Ok(collections);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    
    // Récupère une collection par son id
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CollectionDTO))]
    public IActionResult GetById(int id)
    {
        try
        {

            CollectionDTO result = _collectionService.GetCollectionById(id).MapToDTO();
            return Ok(result);
        }
        catch(ArgumentOutOfRangeException ex)
        {
            return NotFound("La collection n'a pas été trouvée");
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    
   //La méthode répond aux requêtes HTTP POST : appelée quand le client enverra une requête POST à l'URL api/collection
   [HttpPost]
   //La méthode peut retourner un code de status HTTP 2001 et que le type de retour sera un CollectionDTO (nouvelle ressource créée avec succès)
   [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(CollectionDTO))]
   // Status 409 si la collection existe déjà et retourne une chaine de caractères
   [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
   // Status 403 si l'utilisateur n'a pas les droits pour créer une collection
   [ProducesResponseType(StatusCodes.Status403Forbidden)]
   
   // FromBody indique que la valeur d'un paramètre d'action doit être liée à partir du corps de la requete HTTP. Quand le client envoie une requête POST, les données JSON dans le corps de la requete seront désérialisées en un objet CollectionInsertFormDTO
   public IActionResult Insert([FromBody]CollectionInsertFormDTO collection)
    {
        try
        {
            // conversion de l'objet DTO en modèle BLL, puis retourne un modèle BLL qui est reconverti en objet DTO.
            CollectionDTO result = _collectionService.CreateCollection(collection.MapToModel()).MapToDTO();
            // nameof permet de récupérer le nom de la méthode GetById sans le hardcoder
            // permet de créer un objet anonyme avec une propriété id qui contient l'id de la collection créée
            return CreatedAtAction(nameof(GetById), new { id = result.CollectionId }, result);
        }
        catch (AlreadyExistsException ex)
        {
            return Conflict(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}