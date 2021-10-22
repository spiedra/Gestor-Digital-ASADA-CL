using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gestor_Digital_ASADA_CL_API.Models;

namespace Gestor_Digital_ASADA_CL_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly GestorDigitalASADACLAYDContext _context;

        public RoleController(GestorDigitalASADACLAYDContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/API/Role/GetRoleById/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var role = await _context.Roles
                .FirstOrDefaultAsync(m => m.IdRole == id);
            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        [HttpGet]
        [Route("/API/Role/GetRoleIdByName/{name}")]
        public async Task<IActionResult> Details(string name)
        {
            if (name == null)
            {
                return NotFound();
            }

            var role = await _context.Roles
                .FirstOrDefaultAsync(m => m.TipoRole == name);
            if (role == null)
            {
                return NotFound();
            }

            return Ok(role.IdRole);
        }

        [HttpGet]
        [Route("/API/Role/GetRoles")]
        public async Task<IActionResult> Details()
        {
            return Ok(await _context.Roles.ToListAsync());
        }
    }
}
