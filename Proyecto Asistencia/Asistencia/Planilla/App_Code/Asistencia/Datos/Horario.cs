using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asistencia.Datos
{
    public partial class Horario
    {

        #region Variables privadas

        private System.Int32 id_;
        private System.String dia_;
        private System.DateTime horaEntrada_;
        private System.DateTime horaSalida_;
        private System.Int32 idTurno_;
       
        #endregion

        #region Propiedades publicas

        public System.Int32 id
        {
            get { return id_; }
            set { id_ = value; }
        }
        public System.String dia
        {
            get { return dia_.Trim(); }
            set { dia_ = value; }
        }
        public System.DateTime horaEntrada
        {
            get { return horaEntrada_; }
            set { horaEntrada_ = value; }
        }
        public System.DateTime horaSalida
        {
            get { return horaSalida_; }
            set { horaSalida_ = value; }
        }
        public System.Int32 idTurno
        {
            get { return idTurno_; }
            set { idTurno_ = value; }
        }

        #endregion

        #region Metodos publicos

        public System.Int32 Insertar()
        {
            if (Conexion.Conexion.Ejecutar("insert into Horario values(?, ?, ?, ?)", dia, horaEntrada, horaSalida, idTurno) == 0) return -1;
            System.Data.DataTable t = Conexion.Conexion.Obtener("select max(id) from Horario");
            return System.Convert.ToInt32(t.Rows[0][0]);
        }

        public void Actualizar()
        {
            Conexion.Conexion.Ejecutar("update Horario set dia=?, horaEntrada=?, horaSalida=?, idTurno=? where id=?", dia, horaEntrada, horaSalida, idTurno, id);
        }

        public void Eliminar()
        {
            Conexion.Conexion.Ejecutar("delete from Horario where id=?", id);
        }

        public System.Data.DataTable Listar()
        {
            return Listar("");
        }

        public System.Data.DataTable Listar(string condicion, params object[] args)
        {
            string s = "select * from Horario " + (!string.IsNullOrEmpty(condicion) ? "where " + condicion : "");
            return Conexion.Conexion.Obtener(s, args);
        }

        public System.Data.DataRow Obtener()
        {
            System.Data.DataTable t = Conexion.Conexion.Obtener("select * from Horario where id=?", id);
            if (t.Rows.Count > 0)
            {
                id = System.Convert.ToInt32(t.Rows[0][0]);
                dia = System.Convert.ToString(t.Rows[0][1]);
                horaEntrada = System.Convert.ToDateTime(t.Rows[0][2]);
                horaSalida = System.Convert.ToDateTime(t.Rows[0][3]);
                idTurno = System.Convert.ToInt32(t.Rows[0][4]);
                return t.Rows[0];
            }
            return null;
        }

        #endregion

    }
}