using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace empresaTINT
{
    public partial class Cadastrar : Form
    {
        public Cadastrar()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }//fim do voltar

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//fim da caixa codigo

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }//fim da caixa nome

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }//fim da caixa telefone

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }// fim da caixa endereço

        private void button2_Click(object sender, EventArgs e)
        {
            //Instanciar a classe DAO
            DAO  inserir = new DAO();
            //Coletando os dados dos campos
            int codigo = Convert.ToInt32(textBox1.Text);
            string nome = textBox2.Text;
            string telefone = textBox3.Text;
            string endereco = textBox4.Text;
            //CHamando o metodo inserir
            MessageBox.Show(inserir.Inserir(codigo, nome, telefone , endereco));
            this.Close();//Fechar a janela cadastrar
        }// fim do botao cadastrar
    }// fim da classe
}//fim do projeto
