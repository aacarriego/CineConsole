﻿using Application.Interface;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public class SalasService
    {
        private readonly ISalasQuery _salasQuery;

        public SalasService(ISalasQuery salasQuery)
        {
            _salasQuery = salasQuery;
        }

        public List<Sala> GetAllSalas()
        {
            return _context.Salas.ToList();
        }

        public string GetSalaNombreById(int salaId)
        {

            var sala = _context.Salas.FirstOrDefault(s => s.SalaId == salaId);

            if (sala != null)
            {
                return sala.Nombre;
            }
            else
            {
                // Manejar el caso en el que el ID de la sala no existe
                return "Sala no encontrada";
            }
        }
    }
}
