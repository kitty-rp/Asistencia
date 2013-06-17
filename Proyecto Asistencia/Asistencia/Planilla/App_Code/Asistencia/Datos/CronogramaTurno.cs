using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asistencia.Datos
{
    public class CronogramaTurno
    {

        #region Variables privadas

        private System.Int32 id_;
        private System.DateTime fecha_;
        private System.Int32 activo_;
        private System.Int32 idCronograma_;
        private System.Int32 idTurno_;

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
        public System.DateTime fecha
        {
            get
            {
                return fecha_;
            }
            set
            {
                fecha_ = value;
            }
        }
        public System.Int32 activo
        {
            get
            {
                return activo_;
            }
            set
            {
                activo_ = value;
            }
        }
        public System.Int32 idCronograma
        {
            get
            {
                return idCronograma_;
            }
            set
            {
                idCronograma_ = value;
            }
        }
        public System.Int32 idTurno
        {
            get
            {
                return idTurno_;
            }
            set
            {
                idTurno_ = value;
            }
        }

        #endregion

        #region Metodos publicos

        public System.Int32 Insertar ()
        {
            if ( Conexion.Conexion.Ejecutar ( "insert into CronogramaTurno values(?, ?, ?, ?)", fecha, activo, idCronograma, idTurno ) == 0 )
                return -1;
            System.Data.DataTable t = Conexion.Conexion.Obtener ( "select max(id) from CronogramaTurno" );
            return System.Convert.ToInt32 ( t.Rows[0][0] );
        }

        public void Actualizar ()
        {
            Conexion.Conexion.Ejecutar ( "update CronogramaTurno set fecha=?, activo=?, idCronograma=?, idTurno=? where id=?", fecha, activo, idCronograma, idTurno, id );
        }

        public void Eliminar ()
        {
            Conexion.Conexion.Ejecutar ( "delete from CronogramaTurno where id=?", id );
        }

        public System.Data.DataTable Listar ()
        {
            return Listar ( "" );
        }

        public System.Data.DataTable Listar ( string condicion, params object[] args )
        {
            string s = "select * from CronogramaTurno " + ( !string.IsNullOrEmpty ( condicion ) ? "where " + condicion : "" );
            return Conexion.Conexion.Obtener ( s, args );
        }

        public System.Data.DataRow Obtener ()
        {
            System.Data.DataTable t = Conexion.Conexion.Obtener ( "select * from CronogramaTurno where id=?", id );
            if ( t.Rows.Count > 0 )
            {
                id = System.Convert.ToInt32 ( t.Rows[0][0] );
                fecha = System.Convert.ToDateTime ( t.Rows[0][1] );
                activo = System.Convert.ToInt32 ( t.Rows[0][2] );
                idCronograma = System.Convert.ToInt32 ( t.Rows[0][3] );
                idTurno = System.Convert.ToInt32 ( t.Rows[0][4] );
                return t.Rows[0];
            }
            return null;
        }

        public System.Data.DataTable ListarDeCronograma ( int idCronograma )
        {
            //return Listar("idCronograma=?", idCronograma);
            string s = "select ct.*, DTipoBono_.descricion as turno from cronogramaTurno  ct inner join turno DTipoBono_ on ct.idTurno =DTipoBono_.id where ct.idCronograma=? ";
            return Conexion.Conexion.Obtener ( s, idCronograma );
        }

        #endregion

    }
}



