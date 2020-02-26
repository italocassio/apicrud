using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Models;
using Store.Data;

namespace Shop.Controllers
{
    [ApiController]
    [Route("v1/usuarios")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> Get(
            [FromServices]StoreDataContext context
        )
        {
            var Usuarios = await context.Usuarios.AsNoTracking().ToListAsync();
            return Ok(Usuarios);
        }

        [HttpPost]
        public async Task<ActionResult> Post(
            [FromServices]StoreDataContext context,
            [FromBody]Usuario Usuario
        )
        {
            await context.Usuarios.AddAsync(Usuario);
            await context.SaveChangesAsync();
            return Created("", Usuario);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult> Put(
            [FromServices]StoreDataContext context,
            [FromBody]Usuario Usuario,
            int id
        )
        {
            var item = await context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
                return NotFound();

            context.Entry<Usuario>(Usuario).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return Ok(item);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> Delete(
            [FromServices]StoreDataContext context,
            int id
        )
        {
            var item = await context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
                return NotFound();

            context.Usuarios.Remove(item);
            await context.SaveChangesAsync();

            return Ok(item);
        }
    }
}
