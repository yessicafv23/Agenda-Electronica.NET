using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AgendaElectronica
{
    public partial class agenda : Form
    {
        public agenda()
        {
            InitializeComponent();
        }

        // Registrar contacto
        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            string codigo = textId.Text;
            string nombre = textNombre.Text;
            string apellido = textApellido.Text;
            string telefono = textTelefono.Text;
            string correo = textEmail.Text;

            string cadenaSQL = "INSERT INTO contacto (id, nombre, apellido, telefono, email)" +
                "VALUES("+codigo+",'"+nombre+"','"+apellido+"','"+telefono+"','"+correo+"')";

            SqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open(); // Abrir la base de datos

            try
            {
                SqlCommand cmd = new SqlCommand(cadenaSQL, conexionBD);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Contacto registrado correctamente");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al registrar el contacto. " + ex);
            }
            finally
            {
                conexionBD.Close();
            }

        }

        // Buscar contacto
        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            string codigo = textId.Text;

            SqlDataReader consulta = null; // Consultas utlizar select

            string cadenaSQL = "SELECT * FROM contacto WHERE id = "+codigo+"";
            SqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open(); // Abrir la base de datos

            try
            {
                SqlCommand cmd = new SqlCommand(cadenaSQL, conexionBD);
                consulta = cmd.ExecuteReader();

                if (consulta.HasRows) // Verificar si hay registros
                {
                    while (consulta.Read())
                    {

                        textNombre.Text = consulta.GetString(1);
                        textApellido.Text = consulta.GetString(2);
                        textTelefono.Text = consulta.GetString(3);
                        textEmail.Text = consulta.GetString(4);
                    }
                }
                else
                {
                    MessageBox.Show("No hay registros");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error en la tabla. " + ex);
            }
            finally 
            {
                conexionBD.Close();
            }
        }

        //Editar
        private void buttonEditar_Click(object sender, EventArgs e)
        {
            string codigo = textId.Text;
            string nombre = textNombre.Text;
            string apellido = textApellido.Text;
            string telefono = textTelefono.Text;
            string correo = textEmail.Text;

            string cadenaSQL = "UPDATE contacto SET id = " + codigo + ", nombre = '" + nombre + "', apellido = '" + apellido + "', telefono = '" + telefono + "', email = '" + correo + "' WHERE id = "+ codigo;

            SqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open(); // Abrir la base de datos

            try
            {
                SqlCommand cmd = new SqlCommand(cadenaSQL, conexionBD);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Contacto actualizado correctamente");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al actualizar  el contacto. " + ex);
            }
            finally
            {
                conexionBD.Close();
            }

        }

        // Eliminar
        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            string codigo = textId.Text;

            string cadenaSQL = "DELETE FROM contacto WHERE id = " + codigo;

            SqlConnection conexionBD = Conexion.conexion();
            conexionBD.Open(); // Abrir la base de datos

            try
            {
                SqlCommand cmd = new SqlCommand(cadenaSQL, conexionBD);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Contacto eliminado correctamente");
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al eliminar  el contacto. " + ex);
            }
            finally
            {
                conexionBD.Close();
            }
        }

        private void buttonLimpiar_Click(object sender, EventArgs e)
        {
            textId.Text = "";
            textNombre.Text = "";
            textApellido.Text = "";
            textTelefono.Text = "";
            textEmail.Text = "";
        }

    }
}
