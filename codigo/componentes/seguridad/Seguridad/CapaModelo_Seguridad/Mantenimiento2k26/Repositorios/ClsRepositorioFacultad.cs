using CapaModelo_Seguridad.Repositorios;                    // ClsSentencias
using CapaModelo_Seguridad.Mantenimiento2k26.Contratos;     // IRepositorioFacultad
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;

namespace CapaModelo_Seguridad.Mantenimiento2k26.Repositorios
{
    public class ClsRepositorioFacultad : ClsSentencias, IRepositorioFacultad
    {
        private string _SelectAll;
        private string _Insert;
        private string _Update;
        private string _Delete;
        private string _SelectReporte;

        public ClsRepositorioFacultad()
        {
            _SelectAll = "SELECT codigo_facultad, nombre_facultad, estatus_facultad " +
                         "FROM facultades";

            _Insert = "INSERT INTO facultades " +
                      "(codigo_facultad, nombre_facultad, estatus_facultad) " +
                      "VALUES (?, ?, ?)";

            _Update = "UPDATE facultades SET nombre_facultad=?, estatus_facultad=? " +
                      "WHERE codigo_facultad=?";

            _Delete = "DELETE FROM facultades WHERE codigo_facultad=?";

            _SelectReporte = "SELECT codigo_facultad AS CodigoFacultad, " +
                             "nombre_facultad AS NombreFacultad, " +
                             "estatus_facultad AS EstatusFacultad " +
                             "FROM facultades";
        }

        public int SeguridadMetAgregar(ClsFacultad Entidad)
        {
            var Parametros = new List<OdbcParameter>
            {
                new OdbcParameter("p_codigoFacultad",  Entidad.CodigoFacultad),
                new OdbcParameter("p_nombreFacultad",  Entidad.NombreFacultad),
                new OdbcParameter("p_estatusFacultad", Entidad.EstatusFacultad)
            };
            return SeguridadMetEjecucionNonQuery(_Insert, Parametros, CommandType.Text);
        }

        public int SeguridadMetEditar(ClsFacultad Entidad)
        {
            var Parametros = new List<OdbcParameter>
            {
                new OdbcParameter("p_nombreFacultad",  Entidad.NombreFacultad),
                new OdbcParameter("p_estatusFacultad", Entidad.EstatusFacultad),
                new OdbcParameter("p_codigoFacultad",  Entidad.CodigoFacultad)  // PK al final
            };
            return SeguridadMetEjecucionNonQuery(_Update, Parametros, CommandType.Text);
        }

        public int SeguridadMetRemover(ClsFacultad Entidad)
        {
            var Parametros = new List<OdbcParameter>
            {
                new OdbcParameter("p_codigoFacultad", Entidad.CodigoFacultad)
            };
            return SeguridadMetEjecucionNonQuery(_Delete, Parametros, CommandType.Text);
        }

        public IEnumerable<ClsFacultad> SeguridadMetObtenerTodos()
        {
            var ListaFacultades = new List<ClsFacultad>();
            var TablaDatos = SeguridadMetEjecucionConsulta(_SelectAll, CommandType.Text);

            foreach (DataRow Fila in TablaDatos.Rows)
            {
                var Facultad = new ClsFacultad
                {
                    CodigoFacultad = Fila[0].ToString(),
                    NombreFacultad = Fila[1] != DBNull.Value ? Fila[1].ToString() : "",
                    EstatusFacultad = Fila[2] != DBNull.Value ? Fila[2].ToString() : ""
                };
                ListaFacultades.Add(Facultad);
            }
            return ListaFacultades;
        }

        public DataTable MantenimientoMetObtenerFacultadesTabla()
        {
            return SeguridadMetEjecucionConsulta(_SelectAll, CommandType.Text);
        }

        public DataTable MantenimientoMetObtenerFacultadesReporte()
        {
            return SeguridadMetEjecucionConsulta(_SelectReporte, CommandType.Text);
        }
    }
}
