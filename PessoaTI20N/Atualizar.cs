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
    public partial class Atualizar : Form
    {
        DAO bd;
        public Atualizar()
        {
            InitializeComponent();
            bd = new DAO();
        }//fim do construtor

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }//fim do campo CPF

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//fim do campo

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }//fim do dado

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Coletar os dados
                long cpf = Convert.ToInt64(textBox3.Text);
                string campo = textBox1.Text;
                string dado = textBox2.Text;
                //Atualizar os dados
                MessageBox.Show(bd.Atualizar(cpf, "pessoa", campo, dado));
                //Limpar os campos
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }catch(Exception ex)
            {
                MessageBox.Show("Algo deu errado!\n\n" + ex);
            }
        }//fim do botão atualizar

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }//fim do botão cancelar
    }//fim do projeto
}//fim da classe
