using SOFTDEM.Bases.EntityBase.Entitys;
using SOFTDEM.Bases.Response.Paginado;
using SOFTDEM.Bases.Response.Response;
using SOFTDEM.SORF.CoreEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOFTDEM.SORF.CoreInfrastructureInterfaces
{
    public interface IMonitorNotificacionFacturasInfraClient
    {

        Task<PaginadoResult<MonitorNotificacionFactura>> ObtenerListaPaginadaMonitorNotificaciones(ConsultaMonitorFactura filtros);

        Task<ResultBase<DocumentoBase>> ObtenerReporteMonitorNotificaciones(ConsultaMonitorFactura filtro);


    }
}
