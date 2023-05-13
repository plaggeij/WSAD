using Assignment1_Plagge_Jake.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1_Plagge_Jake.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StuffController : Controller
    {
        [HttpGet]
        [Route("FavoriteNum/{name}")]
        public int GetFavNum(string name)
        {
            return name.Equals("Jake") ? 25 : 0;
        }

        [HttpPost]
        [Route("FavoriteNum/AddFavNum")]
        public string AddFavNum([FromBody]FavoriteNum favnum)
        {
            Console.Write("Help me");
            return "I want to die";
            //return favnum.Name + "'s favorite number is " + favnum.Num;
        }
    }
    
    
    
}