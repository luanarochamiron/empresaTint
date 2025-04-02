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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DAO conexao = new DAO();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }//fim do form load

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cadastrar cad = new Cadastrar();
            cad.ShowDialog();  
        }//fim do botão cadastrar 

        private void Consultar_Click(object sender, EventArgs e)
        {
            Consultar con = new Consultar();
            con.ShowDialog();

        }//fim do consultar 

        private void Atualizar_Click(object sender, EventArgs e)
        {
            Atualizar Atu= new Atualizar();
            Atu.ShowDialog();

        }//fim do atualizar

        private void Excluir_Click(object sender, EventArgs e)
        {
            Excluir Exu = new Excluir();
            Exu.ShowDialog();

        }//Fim do excluir
    }//fim da classe
} //Fim do projeto
