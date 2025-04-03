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
        public int contador;
        public DAO()
        {
            conexao = new MySqlConnection("server=localhost;Database=tintCsharp;Uid=root;password=");
            try
            {
                conexao.Open();//tentando conectar com o banco 
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
            contador = 0;
            while(leitura.Read())
            {
                codigo[i] = Convert.ToInt32(leitura["codigo"]);
                nome[i] = leitura["nome"] + "";
                telefone[i] = leitura["telefone"] + "";
                endereco[i] = leitura["endereco"] + "";
                i++;//contador gire
                contador++;
            }// fim do while
            //Encerrar o processo de leitura
            leitura.Close();
        }//fim do metodo 

        public int ConsultarPorCodigo(int cod)
        {
            PreencherVetor() ; // PREENCHENDO VETOR COM OS DADOS DO BANCO
            i = 0 ;

            while (i < QuantidadeDeDados())
            {
                if (codigo[i] == cod)
                {
                    return i;
                }
                i++;//contador gire
            }// fim do while
            return -1;
        }//fim do metodo 


        public string RetornarNome(int cod)
        {
            int posicao = ConsultarPorCodigo(cod);
            if (posicao > -1)
            {
                return nome[posicao];
            }
            return "Código digitado não é valido!";
        }//fim do retornar nome

        public string RetornarTelefone(int cod)
        {
            int posicao = ConsultarPorCodigo(cod);
            if (posicao > -1)
            {
                return telefone[posicao];
            }
            return "Código digitado não é valido!";
        }//fim do retornar telefone

        public string RetornarEndereco(int cod)
        {
            int posicao = ConsultarPorCodigo(cod);
            if (posicao > -1)
            {
                return endereco[posicao];
            }
            return "Código digitado não é valido!";
        }//fim do retornarendereco


        public int QuantidadeDeDados()
        {
            return contador;
        }// fim do método

        public string Atualizar(int codigo, string campo, string dado)
        {
            string query = $"update pessoa set {campo} = '{dado}' where codigo = codigo";
            MySqlCommand sql = new MySqlCommand(query, conexao);
            string resultado = sql.ExecuteNonQuery() + "Atualizado!";
            return resultado;

        }//fim do atualizar

        public string Excluir(int codigo)
        {
            string query = $"delete from pessoa where codigo = '{codigo}'";
            MySqlCommand sql = new MySqlCommand(query, conexao);
            string  resultado = sql.ExecuteNonQuery() + "Deletado";
            return resultado;
        }// fim do excluir 
    }// fim da classe
}// fim do projeto
