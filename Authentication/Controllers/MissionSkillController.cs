using Authentication.Entities;
using Authentication.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionSkillController : ControllerBase
    {
        public readonly IMissionSkill _missionSkill;

        public MissionSkillController(IMissionSkill missionSkill)
        {
            _missionSkill = missionSkill;
        }

        [HttpGet]
        [Route("GetMissionSkills")]
        public async Task<IActionResult> GetMissionSkill()
        {
            try
            {
                var themes = await _missionSkill.GetMissionSkill();
                return Ok(themes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPost]
        [Route("CreateMissionSkill")]
        public async Task<IActionResult> CreateMissionSkill([FromBody] Skill model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _missionSkill.CreateMissionSkill(model);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpPut]
        [Route("UpdateMissionSkill/{SkillId}")]
        public async Task<IActionResult> UpdateMissionSkill(int SkillId, [FromBody] Skill model)
        {
            if (SkillId <= 0)
            {
                return BadRequest("Invalid Mission skill ID");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _missionSkill.UpdateMissionSkill(SkillId, model);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        [HttpGet]
        [Route("GetMissionSkillById/{SkillId}")]
        public async Task<IActionResult> GetMissionSkillById(int SkillId)
        {
            if (SkillId <= 0)
            {
                return BadRequest("Invalid Mission skill ID");
            }

            try
            {
                var theme = await _missionSkill.GetMissionSkillById(SkillId);
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
        [Route("DeleteMissionSkill/{id}")]
        public async Task<IActionResult> DeleteMissionSkill(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Mission skill ID");
            }

            try
            {
                var result = await _missionSkill.DeleteMissionSkill(id);
                return Ok(new { message = result });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }
    }
}
