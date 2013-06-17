using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asistencia.Presentacion.Turno
{
    public partial class Listado : System.Web.UI.Page
    {

        #region Variables privadas

        private Negocio.Turno NTurno_ = new Negocio.Turno ();

        #endregion

        #region eventos

        protected void Page_Load ( object sender, EventArgs e )
        {
            actualizar ();
        }

        protected void gvListado_RowCommand ( object sender, GridViewCommandEventArgs e )
        {
            if ( e.CommandName == "Eliminar" )
            {
                NTurno_.Eliminar ( int.Parse ( e.CommandArgument.ToString () ) );
                actualizar ();
            }
        }


        #endregion

        #region Metodos privados

        private void actualizar ()
        {
            gvListado.DataSource = NTurno_.Listar ();
            gvListado.DataBind ();
        }


        #endregion
    }
}