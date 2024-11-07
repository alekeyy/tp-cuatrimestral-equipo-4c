﻿using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace expresssolution
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                dgvListaUsuarios.DataSource = negocio.listar();
                dgvListaUsuarios.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void dgvListaUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Session.Add("IdAModificar", dgvListaUsuarios.AccessKey.ToString());
                Response.Redirect("Perfil.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}