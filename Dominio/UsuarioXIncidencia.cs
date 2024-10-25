using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class UsuarioXIncidencia //cambiar a REPORTE INCIDENCIA
    {
        public int ID { get; set; }
        public string Nombre { get; set; } // titulo del reporte
        public int IDIncidencia { get; set; }
        public int IDCliente { get; set; }
        public int IDTelefonista { get; set; }
        public string Descripcion { get; set; } // cambiar a DEVOLUCION
    }
}
