using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asistencia.Negocio
{
    public partial class Turno
    {

        #region Variables privadas

        private Datos.Turno DTurno_;

        #endregion

        #region Metodos publicos

        public System.Int32 Insertar ( System.String descricion )
        {
            try
            {
                DTurno_ = new Datos.Turno ();
                DTurno_.descricion = descricion;
                int i = DTurno_.Insertar ();
                if ( i < 0 )
                    throw new System.Exception ( "Turno: Error al insertar. \n" );
                return i;
            }
            catch ( System.Exception ex )
            {
                throw new System.Exception ( "Turno: Error al insertar. \n" + ex.Message );
            }
        }

        public void Actualizar ( System.Int32 id, System.String descricion )
        {
            try
            {
                DTurno_ = new Datos.Turno ();
                DTurno_.id = id;
                DTurno_.descricion = descricion;
                ;
                DTurno_.Actualizar ();
            }
            catch ( System.Exception ex )
            {
                throw new System.Exception ( "Turno: Error al actualizar. \n" + ex.Message );
            }
        }

        public void Eliminar ( System.Int32 id )
        {
            try
            {
                DTurno_ = new Datos.Turno ();
                DTurno_.id = id;
                DTurno_.Eliminar ();
            }
            catch ( System.Exception ex )
            {
                throw new System.Exception ( "Turno: Error al eliminar. \n" + ex.Message );
            }
        }

        public System.Data.DataTable Listar ()
        {
            DTurno_ = new Datos.Turno ();
            return DTurno_.Listar ();
        }

        public System.Data.DataTable Listar ( string condicion, params object[] args )
        {
            try
            {
                DTurno_ = new Datos.Turno ();
                return DTurno_.Listar ( condicion, args );
            }
            catch ( System.Exception ex )
            {
                throw new System.Exception ( "Turno: Error al listar. \n" + ex.Message );
            }
        }

        public System.Data.DataRow Obtener ( System.Int32 id )
        {
            try
            {
                DTurno_ = new Datos.Turno ();
                DTurno_.id = id;
                return DTurno_.Obtener ();
            }
            catch ( System.Exception ex )
            {
                throw new System.Exception ( "Turno: Error al obtener datos. \n" + ex.Message );
            }
        }

        #endregion

        #region Horario ABML

        #region Variables privadas

        private Datos.Horario DHorario_;

        #endregion

        #region Metodos publicos

        public System.Int32 InsertarHorario ( System.String dia, System.DateTime horaEntrada, System.DateTime horaSalida, System.Int32 idTurno )
        {
            try
            {
                DHorario_ = new Datos.Horario ();
                DHorario_.dia = dia;
                DHorario_.horaEntrada = horaEntrada;
                DHorario_.horaSalida = horaSalida;
                DHorario_.idTurno = idTurno;
                int i = DHorario_.Insertar ();
                if ( i < 0 )
                    throw new System.Exception ( "Horario: Error al insertar. \n" );
                return i;
            }
            catch ( System.Exception ex )
            {
                throw new System.Exception ( "Horario: Error al insertar. \n" + ex.Message );
            }
        }

        public void ActualizarHorario ( System.Int32 id, System.String dia, System.DateTime horaEntrada, System.DateTime horaSalida, System.Int32 idTurno )
        {
            try
            {
                DHorario_ = new Datos.Horario ();
                DHorario_.id = id;
                DHorario_.dia = dia;
                DHorario_.horaEntrada = horaEntrada;
                DHorario_.horaSalida = horaSalida;
                DHorario_.idTurno = idTurno;
                ;
                DHorario_.Actualizar ();
            }
            catch ( System.Exception ex )
            {
                throw new System.Exception ( "Horario: Error al actualizar. \n" + ex.Message );
            }
        }

        public void EliminarHorario ( System.Int32 id )
        {
            try
            {
                DHorario_ = new Datos.Horario ();
                DHorario_.id = id;
                DHorario_.Eliminar ();
            }
            catch ( System.Exception ex )
            {
                throw new System.Exception ( "Horario: Error al eliminar. \n" + ex.Message );
            }
        }

        public System.Data.DataTable ListarHorario ()
        {
            DHorario_ = new Datos.Horario ();
            return DHorario_.Listar ();
        }

        public System.Data.DataTable ListarHorario ( string condicion, params object[] args )
        {
            try
            {
                DHorario_ = new Datos.Horario ();
                return DHorario_.Listar ( condicion, args );
            }
            catch ( System.Exception ex )
            {
                throw new System.Exception ( "Horario: Error al listar. \n" + ex.Message );
            }
        }

        public System.Data.DataTable ListarHorarioDeTurno ( int idTurno )
        {
            try
            {
                DHorario_ = new Datos.Horario ();
                return DHorario_.Listar ( "idTurno=?", idTurno );
            }
            catch ( System.Exception ex )
            {
                throw new System.Exception ( "Horario: Error al listar. \n" + ex.Message );
            }
        }

        public System.Data.DataRow ObtenerHorario ( System.Int32 id )
        {
            try
            {
                DHorario_ = new Datos.Horario ();
                DHorario_.id = id;
                return DHorario_.Obtener ();
            }
            catch ( System.Exception ex )
            {
                throw new System.Exception ( "Horario: Error al obtener datos. \n" + ex.Message );
            }
        }

        #endregion

        #endregion

    }
}