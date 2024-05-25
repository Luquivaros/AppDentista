using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; //Importar o MySQL

namespace PessoaTI20N
{
    class DAO
    {
        public MySqlConnection conexao;
        public long[] cpf;
        public string[] nome;
        public string[] telefone;
        public string[] endereco;
        public int i;
        public int contador;

        public DAO()
        {
            conexao = new MySqlConnection("server=localhost;Database=empresaTI20N;Uid=root;password=");
            try
            {
                conexao.Open();//Abrir a conexão
            }
            catch(Exception ex)
            {
                MessageBox.Show("Algo deu errado!\n\n" + ex);
            }
        }//fim do construtor

        public string Inserir(long cpf, string nome, string telefone, string endereco)
        {
            string inserir = $"Insert into pessoa(cpf, nome, telefone, endereco) values" +
                $"('{cpf}','{nome}','{telefone}','{endereco}')";

            MySqlCommand sql = new MySqlCommand(inserir, conexao);
            string resultado = sql.ExecuteNonQuery() + " Executado!";
            return resultado;
        }//fim do método

        public void PreencherVetor()
        {
            string query = "select * from pessoa";

            //Instanciar
            this.cpf = new long[100];
            this.nome = new string[100];
            this.telefone = new string[100];
            this.endereco = new string[100];

            //Fazer o comando de seleção do banco
            MySqlCommand sql = new MySqlCommand(query, conexao);
            //Leitor do banco
            MySqlDataReader leitura = sql.ExecuteReader();

            i = 0;
            contador = 0;
            while (leitura.Read())
            {
                cpf[i]      = Convert.ToInt64(leitura["cpf"]);
                nome[i]     = leitura["nome"] + "";
                telefone[i] = leitura["telefone"] + "";
                endereco[i] = leitura["endereco"] + "";
                i++;//Percorrer o vetor
                contador++;//Contar quantos dados eu tenho
            }//fim do while

            //Encerro a comunicação com o software
            leitura.Close();
        }//fim do preencher

        //Criar o método para retornar o contador
        public int QuantidadeDados()
        {
            return contador;
        }//fim do quantidade de dados

        public string Atualizar(long cpf, string nomeTabela, string campo, string dado)
        {
            string query = $"update {nomeTabela} set {campo} = '{dado}' where cpf = '{cpf}'";
            MySqlCommand sql = new MySqlCommand(query, conexao);
            string resultado = sql.ExecuteNonQuery() + " Atualizado!";
            return resultado;
        }//fim do método

        public string Excluir(long cpf, string nomeTabela)
        {
            string query = $"delete from {nomeTabela} where CPF = '{cpf}'";
            MySqlCommand sql = new MySqlCommand(query, conexao);
            string resultado = sql.ExecuteNonQuery() + " Excluído!";
            return resultado;
        }//fim do excluir

        // Método para agendar um compromisso para uma pessoa no banco de dados
        public string Agendar(long cpf, DateTime data, string descricao)
        {
            // Monta a query SQL para inserir um novo agendamento na tabela 'agendamento'
            string query = $"Insert into agendamento(cpf_pessoa, data, descricao) values" +
                           $"('{cpf}', '{data.ToString("yyyy-MM-dd HH:mm:ss")}', '{descricao}')";

            // Cria um novo comando MySQL utilizando a query e a conexão
            MySqlCommand sql = new MySqlCommand(query, conexao);

            // Executa o comando SQL e retorna a mensagem de sucesso
            string resultado = sql.ExecuteNonQuery() + " Agendamento criado!";
            return resultado;
        }

        // Método para obter os agendamentos de uma pessoa do banco de dados
        public DataTable ObterAgendamentos(long cpf)
        {
            // Cria um DataTable para armazenar os agendamentos
            DataTable agendamentos = new DataTable();

            try
            {
                // Define as colunas do DataTable
                agendamentos.Columns.Add("Data", typeof(DateTime));
                agendamentos.Columns.Add("Descrição", typeof(string));

                // Query SQL para selecionar os agendamentos da pessoa com o CPF especificado
                string query = $"select data, descricao from agendamento where cpf_pessoa = '{cpf}'";

                // Cria um novo comando MySQL utilizando a query e a conexão
                MySqlCommand sql = new MySqlCommand(query, conexao);

                // Executa o comando SQL e obtém um leitor para ler os resultados
                MySqlDataReader leitura = sql.ExecuteReader();

                // Loop para ler os resultados do leitor
                while (leitura.Read())
                {
                    // Obtém a data e a descrição do agendamento
                    DateTime data = Convert.ToDateTime(leitura["data"]);
                    string descricao = leitura["descricao"].ToString();

                    // Adiciona uma nova linha ao DataTable com a data e a descrição
                    agendamentos.Rows.Add(data, descricao);
                }

                // Fecha o leitor após terminar a leitura
                leitura.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao obter agendamentos: " + ex.Message);
            }

            // Retorna o DataTable com os agendamentos
            return agendamentos;
        }
    }//fim da classe
}//fim do projeto
