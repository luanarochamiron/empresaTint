using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace empresaTINT
{
    public partial class Consultar : Form
    {
        DAO consul;
        public Consultar()
        {
            consul = new DAO();
            InitializeComponent();
            ConfigurarDataGrid();
            NomeColunas(); //nomemando as colunas
            AdicionarDados();//Adiconando os dados para visualizar
        }//fim do construtor

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void consultarNovo_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }//fim do voltar

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void NomeColunas()
        {
            dataGridView1.Columns[0].Name = "Código";
            dataGridView1.Columns[1].Name = "Nome";
            dataGridView1.Columns[2].Name = "Telefone";
            dataGridView1.Columns[3].Name = "Endereço";
        }//fim nome colunas

        public void ConfigurarDataGrid()
        {
            dataGridView1.AllowUserToAddRows = false; // nao pode adicionar linhas 
            dataGridView1.AllowUserToDeleteRows = false; // ele nao pode apagar linhas 
            dataGridView1.AllowUserToResizeColumns = false;// nao pode redimensaionar as colunas 
            dataGridView1.AllowUserToResizeRows = false; // nao pode redimensaionar as linhas 

            dataGridView1.ColumnCount = 4;
        }// configurar data grid

        public void AdicionarDados()
        {
            consul.PreencherVetor();//Preencher os vetores c/ dados do bd
            for(int i = 0; i < consul.QuantidadeDeDados(); i++) 
            {
                dataGridView1.Rows.Add(consul.codigo[i], consul.nome[i], consul.telefone[i], consul.endereco[i]);

            }//fim do for


        }// Fim do adicionar dados

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }// fim do data grid view
    }// fim da classe
}// fim do projeto
