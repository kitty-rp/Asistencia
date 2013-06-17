using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asistencia.Presentacion.Turno
{
    public partial class Formulario : System.Web.UI.Page
    {

        #region Variables privadas

        private Asistencia.Negocio.Turno NTurno_ = new Asistencia.Negocio.Turno ();

        #endregion

        #region eventos

        protected void Page_Load ( object sender, EventArgs e )
        {
            if ( !IsPostBack )
            {
                if ( !string.IsNullOrEmpty ( Request["id"] ) )
                {
                    cargarDatos ();
                    cargarHorarios ();
                    pHor1.Visible = true;
                    pHor2.Visible = true;
                }
            }
        }


        protected void lbGuardar_Click ( object sender, EventArgs e )
        {
            if ( tCod.Text == "" )
                insertar ();
            else
                modificar ();
        }

        protected void lbAddH_Click ( object sender, EventArgs e )
        {
            insertarHorario ();
        }

        protected void gvHorario_RowCommand ( object sender, GridViewCommandEventArgs e )
        {
            if ( e.CommandName == "EliminarH" )
            {
                NTurno_.EliminarHorario ( int.Parse ( e.CommandArgument.ToString () ) );
                cargarHorarios ();
            }
        }

        #endregion

        #region Metodos privados

        private void cargarDatos ()
        {
            System.Data.DataRow o = NTurno_.Obtener ( int.Parse ( Request["id"] ) );
            tCod.Text = o[0].ToString ();
            tDesc.Text = o[1].ToString ();
        }

        private void cargarHorarios ()
        {
            gvHorario.DataSource = NTurno_.ListarHorarioDeTurno ( int.Parse ( tCod.Text ) );
            gvHorario.DataBind ();
        }

        private void insertarHorario ()
        {
            NTurno_.InsertarHorario ( ddDia.SelectedValue, DateTime.Parse ( "2012/12/12 " + tHIni.Text + ":" + tMIni.Text ), DateTime.Parse ( "2012/12/12 " + tHFin.Text + ":" + tMFin.Text ), int.Parse ( tCod.Text ) );
            cargarHorarios ();
        }

        private void insertar ()
        {
            try
            {
                int id = NTurno_.Insertar ( tDesc.Text );
                Response.Redirect ( "Formulario.aspx?id=" + id.ToString () );
            }
            catch ( Exception )
            {
            }
        }

        private void modificar ()
        {
            try
            {
                NTurno_.Actualizar ( int.Parse ( tCod.Text ), tDesc.Text );
                Response.Redirect ( "Listado.aspx" );
            }
            catch ( Exception )
            {
            }
        }

        #endregion
    }
}