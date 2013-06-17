namespace Conexion
{
    public class Conexion
    {
        private static System.Data.OleDb.OleDbConnection cnx;
        private static string CadenaConexion = @"Provider=SQLoledb;Server=KITTY\SQLSERVER2008;Database=planilla;Integrated Security=SSPI";       
        private static System.Data.OleDb.OleDbTransaction transaccion;

        private static void Conectar()
        {
            if (cnx == null)
            {
                cnx = new System.Data.OleDb.OleDbConnection(CadenaConexion);
            }
            try
            {
                if (cnx.State != System.Data.ConnectionState.Open)
                    cnx.Open();
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Conexion: Error al conectar con el servidor.", ex);
            }
        }

        private static void Desconectar()
        {
            if (cnx == null)
                return;
            if (cnx.State != System.Data.ConnectionState.Closed && transaccion == null)
                cnx.Close();
        }

        public static void EmpezarTransaccion()
        {
            Conectar();
            if (transaccion != null)
                return;
            try
            {
                transaccion = cnx.BeginTransaction();
            }
            catch (System.Exception ex)
            {
                transaccion = null;
                throw new System.Exception("Conexion: Error al empezar la transacci�n.", ex);
            }
        }

        public static void DeshacerTransaccion()
        {
            if (transaccion != null)
                try
                {
                    transaccion.Rollback();
                }
                catch (System.Exception)
                {
                }
                finally
                {
                    transaccion = null;
                    Desconectar();
                }
        }

        public static void ConfirmarTransaccion()
        {
            if (transaccion == null)
                throw new System.Exception("Conexion: Error al confirmar la transacci�n.");
            try
            {
                transaccion.Commit();
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Conexion: Error al confirmar la transacci�n.", ex);
            }
            finally
            {
                transaccion = null;
                Desconectar();
            }
        }

        public static System.Data.OleDb.OleDbCommand Comando(string sql, params object[] args)
        {
            System.Data.OleDb.OleDbCommand com = new System.Data.OleDb.OleDbCommand(sql, cnx);
            for (System.Int32 i = 0; i < args.Length; i++)
            {
                System.Data.OleDb.OleDbParameter par = new System.Data.OleDb.OleDbParameter("DPeriodo_" + i, args[i]);
                com.Parameters.Add(par);
            }
            return com;
        }

        public static int Ejecutar(string sql, params object[] args)
        {
            Conectar();
            try
            {
                System.Data.OleDb.OleDbCommand com = Comando(sql, args);
                com.Transaction = transaccion;
                int i = com.ExecuteNonQuery();
                Desconectar();
                return i;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Conexion: Error al ejecutar.", ex);
            }
        }

        public static int EjecutarProc(string sql, params object[] args)
        {
            Conectar();
            try
            {
                System.Data.OleDb.OleDbCommand com = Comando(sql, args);
                com.CommandType = System.Data.CommandType.StoredProcedure;
                com.Transaction = transaccion;
                int i = com.ExecuteNonQuery();
                Desconectar();
                return i;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Conexion: Error al ejecutar.", ex);
            }
        }

        public static System.Data.DataTable Obtener(string sql, params object[] parametros)
        {
            Conectar();
            try
            {
                System.Data.DataTable dt = new System.Data.DataTable();
                System.Data.OleDb.OleDbCommand com = Comando(sql, parametros);
                com.Transaction = transaccion;
                System.Data.OleDb.OleDbDataReader r = com.ExecuteReader();
                dt.Load(r);
                return dt;
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("Conexion: Error al obtener.", ex);
            }
            finally
            {
                Desconectar();
            }
        }

    }

}