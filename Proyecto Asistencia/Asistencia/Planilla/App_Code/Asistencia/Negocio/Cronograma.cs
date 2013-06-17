using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asistencia.Negocio
{
    public partial class Cronograma
    {
        #region Variables privadas

        private Datos.Cronograma DCronograma_;

        #endregion

        #region Metodos publicos

        public System.Int32 Insertar ( System.String descripcion, System.DateTime fechaIni, System.DateTime fechaFin )
        {
            try
            {
                DCronograma_ = new Datos.Cronograma ();
                DCronograma_.descripcion = descripcion;
                DCronograma_.fechaIni = fechaIni;
                DCronograma_.fechaFin = fechaFin;
                int i = DCronograma_.Insertar ();
                if ( i < 0 )
                    throw new System.Exception ( "Cronograma: Error al insertar. \n" );

                return i;
            }
            catch ( System.Exception ex )
            {
                throw new System.Exception ( "Cronograma: Error al insertar. \n" + ex.Message );
            }
        }

        public void Actualizar ( System.Int32 id, System.String descripcion, System.DateTime fechaIni, System.DateTime fechaFin )
        {
            try
            {
                DCronograma_ = new Datos.Cronograma ();
                DCronograma_.id = id;
                DCronograma_.descripcion = descripcion;
                DCronograma_.fechaIni = fechaIni;
                DCronograma_.fechaFin = fechaFin;
                ;
                DCronograma_.Actualizar ();
            }
            catch ( System.Exception ex )
            {
                throw new System.Exception ( "Cronograma: Error al actualizar. \n" + ex.Message );
            }
        }

        public void Eliminar ( System.Int32 id )
        {
            try
            {
                DCronograma_ = new Datos.Cronograma ();
                DCronograma_.id = id;
                DCronograma_.Eliminar ();
            }
            catch ( System.Exception ex )
            {
                throw new System.Exception ( "Cronograma: Error al eliminar. \n" + ex.Message );
            }
        }

        public System.Data.DataTable Listar ()
        {
            DCronograma_ = new Datos.Cronograma ();
            return DCronograma_.Listar ();
        }

        public System.Data.DataTable Listar ( string condicion, params object[] args )
        {
            try
            {
                DCronograma_ = new Datos.Cronograma ();
                return DCronograma_.Listar ( condicion, args );
            }
            catch ( System.Exception ex )
            {
                throw new System.Exception ( "Cronograma: Error al listar. \n" + ex.Message );
            }
        }

        public System.Data.DataRow Obtener ( System.Int32 id )
        {
            try
            {
                DCronograma_ = new Datos.Cronograma ();
                DCronograma_.id = id;

                return DCronograma_.Obtener ();
            }
            catch ( System.Exception ex )
            {
                throw new System.Exception ( "Cronograma: Error al obtener datos. \n" + ex.Message );
            }
        }
        #endregion

        #region CronogramaTurno

        #region Variables privadas

        private Datos.CronogramaTurno DCronogrmaTurno_;

        #endregion

        #region Metodos publicos

        public System.Int32 InsertarCronogramaTurno ( System.DateTime fecha, System.Int32 activo, System.Int32 idCronograma, System.Int32 idTurno )
        {
            try
            {
                DCronogrmaTurno_ = new Datos.CronogramaTurno ();
                DCronogrmaTurno_.fecha = fecha;
                DCronogrmaTurno_.activo = activo;
                DCronogrmaTurno_.idCronograma = idCronograma;
                DCronogrmaTurno_.idTurno = idTurno;
                int i = DCronogrmaTurno_.Insertar ();
                if ( i < 0 )
                    throw new System.Exception ( "CronogramaTurno: Error al insertar. \n" );
                return i;
            }
            catch ( System.Exception ex )
            {
                throw new System.Exception ( "CronogramaTurno: Error al insertar. \n" + ex.Message );
            }
        }

        public void ActualizarCronogramaTurno ( System.Int32 id, System.DateTime fecha, System.Int32 activo, System.Int32 idCronograma, System.Int32 idTurno )
        {
            try
            {
                DCronogrmaTurno_ = new Datos.CronogramaTurno ();
                DCronogrmaTurno_.id = id;
                DCronogrmaTurno_.fecha = fecha;
                DCronogrmaTurno_.activo = activo;
                DCronogrmaTurno_.idCronograma = idCronograma;
                DCronogrmaTurno_.idTurno = idTurno;
                ;
                DCronogrmaTurno_.Actualizar ();
            }
            catch ( System.Exception ex )
            {
                throw new System.Exception ( "CronogramaTurno: Error al actualizar. \n" + ex.Message );
            }
        }

        public void EliminarCronogramaTurno ( System.Int32 id )
        {
            try
            {
                DCronogrmaTurno_ = new Datos.CronogramaTurno ();
                DCronogrmaTurno_.id = id;
                DCronogrmaTurno_.Eliminar ();
            }
            catch ( System.Exception ex )
            {
                throw new System.Exception ( "CronogramaTurno: Error al eliminar. \n" + ex.Message );
            }
        }

        public System.Data.DataTable ListarCronogramaTurno ()
        {
            DCronogrmaTurno_ = new Datos.CronogramaTurno ();
            return DCronogrmaTurno_.Listar ();
        }

        public System.Data.DataTable ListarCronogramaTurno ( string condicion, params object[] args )
        {
            try
            {
                DCronogrmaTurno_ = new Datos.CronogramaTurno ();
                return DCronogrmaTurno_.Listar ( condicion, args );
            }
            catch ( System.Exception ex )
            {
                throw new System.Exception ( "CronogramaTurno: Error al listar. \n" + ex.Message );
            }
        }

        public System.Data.DataRow ObtenerCronogramaTurno ( System.Int32 id )
        {
            try
            {
                DCronogrmaTurno_ = new Datos.CronogramaTurno ();
                DCronogrmaTurno_.id = id;
                return DCronogrmaTurno_.Obtener ();
            }
            catch ( System.Exception ex )
            {
                throw new System.Exception ( "CronogramaTurno: Error al obtener datos. \n" + ex.Message );
            }
        }


        public System.Data.DataTable ListarDeCronograma ( int idCronograma )
        {
            try
            {
                DCronogrmaTurno_ = new Datos.CronogramaTurno ();
                return DCronogrmaTurno_.ListarDeCronograma ( idCronograma );
            }
            catch ( System.Exception ex )
            {
                throw new System.Exception ( "CronogramaTurno: Error al listar. \n" + ex.Message );
            }
        }
        #endregion

        #endregion

    }
}

