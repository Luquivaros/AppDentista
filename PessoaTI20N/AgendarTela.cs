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
    public partial class Agendar : Form
    {
        DAO bd;
        public Agendar()
        {
            InitializeComponent();
            bd = new DAO();

            ConfigurarGrid();//Estruturar o grid
            NomesDados();//Dar os nomes as colunas
            bd.PreencherVetor();//Consulto o banco de dados
            AdicionarDados();//Inserir linhas na tela
        }//fim do construtor

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }//fim do dataGrid

        public void NomesDados()
        {
            dataGridView1.Columns[0].Name = "CPF";
            dataGridView1.Columns[1].Name = "Nome";
            dataGridView1.Columns[2].Name = "Telefone";
            dataGridView1.Columns[3].Name = "Endereço";
        }//fim do método

        public void AdicionarDados()
        {
            for (int i = 0; i < bd.QuantidadeDados(); i++)
            {
                dataGridView1.Rows.Add(bd.cpf[i], bd.nome[i], bd.telefone[i], bd.endereco[i]);
            }
        }//fim do método

        public void ConfigurarGrid()
        {
            dataGridView1.AllowUserToAddRows = false;//Usuário não adiciona linhas
            dataGridView1.AllowUserToDeleteRows = false;//Usuário não apaga linhas
            dataGridView1.AllowUserToResizeColumns = false;//Usuário não adiciona colunas
            dataGridView1.AllowUserToResizeRows = false;//Usuário modificar linhas
            dataGridView1.ColumnCount = 4;//Quantidade de colunas
        }//fim do método

        private void AgendarTela_Load(object sender, EventArgs e)
        {

        }
    }//fim da classe
}//fim do projeto
