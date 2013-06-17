//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace Horario.Negocio
//{
//    public partial class Horario
//    {

//        private Datos.Horario h;

//        public System.Int32 Insertar(System.String dia, System.String horaEntrada, System.String horaSalida, System.Int32 idTurno)
//        {
//            try
//            {
//                h = new Datos.Horario();
//                h.dia = dia;
//                h.horaEntrada = horaEntrada;
//                h.horaSalida = horaSalida;
//                h.idTurno = idTurno;
//                int i = h.Insertar();
//                if (i < 0)
//                    throw new System.Exception("Horario: Error al insertar. \n");
//                return i;
//            }
//            catch (System.Exception ex)
//            {
//                throw new System.Exception("Horario: Error al insertar. \n" + ex.Message);
//            }
//        }

//        public void Actualizar(System.Int32 id, System.String dia, System.String horaEntrada, System.String horaSalida, System.Int32 idTurno)
//        {
//            try
//            {
//                h = new Datos.Horario();
//                h.id = id;
//                h.dia = dia;
//                h.horaEntrada = horaEntrada;
//                h.horaSalida = horaSalida;
//                h.idTurno = idTurno; ;
//                h.Actualizar();
//            }
//            catch (System.Exception ex)
//            {
//                throw new System.Exception("Horario: Error al actualizar. \n" + ex.Message);
//            }
//        }

//        public void Eliminar(System.Int32 id)
//        {
//            try
//            {
//                h = new Datos.Horario();
//                h.id = id;
//                h.Eliminar();
//            }
//            catch (System.Exception ex)
//            {
//                throw new System.Exception("Horario: Error al eliminar. \n" + ex.Message);
//            }
//        }

//        public System.Data.DataTable Listar()
//        {
//            h = new Datos.Horario();
//            return h.Listar();
//        }

//        public System.Data.DataTable Listar(string condicion, params object[] args)
//        {
//            try
//            {
//                h = new Datos.Horario();
//                return h.Listar(condicion, args);
//            }
//            catch (System.Exception ex)
//            {
//                throw new System.Exception("Horario: Error al listar. \n" + ex.Message);
//            }
//        }

//        public System.Data.DataRow Obtener(System.Int32 id)
//        {
//            try
//            {
//                h = new Datos.Horario();
//                h.id = id;
//                return h.Obtener();
//            }
//            catch (System.Exception ex)
//            {
//                throw new System.Exception("Horario: Error al obtener datos. \n" + ex.Message);
//            }
//        }

//    }
//}