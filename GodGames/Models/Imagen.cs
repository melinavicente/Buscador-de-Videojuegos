using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace GodGames.Models
{
public class Imagen
{
    public int Id { get; set; }
    public string URL { get; set; } = string.Empty;

    public int IdVideogames { get; set; }

    [ForeignKey("IdVideogames")] 
    public VideoGames? VideoGames { get; set; } 
}
}