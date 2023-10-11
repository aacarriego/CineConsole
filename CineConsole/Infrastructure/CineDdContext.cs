using Domain;
using Microsoft.EntityFrameworkCore;



namespace Infrastructure
{
    public class CineDdContext : DbContext
    {

        // Set de tablas (entidades)
        public DbSet<Sala> Salas { get; set; }

        public DbSet<Pelicula> Peliculas { get; set; }

        public DbSet<Genero> Generos { get; set; }

        public DbSet<Ticket> Tickets { get; set; }

        public DbSet<Funcion> Funciones { get; set; }


        //Configuracion relaciones y FK
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genero>(entity =>
            {
                entity.HasKey(p => p.GeneroId);

                entity.Property(p => p.Nombre).HasMaxLength(50).IsRequired();

                entity.ToTable("Generos");
            });

            modelBuilder.Entity<Pelicula>(entity =>
            {
                entity.HasKey(p => p.PeliculaId);

                entity.Property(p => p.Titulo).HasMaxLength(50).IsRequired();
                entity.Property(p => p.Sinopsis).HasMaxLength(255).IsRequired();
                entity.Property(p => p.Poster).HasMaxLength(100).IsRequired();
                entity.Property(p => p.Trailer).HasMaxLength(100).IsRequired();
                entity.Property(p => p.Genero).IsRequired();
                entity.HasOne(p => p.genero).WithMany(g => g.Peliculas).HasForeignKey(p => p.Genero);

                entity.ToTable("Peliculas");

            });

            modelBuilder.Entity<Funcion>(entity =>
            {
                entity.HasKey(f => f.FuncionId);

                entity.Property(f => f.PeliculaId).IsRequired();
                entity.Property(f => f.SalaId).IsRequired();
                entity.Property(f => f.Fecha).IsRequired();
                entity.Property(f => f.Horario).IsRequired();

                entity.HasOne(p => p.Peliculas).WithMany(f => f.Funciones).HasForeignKey(p => p.PeliculaId);
                entity.HasOne(s => s.Salas).WithMany(f => f.Funciones).HasForeignKey(p => p.SalaId);

                entity.ToTable("Funciones");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.HasKey(t => t.TicketId);
                entity.Property(t => t.FuncionId).IsRequired();
                entity.Property(t => t.Usuario).HasMaxLength(50).IsRequired();

                entity.HasOne(t => t.Funciones).WithMany(f => f.Tickets).HasForeignKey(t => t.FuncionId);
                entity.ToTable("Tickets");
            });

            modelBuilder.Entity<Sala>(entity =>
            {
                entity.HasKey(s => s.SalaId);

                entity.Property(s => s.Capacidad).IsRequired();
                entity.Property(s => s.Nombre).HasMaxLength(50).IsRequired();

                entity.ToTable("Salas");
            });
            //// UNA PELICULA ASOCIADA A MUCHAS FUNCIONES + FK
            //modelBuilder.Entity<Funcion>()
            //    .HasOne(fun => fun.Peliculas)
            //    .WithMany(pel => pel.Funciones)
            //    .HasForeignKey(fun => fun.PeliculaId);

            //// UN GENERO ASOCIADO A MUCHAS PELICULAS + FK
            //modelBuilder.Entity<Genero>()
            //  .HasMany(gen => gen.Peliculas)
            //  .WithOne(pel => pel.genero)
            //  .HasForeignKey(p => p.GeneroId);

            ////// UNA SALA TIENE MUCHAS FUNCIONES + FK
            //modelBuilder.Entity<Sala>()
            //    .HasMany(s => s.Funciones)
            //    .WithOne(f => f.Salas)
            //    .HasForeignKey(f => f.SalaId);

            //// UNA FUNCION TIENE MUCHOS TICKETS + FK
            //modelBuilder.Entity<Ticket>()
            //    .HasOne(t => t.funcion)
            //    .WithMany(f => f.Tickets)
            //    .HasForeignKey(t => t.FuncionId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-N8FS7SBV;Database=CineDataBase;Trusted_Connection=True;TrustServerCertificate=True");
        }

    }
}
