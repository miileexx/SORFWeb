using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOFTDEM.SORF.CoreEntity
{
    public class MonitorNotificacionFactura
    {
        public string Factura { get; set; }
        public string Serie { get; set; }
        public decimal Importe { get; set; }
        public DateTime FechaFactura { get; set; }
        public DateTime FechaEnvio { get; set; }
        public string Patente { get; set; }
        public decimal FolioServicio { get; set; }
        public string ReferenciaSORF { get; set; }
        public string Operacion { get; set; }
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public int IdFacturarA { get; set; }
        public string NombreFacturarA { get; set; }
        public int CodigoError { get; set; }
        public string DescripcionError { get; set; }
        public int ReintentosEnvio { get; set; }
        public int ClavePROCEDA { get; set; }
    }
}
