using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_Permisos.Models;

namespace WebAPI_Permisos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermisoController : ControllerBase
    {
        private readonly BD_PermisosContext BD_PermisosContext;

        public PermisoController(BD_PermisosContext bD_PermisosContext)
        {
            this.BD_PermisosContext = bD_PermisosContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Permiso>>> Get()
        {
            try
            {
                return await BD_PermisosContext.Permisos.Include(p => p.TipoPermisoNavigation).ToListAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Permiso>> Get(int id)
        {
            try
            {
                var permiso = await BD_PermisosContext.Permisos.Where(p => p.Id == id).Include(p => p.TipoPermisoNavigation).FirstOrDefaultAsync();
                if (permiso == null)
                {
                    return NotFound();
                }
                return Ok(permiso);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="permiso"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Permiso permiso)
        {
            try
            {
                BD_PermisosContext.Permisos.Add(permiso);
                await BD_PermisosContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="permiso"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Permiso permiso)
        {
            try
            {
                BD_PermisosContext.Permisos.Update(permiso);
                await BD_PermisosContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="permiso"></param>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] Permiso permiso)
        {
            try
            {
                BD_PermisosContext.Permisos.Remove(permiso);
                await BD_PermisosContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var permiso = new Permiso()
                {
                    Id = id
                };
                BD_PermisosContext.Entry(permiso).State = EntityState.Deleted;
                await BD_PermisosContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
