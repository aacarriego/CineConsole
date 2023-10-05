﻿using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public interface IPeliculasQuery
    {
        List<Pelicula> GetListPeliculas();
        Pelicula GetById(int peliculaId);
    }
}
