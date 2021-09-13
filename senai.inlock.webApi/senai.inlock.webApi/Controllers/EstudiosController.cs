﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }
    
        public EstudiosController()
        {
            _estudioRepository = new EstudioRepository();
        }

        //GET
        [Authorize(Roles = "1")]
        [HttpGet]
        public IActionResult ListarEstudios()
        {
            List<EstudioDomain> listaEstudios = _estudioRepository.ListarEstudios();

            return Ok(listaEstudios);
        }
    }

    
}
