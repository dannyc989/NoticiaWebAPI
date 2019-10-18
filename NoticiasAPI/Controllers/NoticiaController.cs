﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoticiasAPI.Services;

namespace NoticiasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiaController : ControllerBase
    {
        private readonly NoticiaService _noticiaService;
        public NoticiaController(NoticiaService noticiaService)
        {
            this._noticiaService = noticiaService;
        }

        [HttpGet]
        [Route("obtener")]
        public IActionResult Obtener()
        {
            var resultado = this._noticiaService.Obtener();
            return Ok(resultado);
        }

        [HttpPost]
        [Route("agregar")]
        public IActionResult Agregar([FromBody] _LL
    }
}