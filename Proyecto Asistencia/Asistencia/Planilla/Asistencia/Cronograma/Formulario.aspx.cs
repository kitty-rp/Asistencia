using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Asistencia.Presentacion.Cronograma
{
    public partial class Formulario : System.Web.UI.Page
    {

        #region Variables privadas

        private Asistencia.Negocio.Cronograma NCronograma_ = new Asistencia.Negocio.Cronograma ();
        private Asistencia.Negocio.Turno NTurno_ = new Asistencia.Negocio.Turno ();

        #endregion

        #region eventos

        protected void Page_Load ( object sender, EventArgs e )
        {
            if ( !IsPostBack )
            {
                txtFechaIni.Text = DateTime.Now.ToString ( "dd/MM/yyyy" );
                txtFechaFin.Text = DateTime.Now.ToString ( "dd/MM/yyyy" );

                if ( !string.IsNullOrEmpty ( Request["id"] ) )
                {
                    cargarDatos ();
                    CargarCombo ();
                    cargarTurnos ();
                    pHor1.Visible = true;
                    pHor2.Visible = true;
                }
            }
        }

        protected void gvHorario_RowCommand ( object sender, GridViewCommandEventArgs e )
        {
            if ( e.CommandName == "EliminarC" )
            {
                NCronograma_.EliminarCronogramaTurno ( int.Parse ( e.CommandArgument.ToString () ) );
                cargarTurnos ();
                //t.EliminarHorario(int.Parse(e.CommandArgument.ToString()));
                //cargarHorarios();
            }
        }

        protected void lbtnGuardar_Click ( object sender, EventArgs e )
        {
            if ( txtCodigo.Text == "" )
                insertar ();
            else
                modificar ();
        }

        protected void lbAddH_Click ( object sender, EventArgs e )
        {
            insertarTurno ();
        }

        #endregion

        #region Metodos privados

        private void cargarDatos ()
        {
            System.Data.DataRow o = NCronograma_.Obtener ( int.Parse ( Request["id"] ) );
            txtCodigo.Text = o[0].ToString ();
            txtDescripcion.Text = o[1].ToString ();
            txtFechaIni.Text = o[2].ToString ();
            txtFechaFin.Text = o[3].ToString ();
        }

        private void cargarTurnos ()
        {
            gvTurnos.DataSource = NCronograma_.ListarDeCronograma ( int.Parse ( txtCodigo.Text ) );
            //gvHorario.DataSource = t.ListarHorarioDeTurno(int.Parse(txtCodigo.Text));
            //gvHorario.DataBind();
            gvTurnos.DataBind ();

        }

        private void insertarTurno ()
        {
            DateTime dtIni = DateTime.Parse ( txtFechaIni.Text );
            Negocio.Turno gt = new Negocio.Turno ();
            System.Data.DataTable t = gt.ListarHorarioDeTurno ( int.Parse ( ddlTurno.SelectedValue ) );
            while ( dtIni <= DateTime.Parse ( txtFechaFin.Text ) )
            {
                if ( existeDia ( t, dtIni.DayOfWeek.ToString () ) )
                    NCronograma_.InsertarCronogramaTurno ( dtIni, 1, int.Parse ( txtCodigo.Text ), int.Parse ( ddlTurno.SelectedValue ) );
                dtIni = dtIni.AddDays ( 1 );

            }
            //c.InsertarCronogramaTurno(DateTime.Parse (txtFechaIni.Text),DateTime.Parse(txtFechaFin.Text),1,int.Parse(txtCodigo.Text),int.Parse(ddlTurno.SelectedValue));
            cargarTurnos ();
        }

        private bool existeDia ( System.Data.DataTable t, string dia )
        {
            if ( dia.ToLower () == "monday" )
                dia = "lunes";
            if ( dia.ToLower () == "tuesday" )
                dia = "martes";
            if ( dia.ToLower () == "wednesday" )
                dia = "miércoles";
            if ( dia.ToLower () == "thursday" )
                dia = "jueves";
            if ( dia.ToLower () == "friday" )
                dia = "viernes";
            if ( dia.ToLower () == "saturday" )
                dia = "sábado";
            if ( dia.ToLower () == "sunday" )
                dia = "domingo";
            for ( int i = 0; i < t.Rows.Count; i++ )
                if ( t.Rows[i][1].ToString ().ToLower () == dia )
                    return true;
            return false;
        }

        private void insertar ()
        {
            try
            {
                int id = NCronograma_.Insertar ( txtDescripcion.Text, DateTime.Parse ( txtFechaIni.Text ), DateTime.Parse ( txtFechaFin.Text ) );
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
                NCronograma_.Actualizar ( int.Parse ( txtCodigo.Text ), txtDescripcion.Text, DateTime.Parse ( txtFechaIni.Text ), DateTime.Parse ( txtFechaFin.Text ) );
                Response.Redirect ( "Listado.aspx" );
            }
            catch ( Exception )
            {
            }
        }

  
        private void CargarCombo ()
        {
            ddlTurno.DataSource = NTurno_.Listar ();
            ddlTurno.DataValueField = "id";
            ddlTurno.DataTextField = "descricion";
            ddlTurno.DataBind ();
        }

        #endregion

    }
}