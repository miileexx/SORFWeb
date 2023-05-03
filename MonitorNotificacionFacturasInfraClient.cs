using Newtonsoft.Json;
using NLog;
using RestSharp;
using SOFTDEM.Bases.EntityBase.Entitys;
using SOFTDEM.Bases.Response.Paginado;
using SOFTDEM.Bases.Response.Response;
using SOFTDEM.Bases.Utilitys.Extensions;
using SOFTDEM.SORF.CoreEntity;
using SOFTDEM.SORF.CoreInfrastructureInterfaces;
using SOFTDEM.SORF.Enums;
using SOFTDEM.SORF.InfrastructureService.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SOFTDEM.SORF.InfrastructureService
{
    public class MonitorNotificacionFacturasInfraClient : ClientBase, IMonitorNotificacionFacturasInfraClient
    {
        #region Variables

        private static Logger logger = LogManager.GetCurrentClassLogger();
        private const string BaseUri = "MonitorNotificacionFacturas";
        private const string ObtenerListaPaginadaMonitorNotificacionesUri = "MonitorNotificacionFacturas/ObtenerListaPaginadaMonitorNotificaciones";
        private const string ObtenerReporteMonitorNotificacionesUri = "MonitorNotificacionFacturas/ObtenerReporteMonitorNotificaciones";
        #endregion
        public async Task<PaginadoResult<MonitorNotificacionFactura>> ObtenerListaPaginadaMonitorNotificaciones(ConsultaMonitorFactura filtros)
        {
            try
            {
                return await PostAsync<PaginadoResult<MonitorNotificacionFactura>, ConsultaMonitorFactura>(ObtenerListaPaginadaMonitorNotificacionesUri, filtros);
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
                throw;
            }
        }

        /// <summary>
        /// Método que obtiene la información del reporte Tarja Única y Tarja entrada
        /// </summary>
        /// <param name="filtro">Entidad que contiene los filtros para la consulta</param>
        /// <returns>Información para generar el reporte</returns>
        public async Task<ResultBase<DocumentoBase>> ObtenerReporteMonitorNotificaciones(ConsultaMonitorFactura filtro)
        {
            try
            {
                var resultEntityBase = new ResultBase<DocumentoBase>();

                if (filtro != null)
                {
                    resultEntityBase = await PostDocumentoAsync(ObtenerReporteMonitorNotificacionesUri, filtro, "ReporteMonitorNotificaciones", TipoFormato.Excel);
                }
                else
                {
                    resultEntityBase.MensajeRespuesta = "Filtro nulo";
                }

                return resultEntityBase;
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
                throw;
            }
        }

    }

    
}
