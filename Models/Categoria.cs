using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace proyectoEF.Models;

public class Categoria
{
    public Guid CategoriaID { get; set; }

    public string Nombre { get; set; }

    public string Descripcion { get; set; }

    public int Peso { get; set; }

    [JsonIgnore]
    public virtual ICollection<Tarea> Tareas {get;set;}

}
