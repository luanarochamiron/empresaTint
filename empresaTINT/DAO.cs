using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace empresaTINT
{
    class DAO
    {
        public MySqlConnection conexao;
        public int[] codigo;
        public string[] nome;
        public string[] telefone;
        public string[] endereco;
        public int i;
        public DAO()
        {
            conexao = new MySqlConnection("server=localhost;Database=tintCsharp;Uid=root;password=");
            try
            {
                conexao.Open();//tentando conectar com o banco 
                MessageBox.Show("Conectado !!!");
            } catch (Exception erro)
            {
                MessageBox.Show("Algo deu errado\n\n\n" + erro);
            }
        }// Fim do construtor

        public string Inserir(int codigo, string nome, string telefone, string endereco)
        {
            string inserir = $"Insert into pessoa(codigo,nome,telefone,endereco) values('{codigo}','{nome}','{telefone}','{endereco}')";
            MySqlCommand sql = new MySqlCommand(inserir, conexao);
            string resultado = sql.ExecuteNonQuery() + "Executado";
            return resultado;
        }

        public void PreencherVetor()
        {
            string query = "select * from Pessoa";
            //Instanciar os vetores
            this.codigo = new int[100];
            this.nome = new string[100];
            this.telefone = new string[100];
            this.endereco = new string[100];

            //prepara o comando para o banco 
            MySqlCommand sql = new MySqlCommand(query, conexao);
            //chamar o leitor do banco de dados 
            MySqlDataReader leitura = sql.ExecuteReader();
            i = 0;// Instanciando um contador 
            while(leitura.Read())
            {
                codigo[i] = Convert.ToInt32(leitura["codigo"]);
                nome[i] = leitura["nome"] + "";
                telefone[i] = leitura["telefone"] + "";
                endereco[i] = leitura["endereco"] + "";
                i++;//contador gire

            }// fim do while
            //Encerrar o processo de leitura
            leitura.Close();
        }//fim do metodo 



    }// fim da classe
}// fim do projeto
