CREATE DATABASE laboratorio;
USE laboratorio;

CREATE TABLE alunos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(100),
    matricula VARCHAR(50),
    turma VARCHAR(50)
);