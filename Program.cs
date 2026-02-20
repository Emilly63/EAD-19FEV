using System;
using MySql.Data.MySqlClient;

// --- CONFIGURAÇÃO DA CONEXÃO ---
// Sem senha: deixamos password=""
string server = "localhost";
string database = "laboratorio";
string user = "root";
string password = ""; 
string port = "3306";

string strConexao = $"server={server};database={database};user={user};password={password};port={port};";

using (var conn = new MySqlConnection(strConexao))
{
    try
    {
        Console.WriteLine(">>> Tentando conectar ao MySQL em localhost:3306...");
        conn.Open();
        Console.WriteLine(">>> STATUS: CONECTADO COM SUCESSO!\n");

        // --- PASSO 5 DA ATIVIDADE: INSERINDO UM ALUNO ---
        string sqlInsert = "INSERT INTO alunos (nome, matricula, turma) VALUES (@nome, @mat, @turma)";
        
        using (var cmd = new MySqlCommand(sqlInsert, conn))
        {
            // Substitua pelos seus dados para o print da atividade
            cmd.Parameters.AddWithValue("@nome", "Emilly Aluna");
            cmd.Parameters.AddWithValue("@mat", "20261234");
            cmd.Parameters.AddWithValue("@turma", "Desenvolvimento de Sistemas");

            cmd.ExecuteNonQuery();
            Console.WriteLine("[OK] Dados inseridos com sucesso!");
        }

        // --- PASSO 6 DA ATIVIDADE: CONSULTANDO OS DADOS ---
        Console.WriteLine("\n--- LISTA DE ALUNOS CADASTRADOS ---");
        string sqlSelect = "SELECT * FROM alunos";
        
        using (var cmd = new MySqlCommand(sqlSelect, conn))
        {
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Exibe os dados que estão no MySQL
                    Console.WriteLine($"ID: {reader["id"]} | Nome: {reader["nome"]} | Matrícula: {reader["matricula"]}");
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine("\n[ERRO DE CONEXÃO]");
        Console.WriteLine("Mensagem: " + ex.Message);
        Console.WriteLine("\nDICA: Verifique se o MySQL Workbench está aberto e o serviço está rodando.");
    }
}

Console.WriteLine("\nPressione qualquer tecla para encerrar...");
Console.ReadKey();