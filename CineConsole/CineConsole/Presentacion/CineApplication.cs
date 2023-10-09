﻿using Application.Service;
using Domain;
using Infrastructure;
using Infrastructure.Command;
using Infrastructure.Query;


namespace CineConsole.Presentacion
{
    public class CineApplication
    {
        private readonly CineDdContext context;
        private readonly FuncionService funcionesServices;
        private readonly SalasService salasService;
        private readonly PeliculasService peliculasService;
        private readonly GeneroService generoService;


        public CineApplication(CineDdContext context)
        {
            this.context = context;
            var generoQuery = new GeneroQuery(context);
            var funcionesQuery = new FuncionesQuery(context);
            var funcionesCommand = new FuncionesCommand(context);
            var salasQuery = new SalasQuery(context);
            var peliculasQuery = new PeliculaQuery(context);

            funcionesServices = new FuncionService(funcionesQuery, funcionesCommand);
            salasService = new SalasService(salasQuery);
            peliculasService = new PeliculasService(peliculasQuery);
            generoService = new GeneroService(generoQuery);
        }


        public void Run()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("************");
                Console.WriteLine(" Cine GBA");
                Console.WriteLine("************");
                Console.WriteLine(" ");
                Console.WriteLine(" Menú de Opciones ");
                Console.WriteLine(" -----------------");
                Console.WriteLine(" ");
                Console.WriteLine(" 1. Nueva Funcion ");
                Console.WriteLine(" 2. Funciones por pelicula ");
                Console.WriteLine(" 3. Funciones por dia ");
                Console.WriteLine(" 4. Salir ");
                Console.WriteLine(" ");
                Console.WriteLine("******************************");
                Console.Write("Ingrese una opción: ");

                char option = Char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                switch (option)
                {
                    case '1':
                        CreateNewFuncion();
                        break;

                    case '2':
                        SearchFuncionesPorPelicula();
                        break;

                    case '3':
                        ListFuncionesPorDia();
                        break;

                    case '4':
                        return;
                }
            }

        }


        private void CreateNewFuncion()
        {
            // Lógica para crear una nueva función
            // ...
            var nuevaFuncion = new Funcion();

            Console.Write("Fecha (YYYY-MM-DD): ");
            DateTime fecha;
            while (true)
            {
                try
                {
                    if (DateTime.TryParse(Console.ReadLine(), out fecha))
                        break;
                    else
                        throw new Exception("Formato incorrecto. Utilice el formato YYYY-MM-DD.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            nuevaFuncion.Fecha = fecha;

            Console.Write("Horario (HH:mm:ss): ");
            DateTime horario;
            while (true)
            {
                try
                {
                    if (DateTime.TryParse(Console.ReadLine(), out horario))
                        break;
                    else
                        throw new Exception("Horario no válido. Ingrese un horario en el formato HH:mm:ss.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            nuevaFuncion.Horario = horario;

            // Listar peliculas disponibles
            var todaslaspeliculas = peliculasService.GetAllPeliculas();
            Console.WriteLine("Peliculas disponibles:");
            foreach (var pelicula in todaslaspeliculas)
            {
                Console.WriteLine($"ID: {pelicula.PeliculaId}, Título: {pelicula.Titulo}");
            }

            int peliculaId;
            while (true)
            {
                try
                {
                    Console.Write("Seleccione la película (ID): ");
                    if (int.TryParse(Console.ReadLine(), out peliculaId))
                    {
                        if (todaslaspeliculas.Any(p => p.PeliculaId == peliculaId))
                            break;
                        else
                            throw new Exception("ID de película no válido. Seleccione un ID válido.");
                    }
                    else
                    {
                        throw new Exception("ID de película no válido. Ingrese un número.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            nuevaFuncion.PeliculaId = peliculaId;

            // salas disponibles
            List<Sala> salas = salasService.GetAllSalas();
            Console.WriteLine("Salas disponibles:");
            foreach (var sala in salas)
            {
                Console.WriteLine($"ID: {sala.SalaId}, Nombre: {sala.Nombre}");
            }

            int salaId;
            while (true)
            {
                Console.Write("Seleccione la sala (ID): ");
                if (int.TryParse(Console.ReadLine(), out salaId))
                {
                    if (salas.Any(s => s.SalaId == salaId))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("ID de sala no válido. Seleccione un ID válido.");
                    }
                }
                else
                {
                    Console.WriteLine("ID de sala no válido. Ingrese un número.");
                }
            }
            nuevaFuncion.SalaId = salaId;

            // Se muestra un resumen de los campos seleccionados por el operador antes de confirmar el alta
            Console.WriteLine();
            Console.WriteLine("Datos de la nueva función:");
            Console.WriteLine($"Fecha: {nuevaFuncion.Fecha.ToString("yyyy-MM-dd")}, Horario: {nuevaFuncion.Horario.ToString("HH:mm:ss")}");

            string peliculaTitulo = peliculasService.GetPeliculaTituloById(nuevaFuncion.PeliculaId);

            string salaNombre = salasService.GetSalaNombreById(nuevaFuncion.SalaId);

            string generoNombre = generoService.GetGeneroNombreById(nuevaFuncion.PeliculaId);

            Console.WriteLine($"Película: {peliculaTitulo}");
            Console.WriteLine($"Genero: {generoNombre} ");
            Console.WriteLine($"Sala: {salaNombre}");

            funcionesServices.CreateFuncion(nuevaFuncion);
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine("Función registrada.");
            Console.WriteLine("Presione cualquier tecla para volver al menú principal");
            Console.ReadKey();




            
        }


        private void SearchFuncionesPorPelicula()
        {
            // Lógica para buscar funciones por película
            // ...
            Console.WriteLine("Buscador de funciones por película: ");

            // Traer todas las películas disponibles
            var peliculas = peliculasService.GetAllPeliculas();

            if (peliculas.Any())
            {
                Console.WriteLine("Funciones para la pelicula:");
                foreach (var pelicula in peliculas)
                {
                    Console.WriteLine($"ID: {pelicula.PeliculaId}, Título: {pelicula.Titulo}");
                }

                int seleccion;
                while (true)
                {
                    try
                    {
                        Console.Write("Seleccione la película: ");
                        if (int.TryParse(Console.ReadLine(), out seleccion))
                        {
                            if (peliculas.Any(p => p.PeliculaId == seleccion))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("ID invalido.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("ID invalido");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }

                //  Mostrar las funciones para la película seleccionada
                var funcionesPorPelicula = funcionesServices.GetFuncionesPorPelicula(seleccion);

                if (funcionesPorPelicula.Any())
                {

                    Console.WriteLine($"Funciones para la película (ID: {seleccion}):");

                    foreach (var funcion in funcionesPorPelicula)
                    {
                        Console.WriteLine($"Funcion N°: {funcion.FuncionId}, Fecha: {funcion.Fecha.ToString("yyyy-MM-dd")}, Hora: {funcion.Horario.ToString("HH:mm:ss")}");
                        string nombredelasala = salasService.GetSalaNombreById(funcion.SalaId);
                        string nombredelgenero = generoService.GetGeneroNombreById(funcion.PeliculaId);
                        string nombredelapelicula = peliculasService.GetPeliculaTituloById(funcion.PeliculaId);
                        Console.WriteLine($"Sala: {nombredelasala} ");
                        Console.WriteLine($"Película: {nombredelapelicula} ");
                        Console.WriteLine($"Genero: {nombredelgenero}");
                    }
                }
                else
                {
                    Console.WriteLine(" Película seleccionada sin funciones activas.");
                }

                Console.WriteLine("Presione cualquier tecla para volver al menú principal...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("No hay películas disponibles.");
                Console.WriteLine("Presione cualquier tecla para volver al menú principal");
                Console.ReadKey();
            }

            

        }



        private void ListFuncionesPorDia()
        {
            // Lógica para listar funciones por día
            // ...
            Console.WriteLine("Bienvenido al buscador de funciones");
            Console.Write("Ingrese la fecha (YYYY-MM-DD): ");
            string fechaStr = Console.ReadLine();
            DateTime? fechaFiltro = null;

            if (!string.IsNullOrEmpty(fechaStr) && DateTime.TryParse(fechaStr, out DateTime fechaSeleccionada))
            {
                fechaFiltro = fechaSeleccionada;
            }

            if (fechaFiltro.HasValue)
            {
                var funcionesFiltradas = funcionesServices.GetFuncionesPorFecha(fechaFiltro.Value);

                if (funcionesFiltradas.Any())
                {
                    foreach (var funcion in funcionesFiltradas)
                    {
                        Console.WriteLine("--------------------------------------------");
                        Console.WriteLine($"Funcion N°: {funcion.FuncionId}, Fecha: {funcion.Fecha.ToString("yyyy-MM-dd")}, Hora: {funcion.Horario.ToString("HH:mm:ss")}");
                        Console.WriteLine($"Pelicula: {funcion.Peliculas.Titulo}, Sala: {funcion.Salas.Nombre}");
                        string nombredelasala = salasService.GetSalaNombreById(funcion.SalaId);
                        string nombredelgenero = generoService.GetGeneroNombreById(funcion.PeliculaId);
                        string nombredelapelicula = peliculasService.GetPeliculaTituloById(funcion.PeliculaId);
                        Console.WriteLine($"{nombredelasala}, Película: {nombredelapelicula}, Genero: {nombredelgenero}");
                        Console.WriteLine("--------------------------------------------");
                    }
                }
                else
                {
                    Console.WriteLine("Fecha seleccionada sin funciones activas.");
                }

                Console.WriteLine("Presione cualquier tecla para volver al menú principal");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Fecha no válida.");
            }


        }


    }
}   