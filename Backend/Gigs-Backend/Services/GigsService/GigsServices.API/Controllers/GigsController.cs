namespace GigsServices.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GigsController(ICreateGigsService createGigsService) : ControllerBase
    {
        private readonly ICreateGigsService _createGigsService = createGigsService;

        [HttpPost]
        public async Task<IActionResult> CreateGig([FromBody] CreateGigDto gigDto)
        {
            var id = await _createGigsService.CreateAsync(gigDto);
            return Ok(id);
        }
    }
}
