using Authentication.Entities;
using Authentication.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionThemeController : ControllerBase
    {
        public readonly IMissionTheme _missionTheme;

        public MissionThemeController(IMissionTheme missionTheme)
        {
            _missionTheme = missionTheme;
        }

        [HttpGet]
        [Route("GetMissionThemes")]
        public async Task<IActionResult> GetMissionThemes()
        {
            try
            {
                var themes = await _missionTheme.GetMissionThemes();
                return Ok(themes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("CreateMissionTheme")]
        public async Task<IActionResult> CreateMissionTheme([FromBody] Themess model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _missionTheme.CreateMissionTheme(model);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPut]
        [Route("UpdateMissionTheme/{missionThemeId}")]
        public async Task<IActionResult> UpdateMissionTheme(int missionThemeId, [FromBody] Themess model)
        {
            if (missionThemeId <= 0)
            {
                return BadRequest("Invalid Mission Theme ID");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _missionTheme.UpdateMissionTheme(missionThemeId, model);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetMissionThemeById/{missionThemeId}")]
        public async Task<IActionResult> GetMissionThemeById(int missionThemeId)
        {
            if (missionThemeId <= 0)
            {
                return BadRequest("Invalid Mission Theme ID");
            }

            try
            {
                var theme = await _missionTheme.GetMissionThemeById(missionThemeId);
                if (theme == null)
                {
                    return NotFound();
                }
                return Ok(theme);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpDelete]
        [Route("DeleteMissionTheme/{id}")]
        public async Task<IActionResult> DeleteMissionTheme(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Mission Theme ID");
            }

            try
            {
                var result = await _missionTheme.DeleteMissionTheme(id);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}
