using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOFTDEM.SORF.Enums;
using SOFTDEM.Bases.Response.Paginado;

namespace SOFTDEM.SORF.CoreEntity
{
    public class ConsultaMonitorFactura : PaginadoInfo
    {
        public int TipoFiltro { get; set; }
        public DateTime FechaInicio { get; set; }

        public DateTime FechaFinal { get; set; }

        public decimal FolioServicio { get; set; }

        public int IdCliente { get; set; }

        public int IdFacturarA { get; set; }

        public string ListaCodigoError { get; set; }

        public TipoConsultaReporteador TipoConsultaReporteador { get; set; }
    }
}
