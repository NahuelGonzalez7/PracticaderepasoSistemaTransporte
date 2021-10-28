using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Datos.AdmModels;
using Entidades;

namespace WebTransportes
{
    public partial class VistaAuto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                mostrarDatos();
                llenarComboMarcas();
                LlenarComboBuscarXMarca();
            }
        }

        public void mostrarDatos()
        {
            gridAutos.DataSource = AdmAuto.Listar();
            gridAutos.DataBind();
        }
        protected void ddlMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        public void llenarComboMarcas()
        {
            DataTable dt = AdmAuto.ListarMarca();

            ddlMarcas.DataSource = dt;
            ddlMarcas.DataValueField = dt.Columns["Marca"].ToString();
            ddlMarcas.DataTextField = dt.Columns["Marca"].ToString();
            ddlMarcas.DataBind(); 
        }

        public void LlenarComboBuscarXMarca()
        {
            DataTable dt = AdmAuto.ListarMarca();
            ddlAutosPorMarca.Items.Add("[TODAS]");
            foreach (DataRow item in dt.Rows)
            {
                ddlAutosPorMarca.Items.Add(item["Marca"].ToString());
            }
        }

        protected void ddlAutosPorMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = ddlAutosPorMarca.SelectedValue;
            if (item == "[TODAS]")
            {
                mostrarDatos();
            }
            else
            {
                gridAutos.DataSource = AdmAuto.Listar(item);
                gridAutos.DataBind();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Auto auto = new Auto()
            {
                Marca = ddlMarcas.SelectedValue,
                Modelo = txtModelo.Text,
                Matricula = txtMatricula.Text,
                Precio = Convert.ToDecimal(txtPrecio.Text)
            };

            int filasAfectas = AdmAuto.Insertar(auto);

            if (filasAfectas > 0)
            {
                mostrarDatos();
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            Auto auto = new Auto()
            {
                ID = Convert.ToInt32(txtID.Text),
                Marca = ddlMarcas.SelectedValue,
                Modelo = txtModelo.Text,
                Matricula = txtMatricula.Text,
                Precio = Convert.ToDecimal(txtPrecio.Text)
            };

            int filasAfectadas = AdmAuto.Modificar(auto);

            if (filasAfectadas > 0)
            {
                mostrarDatos();
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtID.Text);

            int filasAfectadas = AdmAuto.Eliminar(id);

            if (filasAfectadas > 0)
            {
                mostrarDatos();
            }
        }
    }
}