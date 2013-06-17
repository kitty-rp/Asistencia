using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asistencia.Datos
{
    public partial class Turno
    {

        #region Variables privadas

        private System.Int32 id_;
        private System.String descricion_;

        #endregion

        #region Propiedades publicas

        public System.Int32 id
        {
            get
            {
                return id_;
            }
            set
            {
                id_ = value;
            }
        }
        public System.String descricion
        {
            get
            {
                return descricion_.Trim ();
            }
            set
            {
                descricion_ = value;
            }
        }

        #endregion

        #region Metodos publicos

        public System.Int32 Insertar ()
        {
            if ( Conexion.Conexion.Ejecutar ( "insert into Turno values(?)", descricion ) == 0 )
                return -1;
            System.Data.DataTable t = Conexion.Conexion.Obtener ( "select max(id) from Turno" );
            return System.Convert.ToInt32 ( t.Rows[0][0] );
        }

        public void Actualizar ()
        {
            Conexion.Conexion.Ejecutar ( "update Turno set descricion=? where id=?", descricion, id );
        }

        public void Eliminar ()
        {
            Conexion.Conexion.Ejecutar ( "delete from Turno where id=?", id );
        }

        public System.Data.DataTable Listar ()
        {
            return Listar ( "" );
        }

        public System.Data.DataTable Listar ( string condicion, params object[] args )
        {
            string s = "select * from Turno " + ( !string.IsNullOrEmpty ( condicion ) ? "where " + condicion : "" );
            return Conexion.Conexion.Obtener ( s, args );
        }

        public System.Data.DataRow Obtener ()
        {
            System.Data.DataTable t = Conexion.Conexion.Obtener ( "select * from Turno where id=?", id );
            if ( t.Rows.Count > 0 )
            {
                id = System.Convert.ToInt32 ( t.Rows[0][0] );
                descricion = System.Convert.ToString ( t.Rows[0][1] );
                return t.Rows[0];
            }
            return null;
        }


        #endregion
    }
}