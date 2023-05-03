using NLog;
using SOFTDEM.Bases.Response.Paginado;
using SOFTDEM.Bases.Response.Response;
using SOFTDEM.SORF.CoreDomainInterfaces;
using SOFTDEM.SORF.CoreEntity;
using SOFTDEM.SORF.Enums;
using SOFTDEM.SORF.Infrastructure.DataEL.Bases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOFTDEM.SORF.Infrastructure.DataEL
{
    public partial class MonitorNotificacionFacturasRepository : RepositoryDALBase , IMonitorNotificacionFacturasRepository 
    {

        #region Variables
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private long totalRegistros; //Se agrego para poder hacer el paginado
        #endregion

        public PaginadoResult<MonitorNotificacionFactura> GetListadoMonitorNotificacionFacturas(ConsultaMonitorFactura consultaMonitorFactura) 
        {
            try
            {

                CreateConnection();

                SetStoredProcedure("[SORF].[usp_SORF_RListadoPaginadoMonitorNotificacionFacturas]");

                SetInParameter("@nTipoFiltro", DbType.Int32, consultaMonitorFactura.TipoFiltro);

                SetInParameter("@dFechaInicio", DbType.DateTime, consultaMonitorFactura.FechaInicio);

                SetInParameter("@dFechaFinal", DbType.DateTime, consultaMonitorFactura.FechaFinal);

                SetInParameter("@nFolioServicio", DbType.Decimal, consultaMonitorFactura.FolioServicio);

                SetInParameter("@nIdCliente042", DbType.Int32, consultaMonitorFactura.IdCliente);

                SetInParameter("@nIdFacturarA044", DbType.Int32, consultaMonitorFactura.IdFacturarA);

                SetInParameter("@sListErrores", DbType.String, consultaMonitorFactura.ListaCodigoError);

                SetInParameter("@bPaginarRegistros", DbType.Boolean, true);

                SetParametrosPaginado(consultaMonitorFactura);

                ExecuteReader();

                List<MonitorNotificacionFactura> listaMonitorNotificaionFactura = AddItemsMonitorNotificaionFactura();

                var paginadoInfo = new PaginadoInfo()
                {
                    RegistrosPorPagina = consultaMonitorFactura.RegistrosPorPagina,
                    NumeroDePagina = consultaMonitorFactura.NumeroDePagina,
                    TotalRegistros = totalRegistros
                };

                var paginadoResult = new PaginadoResult<MonitorNotificacionFactura>(listaMonitorNotificaionFactura, paginadoInfo);

                return paginadoResult;

            }
            catch
            {
              throw;
            } 
            finally
            {
                CloseConnection();
            }

        }

        public DataSet GetDataSetMonitorNotificacionFacturas(ConsultaMonitorFactura consultaMonitorFactura)
        {
            try
            {

                DataSet dsReporte = new DataSet();

                CreateConnection();

                SetStoredProcedure("[SORF].[usp_SORF_RListadoPaginadoMonitorNotificacionFacturas]");

                SetInParameter("@nTipoFiltro", DbType.Int32, consultaMonitorFactura.TipoFiltro);

                SetInParameter("@dFechaInicio", DbType.DateTime, consultaMonitorFactura.FechaInicio);

                SetInParameter("@dFechaFinal", DbType.DateTime, consultaMonitorFactura.FechaFinal);

                SetInParameter("@nFolioServicio", DbType.Decimal, consultaMonitorFactura.FolioServicio);

                SetInParameter("@nIdCliente042", DbType.Int32, consultaMonitorFactura.IdCliente);

                SetInParameter("@nIdFacturarA044", DbType.Int32, consultaMonitorFactura.IdFacturarA);

                SetInParameter("@sListErrores", DbType.String, consultaMonitorFactura.ListaCodigoError);

                SetInParameter("@bPaginarRegistros", DbType.Boolean, false);

                SetParametrosPaginado(consultaMonitorFactura);

                dsReporte = GetDataSet();

                return dsReporte;


            }
            catch
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }

        }

        private List<MonitorNotificacionFactura> AddItemsMonitorNotificaionFactura()
        {
            List<MonitorNotificacionFactura> listaMonitorNotificaionFactura = new List<MonitorNotificacionFactura>();

            while (IsRead())
            {
                var detalleMonitorNotificacion = new MonitorNotificacionFactura()
                {
                    Factura = IssetColumn("sFactura") ? GetStringValue("sFactura", string.Empty) : string.Empty,
                    Serie = IssetColumn("sSerie") ? GetStringValue("sSerie", string.Empty) : string.Empty,
                    Importe = IssetColumn("nImporte") ? GetIntegerValue("nImporte", 0) : 0,
                    FechaFactura = IssetColumn("dFechaFactura") ? GetDateTimeValue("dFechaFactura", DateTime.Now) : DateTime.Now,
                    Patente = IssetColumn("sPatente") ? GetStringValue("sPatente", string.Empty) : string.Empty,
                    FechaEnvio = IssetColumn("dFechaEnvio") ? GetDateTimeValue("dFechaEnvio", DateTime.Now) : DateTime.Now,
                    FolioServicio = IssetColumn("sFolioServicio") ? GetDecimalValue("sFolioServicio", 0) : 0,
                    ReferenciaSORF = IssetColumn("sReferenciaSORF") ? GetStringValue("sReferenciaSORF", string.Empty) : string.Empty,
                    Operacion = IssetColumn("sOperacion") ? GetStringValue("sOperacion", string.Empty) : string.Empty,
                    IdCliente = IssetColumn("nIdCliente") ? GetIntegerValue("nIdCliente", 0) : 0,
                    NombreCliente = IssetColumn("sNombreCliente") ? GetStringValue("sNombreCliente", string.Empty) : string.Empty,
                    IdFacturarA = IssetColumn("nIdClienteFacturarA") ? GetIntegerValue("nIdClienteFacturarA", 0) : 0,
                    NombreFacturarA = IssetColumn("sNombreFacturarA") ? GetStringValue("sNombreFacturarA", string.Empty) : string.Empty,
                    CodigoError = IssetColumn("nCodigoError") ? GetIntegerValue("nCodigoError", 0) : 0,
                    DescripcionError = IssetColumn("sProblema") ? GetStringValue("sProblema", string.Empty) : string.Empty,
                    ReintentosEnvio = IssetColumn("nReintentos") ? GetIntegerValue("nReintentos", 0) : 0,
                   
                };

                totalRegistros = IssetColumn("TotalRegistros") ? GetIntegerValue("TotalRegistros", 0) : 0;

                listaMonitorNotificaionFactura.Add(detalleMonitorNotificacion);
            }


            return listaMonitorNotificaionFactura;
        }
    }
}
