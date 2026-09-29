using CapaModelo_Seguridad.Mantenimiento2k26.Contratos;
using CapaModelo_Seguridad.Mantenimiento2k26.Repositorios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;

namespace CapaControlador_Seguridad.Mantenimiento2k26
{
    public class ClsModeloFacultad
    {
        private string _CodigoFacultad;
        private string _NombreFacultad;
        private string _EstatusFacultad;
        private ClsRepositorioFacultad _RepositorioFacultad;

        public EstadoEntidad Estado { private get; set; }

        public string CodigoFacultad { get => _CodigoFacultad; set => _CodigoFacultad = value; }
        public string NombreFacultad { get => _NombreFacultad; set => _NombreFacultad = value; }
        public string EstatusFacultad { get => _EstatusFacultad; set => _EstatusFacultad = value; }

        public ClsModeloFacultad()
        {
            _RepositorioFacultad = new ClsRepositorioFacultad();
        }

        public string MantenimientoMetGrabarCambios()
        {
            string Mensaje = null;
            try
            {
                var Facultad = new ClsFacultad
                {
                    CodigoFacultad = _CodigoFacultad,
                    NombreFacultad = _NombreFacultad,
                    EstatusFacultad = _EstatusFacultad
                };

                switch (Estado)
                {
                    case EstadoEntidad.Added:
                        _RepositorioFacultad.SeguridadMetAgregar(Facultad);
                        ClsModeloBitacora.SeguridadMetRegistrarAccion(
                            "INSERT", "facultades", 0,
                            "Se agregó la facultad: " + _NombreFacultad);
                        Mensaje = "Registro guardado exitosamente.";
                        break;

                    case EstadoEntidad.Modified:
                        _RepositorioFacultad.SeguridadMetEditar(Facultad);
                        ClsModeloBitacora.SeguridadMetRegistrarAccion(
                            "UPDATE", "facultades", 0,
                            "Se actualizó la facultad: " + _NombreFacultad);
                        Mensaje = "Registro actualizado exitosamente.";
                        break;

                    case EstadoEntidad.Deleted:
                        _RepositorioFacultad.SeguridadMetRemover(Facultad);
                        ClsModeloBitacora.SeguridadMetRegistrarAccion(
                            "DELETE", "facultades", 0,
                            "Se eliminó la facultad código: " + _CodigoFacultad);
                        Mensaje = "Registro eliminado exitosamente.";
                        break;
                }
            }
            catch (OdbcException ex)
            {
                if (ex.Errors.Count > 0 && ex.Errors[0].NativeError == 1062)
                    Mensaje = "Ya existe una facultad con ese código. Use un código diferente.";
                else
                    Mensaje = "Ocurrió un problema al procesar la solicitud. Verifique los datos e intente nuevamente.";
            }
            catch (Exception)
            {
                Mensaje = "Ocurrió un error inesperado. Intente nuevamente o contacte al administrador.";
            }
            return Mensaje;
        }

        public DataTable MantenimientoMetObtenerFacultadesTabla()
        {
            return _RepositorioFacultad.MantenimientoMetObtenerFacultadesTabla();
        }

        public IEnumerable<ClsFacultad> MantenimientoMetObtenerFacultadesReporte()
        {
            return _RepositorioFacultad.SeguridadMetObtenerTodos();
        }
    }
}