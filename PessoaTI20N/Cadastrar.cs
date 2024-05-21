using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PessoaTI20N
{
    public partial class Cadastrar : Form
    {
        DAO bd;
        public Cadastrar()
        {
            InitializeComponent();
            bd = new DAO();
        }//fim do contrutor

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//fim do campo CPF

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }//fim do nome

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }//fim do telefone

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }//fim do endereço

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Coletar os dados do banco
                long cpf = Convert.ToInt64(textBox1.Text);
                string nome = textBox2.Text;
                string telefone = textBox3.Text;
                string endereco = textBox4.Text;
                //Cadastrar
                MessageBox.Show(bd.Inserir(cpf, nome, telefone, endereco));//Insere dados no BD
                                                                           //Limpar a tela
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }catch(Exception ex)
            {
                MessageBox.Show("Algo deu errado!\n\n" + ex);
            }
        }//fim do botão cadastrar

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }//fim do botão cancelar
    }//fim da classe
}//fim do projeto
