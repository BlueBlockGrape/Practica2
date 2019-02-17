﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.daos;
using Backend.modelo;
using Backend.util;

namespace Frontend
{
    public partial class Agregar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dateCalendario.SelectedDate = DateTime.Today;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Fichas modeloFicha = new Fichas();
            accionesSQL accion = new accionesSQL();
            validadores val = new validadores();

            List<String> errores = new List<String>();

            if (!val.vNumeroFloat(txtPromedio.Text))
            {
                errores.Add("Verifique el promedio ingresado.");
            }

            if (!val.vNumero(txtFicha.Text))
            {
                errores.Add("Verifique el número de ficha.");
            }

            if (!val.vNombreApellido(txtNombre.Text))
            {
                errores.Add("Verifique el nombre.");
            }

            if (!val.vNombreApellido(txtPaterno.Text))
            {
                errores.Add("Verifique el apellido paterno.");
            }

            if (!val.vNombreApellido(txtMaterno.Text))
            {
                errores.Add("Verifique el apellido materno.");
            }


            if (errores.Count == 0)
            {
                modeloFicha.nombre = txtNombre.Text;
                modeloFicha.a_paterno = txtPaterno.Text;
                modeloFicha.a_materno = txtMaterno.Text;
                modeloFicha.n_ficha = int.Parse(txtFicha.Text);
                modeloFicha.fecha = dateCalendario.SelectedDate;
                modeloFicha.procedencia = txtProcedencia.Text;
                modeloFicha.opc_1 = cboOpcion1.SelectedValue;

                if (cboOpcion2.SelectedValue == "Ninguna")
                {
                    modeloFicha.opc_2 = cboOpcion2.SelectedValue;
                    modeloFicha.opc_3 = "Ninguna";
                }
                else
                {
                    modeloFicha.opc_2 = cboOpcion2.SelectedValue;
                    modeloFicha.opc_3 = cboOpcion3.SelectedValue;
                }

                modeloFicha.promedio = float.Parse(txtPromedio.Text);

                accion.insert(modeloFicha);

                Response.Redirect("Página Principal.aspx");
            }
            else
            {
                foreach (var item in errores)
                {
                    Response.Write(item + "<br />");
                }
            }


            //if (accion.insert(modeloFicha))
            //{
            //    //Response.Redirect("Página Principal.aspx");
            //    //Response.Write("Por fin hiciste algo bien.");
            //}
            //else
            //{
            //    Response.Write("No funciona, igual que tu vida.");
            //}
        }
    }
}