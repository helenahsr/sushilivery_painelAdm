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
    public partial class Listagem : Form
    {
        private readonly Conexao conn = new Conexao();

        public Listagem()
        {
            InitializeComponent();

            dtgvProdutos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvProdutos.MultiSelect = false;
            dtgvProdutos.ReadOnly = true;

            btnEditar.Click += btnEditar_Click;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CadastroEdicao form = new CadastroEdicao();
            form.ShowDialog();

            ExibirProdutos();
        }

        private void Listagem_Load(object sender, EventArgs e)
        {
            ExibirProdutos();
        }

        public void ExibirProdutos() // Método para exibir os produtos na DataGridView com INNER JOIN
        {
            string query = "SELECT P.id, P.nome, P.descricao, P.preco, P.imagem_url, C.nome AS categoria, P.disponivel, P.criado_em " +
                "FROM produtos AS P " +
                "INNER JOIN categorias AS C ON C.id = P.categoria_id " +
                "WHERE P.exc_produto != 1";

            DataTable dt = conn.ExecutarConsulta(query);
            dtgvProdutos.DataSource = dt;
        }

        private void dtgvProdutos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dtgvProdutos.Rows[e.RowIndex].Selected = true;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dtgvProdutos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um produto para editar.");
                return;
            }

            DataGridViewRow linhaSelecionada = dtgvProdutos.SelectedRows[0];

            int idProduto = Convert.ToInt32(linhaSelecionada.Cells["id"].Value);

            CadastroEdicao form = new CadastroEdicao(idProduto);
            form.ShowDialog();

            ExibirProdutos();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dtgvProdutos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um produto para editar.");
                return;
            }

            DataGridViewRow linhaSelecionada = dtgvProdutos.SelectedRows[0];

            int idProduto = Convert.ToInt32(linhaSelecionada.Cells["id"].Value);

            DialogResult resultado = MessageBox.Show("Tem certeza que deseja excluir este produto?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                string query = $"UPDATE produtos SET exc_produto = 1 WHERE id = {idProduto}";
                conn.ExecutarComando(query);
                ExibirProdutos();
            }
        }
    }
}