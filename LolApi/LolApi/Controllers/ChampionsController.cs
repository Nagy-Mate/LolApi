using LolApi.Core;
using Microsoft.AspNetCore.Mvc;

namespace LolApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ChampionsController(LolDbContext db) : ControllerBase
{
    [HttpGet]
    public ActionResult GetChampions()
    {
        return Ok(db.Champions);
    }

    [HttpGet("{id}")]
    public ActionResult GetChampion(int id)
    {
        var res = db.Champions.FirstOrDefault(x => x.Id == id);
        if (res == null) return NotFound();

        return Ok(res);
    }

    [HttpPost]
    public ActionResult CreateChampion([FromBody] ChampionDto championDto )
    {
        if (championDto.Difficulty > 10 || championDto.Difficulty < 1 || championDto.BlueEssence < 0 || championDto.BlueEssence > 99999)
            return BadRequest();
        try
        {
            db.Champions.Add(new Champion
            {
                BlueEssence = championDto.BlueEssence,
                DamageType = championDto.DamageType,
                Description = championDto.Description,
                Images = championDto.Images,
                Lane = championDto.Lane,
                Name = championDto.Name,
                Role = championDto.Role,
                Difficulty = championDto.Difficulty,
            });
            db.SaveChanges();
            return Created();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteChampion(int id)
    {
        var res = db.Champions.FirstOrDefault(x => x.Id == id);
        if (res == null) return NotFound();

        try
        {
            db.Champions.Remove(res);
            db.SaveChanges();
            return NoContent();
        }
        catch
        {
            return BadRequest();
        }
        
    }
}
