using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaWebCF.Models
{
    public class DbContexto: DbContext
    {
        public DbContexto()
        {

        }
        public DbContexto(DbContextOptions<DbContexto > options): base (options)
        {

        }

        //propiedades para exponer el modelo
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }

        //este metodo nos permite mapear nuestras entidades  con la base de datos
        //y le enviamos  como parametro un objeto que instancia de la clase MolderBuilder
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            //creo los objetos
            modelBuilder.Entity<Categoria>(entidad =>
            {
                entidad.ToTable("categoria");
                entidad.HasKey(primaria => primaria.idcategoria);
                entidad.Property(propiedad => propiedad.idcategoria).HasColumnName("idcategoria");
                entidad.Property(propiedad => propiedad.nombre)
                .HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);//quiere decir que se almacenara como varchar y no nvarchar
                entidad.Property(propiedad => propiedad.descripcion)
               .HasColumnName("descripcion")
               .HasMaxLength(255)
               .IsUnicode(false);//quiere decir que se almacenara como varchar y no nvarchar
                entidad.Property(propiedad => propiedad.estado)
             .HasColumnName("estado")
             .HasDefaultValueSql("((1))");
           

            });

            modelBuilder.Entity<Producto>(entidad =>
            {
                entidad.ToTable("producto");
                entidad.HasKey(primaria => primaria.idproducto);
                entidad.Property(propiedad => propiedad.idproducto).HasColumnName("idproducto");
                entidad.Property(propiedad => propiedad.idcategoria).HasColumnName("idcategoria");
                entidad.Property(propiedad => propiedad.codigo)
               .HasColumnName("codigo")
               .HasMaxLength(64)
               .IsUnicode(false);//quiere decir que se almacenara como varchar y no nvarchar

                entidad.Property(propiedad => propiedad.nombre)
                .HasColumnName("nombre")
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);//quiere decir que se almacenara como varchar y no nvarchar

                entidad.HasIndex(indice => indice.nombre)
                .IsUnique();

                entidad.Property(propiedad => propiedad.precio_venta)
                  .HasColumnName("precio_venta")
                  .IsRequired()
                .HasColumnType("decimal(11, 2)");

                entidad.Property(propiedad => propiedad.stock)
                .HasColumnName("stock")
                  .IsRequired();
            

                entidad.Property(propiedad => propiedad.descripcion)
               .HasColumnName("descripcion")
               .HasMaxLength(255)
               .IsUnicode(false);//quiere decir que se almacenara como varchar y no nvarchar

                entidad.Property(propiedad => propiedad.estado)
                .HasColumnName("estado")
                .HasDefaultValueSql("((1))");

                entidad.HasOne(p =>p.categoria)//de la tabla producto
                .WithMany(c =>c.productos) //de la tabla categoria
                .HasForeignKey(f => f.idcategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)//sin eliminacion
                .HasConstraintName("FK_producto_categoria")


            });

        }


    }
}
