using MySql.Data.MySqlClient;
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
    public partial class CadastroEdicao : Form
    {
        Conexao conn = new Conexao();
        private readonly int? idProduto;

        public CadastroEdicao()
        {
            InitializeComponent();
        }

        public CadastroEdicao(int idProduto)
        {
            InitializeComponent();

            this.idProduto = idProduto;
            button1.Text = "SALVAR ALTERAÇÕES";
            label6.Text = "EDITAR PRODUTO";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string descricao = txtDescricao.Text;
            string imagemUrl = txtImagemUrl.Text;

            double preco = double.Parse(txtPreco.Text);
            int idCategoria = Convert.ToInt32(cmbCategoria.SelectedValue);

            string precoFormatado = preco.ToString("F2", System.Globalization.CultureInfo.InvariantCulture);

            string nomeBanco = nome.Replace("'", "''");
            string descricaoBanco = descricao.Replace("'", "''");
            string imagemUrlBanco = imagemUrl.Replace("'", "''");

            string query;

            if (idProduto.HasValue)
            {
                query = $"UPDATE produtos SET " +
                        $"nome = '{nomeBanco}', " +
                        $"descricao = '{descricaoBanco}', " +
                        $"preco = '{precoFormatado}', " +
                        $"imagem_url = '{imagemUrlBanco}', " +
                        $"categoria_id = '{idCategoria}' " +
                        $"WHERE id = {idProduto.Value}";
            }
            else
            {
                query = $"INSERT INTO produtos " +
                        $"(nome, descricao, preco, imagem_url, categoria_id, disponivel) " +
                        $"VALUES " +
                        $"('{nomeBanco}', '{descricaoBanco}', '{precoFormatado}', " +
                        $"'{imagemUrlBanco}', '{idCategoria}', '1')";
            }

            try
            {
                conn.ExecutarComando(query);

                MessageBox.Show(
                    idProduto.HasValue
                        ? "Produto alterado com sucesso!"
                        : "Produto cadastrado com sucesso!");

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PreencherComboBox()
        {
            string connectionString = "server=localhost;database=sushi_delivery;uid=root;pwd=;";
            string query = "SELECT id, nome FROM categorias ORDER BY nome ASC";

            using (MySqlConnection conexao = new MySqlConnection(connectionString))
            {
                try
                {
                    conexao.Open();

                    using (MySqlCommand comando = new MySqlCommand(query, conexao))
                    {
                        using (MySqlDataAdapter adaptador = new MySqlDataAdapter(comando))
                        {
                            DataTable tabelaDados = new DataTable();
                            adaptador.Fill(tabelaDados);
                            cmbCategoria.DataSource = tabelaDados;
                            cmbCategoria.DisplayMember = "nome";
                            cmbCategoria.ValueMember = "id";
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar os dados: " + ex.Message);
                }
            }
        }

        private void CarregarProduto()
        {
            string query =
                $"SELECT nome, descricao, preco, imagem_url, categoria_id " +
                $"FROM produtos " +
                $"WHERE id = {idProduto.Value}";

            DataTable tabela = conn.ExecutarConsulta(query);

            if (tabela.Rows.Count == 0)
            {
                MessageBox.Show("Produto não encontrado.");
                Close();
                return;
            }

            DataRow produto = tabela.Rows[0];

            txtNome.Text = produto["nome"].ToString();
            txtDescricao.Text = produto["descricao"].ToString();
            txtPreco.Text = produto["preco"].ToString();
            txtImagemUrl.Text = produto["imagem_url"].ToString();

            cmbCategoria.SelectedValue = Convert.ToInt32(produto["categoria_id"]);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            PreencherComboBox();

            if (idProduto.HasValue)
            {
                CarregarProduto();
            }
        }

    }
}
