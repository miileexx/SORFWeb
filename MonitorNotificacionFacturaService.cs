using NLog;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using SOFTDEM.Bases.EntityBase.Entitys;
using SOFTDEM.Bases.Response.Paginado;
using SOFTDEM.Bases.Response.Response;
using SOFTDEM.SORF.CoreDomainInterfaces;
using SOFTDEM.SORF.CoreEntity;
using SOFTDEM.SORF.CoreServicesInterfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOFTDEM.Bases.Utilitys.Extensions;
using System.Data;
using SOFTDEM.SORF.InfrastructureReports;
using SOFTDEM.SORF.Enums;
using SOFTDEM.Bases.EntityBase.Enum;
using Newtonsoft.Json;

namespace SOFTDEM.SORF.Services
{
    public class MonitorNotificacionFacturaService : BaseService, IMonitorNotificacionFacturasService
    {

        private static Logger logger = LogManager.GetCurrentClassLogger();
        private readonly IMonitorNotificacionFacturasRepository monitorNotificacionFacturasRepository;

        public MonitorNotificacionFacturaService(IMonitorNotificacionFacturasRepository monitorNotificacionFacturasRepository)
        {
            this.monitorNotificacionFacturasRepository = monitorNotificacionFacturasRepository;
        }
        
        public int ObtenerSuma(int x, int y)
        {
            return x + y;
        }

        public PaginadoResult<MonitorNotificacionFactura> ObtenerListadoMonitorNotificacionFacturas(ConsultaMonitorFactura consultaMonitorFactura)
        {
            return monitorNotificacionFacturasRepository?.GetListadoMonitorNotificacionFacturas(consultaMonitorFactura);
        }

        public ResultBase<DocumentoBase> ObtenerReporteMonitorNotificaciones(ConsultaMonitorFactura filtroTarja)
        {

            try
            {
                var resultDocumentoBase = new ResultBase<DocumentoBase>();
                var npoiExcelExportarDatos = new NpoiExcelExportarDatos();

                DataSet dataSet = monitorNotificacionFacturasRepository.GetDataSetMonitorNotificacionFacturas(filtroTarja);

                if (dataSet?.Tables?.Count > 0 && dataSet.Tables[0].Rows?.Count > 0)
                {
                    dataSet.Tables[0].TableName = "MonitorFactura";

                    if (dataSet.Tables[0].Columns.Contains("TotalRegistros"))
                    {
                        dataSet.Tables[0].Columns.Remove("TotalRegistros");
                    }

                    resultDocumentoBase.Data = npoiExcelExportarDatos.DataSetToDocumentoBase(dataSet);
                }
                else
                {
                    resultDocumentoBase.MensajeRespuesta = "No existe información";
                }
                
                return resultDocumentoBase;
            }
            catch
            {
                throw;
            }

        }

    }
}
