using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sushilivery_painelAdm
{
    public partial class ListagemUsuarios : Form
    {
        Conexao conn = new Conexao();
        public ListagemUsuarios()
        {
            InitializeComponent();
        }

        public void ExibirUsuarios()
        {
            string query = "SELECT * FROM usuarios";

            DataTable dt = conn.ExecutarConsulta(query);
            dtgvUsuarios.DataSource = dt;
        }

        private void ListagemUsuarios_Load(object sender, EventArgs e)
        {
            ExibirUsuarios();
        }
    }
}
