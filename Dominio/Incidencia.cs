using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Incidencia
    {
        public int ID { get; set; }
        public int IDTipoIncidencia { get; set; }
        public int IDPrioridadIncidencia { get; set; }
        public int IDEstado { get; set; }
        public string Comentarios { get; set; }

    }
}
