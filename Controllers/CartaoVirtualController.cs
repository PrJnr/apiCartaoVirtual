using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_API_REST.Models;
using Projeto_API_REST.Data;


namespace CartaoVirtualController.Controllers
{
    [ApiController]
    [Route("cartaoVirtual")]
    public class CartaoVirtualController : ControllerBase
    {
        public CartaoVirtualController()
        {
        }

        
        
        

        [HttpGet]
        [Route("{email}")]
        public async Task<ActionResult<List<CartaoVirtual>>> GetByEmail([FromServices] DataContext context, String email)
        {
            var CartoesVirtuais = await context.CartoesVirtuais
            //.Include(x => x.Email)
            .AsNoTracking() 
            .Where(x => x.Email == email)
            .OrderBy(x => x.CreatedDate)
            .ToListAsync();
            return CartoesVirtuais;
        }


        [HttpPost]
        [Route("")]
        public async Task<ActionResult<CartaoVirtual>> Post(
            [FromServices] DataContext context,
            [FromBody]CartaoVirtual model)
        {
            if(ModelState.IsValid)
            {
                DateTime currentDate = DateTime.Now;
                Random randNum = new Random();
                var numCart = Convert.ToString(randNum.Next());

                model.CreatedDate = currentDate;
                model.NumeroCartao = numCart;
                context.CartoesVirtuais.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

           
        
       
    }
}