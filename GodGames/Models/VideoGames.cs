using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GodGames.Models
{
public class VideoGames
{
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public List<Imagen> Imagenes { get; set; } = new List<Imagen>();
}
}