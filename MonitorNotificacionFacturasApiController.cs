using SOFTDEM.Bases.EntityBase.Entitys;
using SOFTDEM.Bases.Response.Paginado;
using SOFTDEM.Bases.Response.Response;
using SOFTDEM.SORF.API.ActionFilters;
using SOFTDEM.SORF.API.Controllers;
using SOFTDEM.SORF.CoreEntity;
using SOFTDEM.SORF.CoreServicesInterfaces;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace SOFTDEM.SORF.API.Controllers

{     /// <summary>
      /// ConfiguracionNotificacionesApiController
      /// </summary>
    [RoutePrefix("MonitorNotificacionFacturas")]
    public class MonitorNotificacionFacturasApiController : ApiControllerBase
    {
        private readonly IMonitorNotificacionFacturasService monitorNotificacionFacturasService;

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="monitorNotificacionFacturasService">Interfaz de tipo IMonitorNotificacionFacturasService</param>
        public MonitorNotificacionFacturasApiController(IMonitorNotificacionFacturasService monitorNotificacionFacturasService)
        {
            this.monitorNotificacionFacturasService = monitorNotificacionFacturasService;
        }
        #endregion

        /// <summary>
        /// Listado paginado de Monitor Notificación Facturas
        /// </summary>
        /// <param name="filtro">Entity con filtros aplicar para la consulta</param>
        /// <returns>Listado paginado de información</returns>
        [SwaggerResponse(HttpStatusCode.OK, Description = "Listado paginado de MonitorNotificacionFacturas", Type = typeof(PaginadoResult<MonitorNotificacionFactura>))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Si sucede un error retornar un objeto ResultBase con la información correspondiente", Type = typeof(ResultBase))]
        [AuthenticationFilter]
        [Route("ObtenerListaPaginadaMonitorNotificaciones")]
        [HttpPost]
        public IHttpActionResult ObtenerListaPaginadaMonitorNotificaciones(ConsultaMonitorFactura filtro)
        {
            try
            {
                PaginadoResult<MonitorNotificacionFactura> listadoPaginadoResult = monitorNotificacionFacturasService?.ObtenerListadoMonitorNotificacionFacturas(filtro);

                return Ok(listadoPaginadoResult);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Método que obtiene la información del reporte Tarja Única y Tarja entrada
        /// </summary>
        /// <param name="filtro">Entidad que contiene los filtros para la consulta</param>
        /// <returns>Información para generar el reporte</returns>
        [SwaggerResponse(HttpStatusCode.OK, Description = "ResultBase con la información para indicar si guardó correctamente (Success = true), en caso contrario muestra un mensaje de respuesta.", Type = typeof(ResultBase<DocumentoBase>))]
        [SwaggerResponse(HttpStatusCode.BadRequest, Description = "Si sucede un error retornar un objeto ResultBase con la información correspondiente.", Type = typeof(ResultBase))]
        [AuthenticationFilter]
        [Route("ObtenerReporteMonitorNotificaciones")]
        [HttpPost]
        public IHttpActionResult ObtenerReporteMonitorNotificaciones(ConsultaMonitorFactura filtro)
        {
            try
            {
                ResultBase<DocumentoBase> resultBaseReporte = monitorNotificacionFacturasService?.ObtenerReporteMonitorNotificaciones(filtro);

                return Ok(resultBaseReporte);
            }
            catch
            {
                throw;
            }
        }

    }
}