import React, { useEffect, useState } from "react";
import { Aluno } from "../Models/aluno";
import axios from "axios";  

const ListarAlunos = () => {

    const [alunos, setAlunos] = useState<Aluno[]>([]);

    useEffect(() => {
        carregarAlunos();
    }, []);

function carregarAlunos() {
  //FETCH ou AXIOS
  fetch("http://localhost:5128/api/alunos/")
    .then((resposta) => resposta.json())
    .then((aluno: Aluno[]) => {
      console.table(aluno);
      setAlunos(aluno);
    });
}


  return (
    <div>
      <h1>Listar Alunos</h1>
      <table border={1}>
        <thead>
          <tr>
            <th>#</th>
            <th>Nome</th>
            <th>Sobrenome</th>
            <th>Criado Em</th>
          </tr>
        </thead>
        <tbody>
          {alunos.map((aluno: any) => (
            <tr key={aluno.alunoId}>
              <td>{aluno.alunoId}</td>
              <td>{aluno.nome}</td>
              <td>{aluno.criadoEm}</td>
              <td>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default ListarAlunos;
    function carregarAlunos() {
        throw new Error("Function not implemented.");
    }

