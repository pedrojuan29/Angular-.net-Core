﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProEventos.API.Models;
using ProEventos.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProEventos.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventosController : ControllerBase
    {
        private readonly DataContext _context;
       
        public EventosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _context.Eventos;
        }


        [HttpGet("{id}")]
        public IEnumerable<Evento> GetByid(int id)
        {
            return _context.Eventos.Where(x => x.EventoId == id);
        }

        [HttpPost]
        public string Post()
        {
            return "Exemplo post";
        }

        [HttpPut("{id}")]
        public string Put(int id)
        {
            return $"Exemplo put {id}";
        }
    }
}
