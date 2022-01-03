using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BackendSamtelDomain.Models
{
    public partial class SamtelContext : DbContext
    {
        public SamtelContext()
        {
        }

        public SamtelContext(DbContextOptions<SamtelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Hotel> Hotel { get; set; }
        public virtual DbSet<Reserva> Reserva { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-95OPKV9;Database=Samtel; Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.HasKey(e => e.IdHotel);

                entity.Property(e => e.DireccionHotel)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Estado)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NombreHotel)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Pais)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Reserva>(entity =>
            {
                entity.HasKey(e => e.IdReserva);

                entity.Property(e => e.EstadoReserva)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaEntrada).HasColumnType("datetime");

                entity.Property(e => e.FechaReserva).HasColumnType("datetime");

                entity.Property(e => e.FechaSalida).HasColumnType("datetime");

                entity.HasOne(d => d.IdHotelNavigation)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.IdHotel)
                    .HasConstraintName("FK_Reserva_Hotel");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Reserva)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK_Reserva_Usuario");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario);

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroIdentificacion)
                    .HasMaxLength(35)
                    .IsUnicode(false);

                entity.Property(e => e.TipoIdentificacion)
                    .HasMaxLength(35)
                    .IsUnicode(false);
            });
        }
    }
}
