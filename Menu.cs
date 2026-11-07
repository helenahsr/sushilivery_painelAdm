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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CadastroEdicao form = new CadastroEdicao();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Listagem form = new Listagem();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ListagemUsuarios form = new ListagemUsuarios();
            form.Show();
        }
    }
}
