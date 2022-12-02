using Microsoft.EntityFrameworkCore;
using proyectoEF.Models;

namespace   proyectoEF.Contexto;

public class TareasContext:DbContext
{

    
    public DbSet<Categoria> Categorias { get; set; }

    public DbSet<Tarea> Tareas { get; set; }

    public TareasContext(DbContextOptions<TareasContext> options) :base(options) { }

    protected override void  OnModelCreating(ModelBuilder modelBuilder){

        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add(new Categoria() { CategoriaID = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), Nombre = "Actividades pendientesEdit", Peso = 20});
        categoriasInit.Add(new Categoria() { CategoriaID = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb402"), Nombre = "Actividades personalesEdit", Peso = 50});

        modelBuilder.Entity<Categoria>(categoria =>{
            categoria.ToTable("Categoria");

            categoria.HasKey(cat => cat.CategoriaID);

            categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);

            categoria.Property(p => p.Descripcion).IsRequired(false).HasMaxLength(250);

            categoria.Property(p=>p.Peso);

            categoria.HasData(categoriasInit);
        });


        List<Tarea> tareasInit = new List<Tarea>();

        tareasInit.Add(new Tarea() { TareaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb410"), CategoriaID = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb4ef"), PrioridadTarea = TiposPrioridad.Media, Titulo = "Pago de servicios publicosEdit", FechaCreacion = DateTime.Now });
        tareasInit.Add(new Tarea() { TareaId = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb411"), CategoriaID = Guid.Parse("fe2de405-c38e-4c90-ac52-da0540dfb402"), PrioridadTarea = TiposPrioridad.Baja, Titulo = "Terminar de ver pelicula en netflixEdit", FechaCreacion = DateTime.Now });

        
        modelBuilder.Entity<Tarea>(tarea=>
        {
            tarea.ToTable("Tarea");

            tarea.HasKey(p=> p.TareaId);

            tarea.HasOne(p=> p.Categoria).WithMany(p=> p.Tareas).HasForeignKey(p=> p.CategoriaID);

            tarea.Property(p=> p.Titulo).IsRequired().HasMaxLength(200);

            tarea.Property(p=> p.Descripcion).IsRequired(false);;

            tarea.Property(p=> p.PrioridadTarea);

            tarea.Property(p=> p.FechaCreacion);


            tarea.Ignore(p=> p.Resumen);


            tarea.HasData(tareasInit);

        });

    }
    
}
