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
    public partial class Excluir : Form
    {
        DAO bd;
        public Excluir()
        {
            InitializeComponent();
            bd = new DAO();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }//fim do campo excluir

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                long cpf = Convert.ToInt64(textBox1.Text);//Coletando o CPF
                                                          //Chamar o método
                MessageBox.Show(bd.Excluir(cpf, "pessoa"));
                //limpando o banco
                textBox1.Text = "";
            }catch(Exception ex)
            {
                MessageBox.Show("Algo deu errado!\n\n" + ex);
            }
        }//fim do botão excluir

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }//fim do botão cancelar
    }//fim da classe
}//fim do projeto
