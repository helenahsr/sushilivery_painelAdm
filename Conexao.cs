using MySql.Data.MySqlClient;       //Habilita o uso dos  métodos para conexão com BD MySQl
using System;
using System.Data;                  //Habilita o uso da classe DataTable (tabela de dados)

namespace sushilivery_painelAdm
{
    internal class Conexao
    {
        MySqlConnection conexao;    //Objeto para estabelecer uma conexão com o banco de dados MySQL

        public void Conectar()  // Criação do método que conecta a um banco de dados.
        {
            try
            {
                string stringConexao = "Persist Security Info = false; " +      //garante segurança de senhas
                                       "server      = localhost; " +            //em qual servidor se encontra o BD
                                       "database    = sushi_delivery; " +       //nome do BD
                                       "uid         = root; " +                 //usuário para acessar o BD
                                       "pwd         ='';";

                conexao = new MySqlConnection(stringConexao);   //Estabelece a conexão
                conexao.Open();     //Abre a conexão
            }
            catch (MySqlException ex)
            {
                throw new Exception("Não foi possível conectar ao banco de dados.\n" + ex.Message);
            }
        }

        public DataTable ExecutarConsulta(string sql)   //parâmetro sql: deve conter uma instrução Select
        {
            try
            {
                Conectar();
                MySqlDataAdapter dados = new MySqlDataAdapter(sql, conexao); //Representa um conjunto de comandos de dados.
                DataTable dt = new DataTable(); //criação de uma tabela temporária na memória para conter os dados do select.
                dados.Fill(dt);    //Preenchimento do objeto DataTable(dt) com os dados obtidos da execução do select.

                return dt;
            }
            catch (MySqlException ex)
            {
                throw new Exception("Não foi possível executar a CONSULTA solicitada.\n" + ex.Message);
            }
            finally
            {
                conexao.Close();
            }
        }

        public void ExecutarComando(string sql)     //parâmetro sql: instrução sql de INSERT, UPDATE ou DELETE
        {
            Conectar();

            try
            {
                MySqlCommand comando = new MySqlCommand(sql, conexao);      //vincula a instrução sql à conexão aberta
                comando.ExecuteNonQuery();      //Método responsável por executar a instrução sql
            }
            catch (MySqlException ex)
            {
                throw new Exception("A instrução não foi realizada.\n" + ex.Message);
            }
            finally
            {
                conexao.Close();        //Importante para que o banco não fique vulnerável.
            }
        }

    }
}
