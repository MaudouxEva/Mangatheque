using Mangatheque.BLL.Interfaces;
using Mangatheque.BLL.CustomExceptions;
using Mangatheque.DTOs;
using Mangatheque.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Mangatheque.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VolumeController : ControllerBase
{
    private readonly IVolumeService _volumeService;
    public VolumeController(IVolumeService volumeService)
    {
        _volumeService = volumeService;
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<VolumeDTO>))]
    public IActionResult GetAll()
    {
        IEnumerable<VolumeDTO> volumes;
        try
        {
            volumes = _volumeService.GetAllVolumes().Select(volumeModel => volumeModel.MapToDTO());
            return Ok(volumes);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
    
    [HttpGet("id/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VolumeDTO))]
    public IActionResult GetById(int id)
    {
        try
        {
            VolumeDTO result = _volumeService.GetVolumeById(id).MapToDTO();
            return Ok(result);
        }
        catch(ArgumentOutOfRangeException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    [HttpGet("isbn/{isbn}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VolumeDTO))]
    public IActionResult GetByIsbn(string isbn)
    {
        try
        {
            VolumeDTO result = _volumeService.GetVolumeByIsbn(isbn).MapToDTO();
            return Ok(result);
        }
        catch(ArgumentOutOfRangeException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    [HttpGet("collection/{collectionId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VolumeDTO))]
    public IActionResult GetByCollectionId(int collectionId)
    {
        try
        {
            var volumes = _volumeService.GetVolumesByCollectionId(collectionId)
                .Select(volume => volume.MapToDTO());
            return Ok(volumes);
        }
        catch(ArgumentOutOfRangeException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(VolumeDTO))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    public IActionResult Insert([FromBody]VolumeInsertFormDTO volume)
    {
        try
        {
            VolumeDTO result = _volumeService.CreateVolume(volume.MapToModel()).MapToDTO();
            return CreatedAtAction(nameof(GetById), new { id = result.VolumeId }, result);
        }
        catch (AlreadyExistsException ex)
        {
            return Conflict(ex.Message);
        }
        catch(Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}