using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyectoEF.Models;

public class Tarea
{

    public Guid TareaId { get; set; }
    public Guid CategoriaID { get; set; }

    public string Titulo { get; set; }

    public string Descripcion { get; set; }

    public TiposPrioridad PrioridadTarea  { get; set; }

    public DateTime FechaCreacion  { get; set; }

    public virtual Categoria Categoria {get;set;}

    public string Resumen {get;set;}

}
