using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ServerGame.Models;
using ServerGame.Services;

namespace ServerGame.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameResultController : ControllerBase
    {

        private GameService service;

        public GameResultController()
        {
            service = new GameService();
        }

            
        [HttpPost]
        public ActionResult RegisterGameResult(GameResultModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return StatusCode(400, "The result is not valid");

                service.Save(model);
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Error to save game result");
            }
            
        }

    }
}
