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
    public class TipoPermisoController : ControllerBase
    {
        private readonly BD_PermisosContext BD_PermisosContext;

        public TipoPermisoController(BD_PermisosContext bD_PermisosContext)
        {
            this.BD_PermisosContext = bD_PermisosContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoPermiso>>> Get()
        {
            try
            {
                return await BD_PermisosContext.TipoPermisos.ToListAsync();
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
        public async Task<ActionResult<TipoPermiso>> Get(int id)
        {
            try
            {
                var permiso = await BD_PermisosContext.TipoPermisos.FirstOrDefaultAsync( p => p.Id == id);
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
    }
}
