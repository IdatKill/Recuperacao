import { useEffect, useState } from "react";
import axios from "axios";

interface Imc {
  id: number;
  aluno: { nome: string; sobrenome: string };
  altura: number;
  peso: number;
  valor: number;
  classificacao: string;
  dataCriacao: string;
}

export default function ImcListar() {
  const [imcs, setImcs] = useState<Imc[]>([]);

  useEffect(() => {
    const fetchImcs = async () => {
      const response = await axios.get("/api/imc/listar");
      setImcs(response.data);
    };
    fetchImcs();
  }, []);

  return (
    <div>
      <h1>Lista de IMCs</h1>
      <table border={1}>
        <thead>
          <tr>
            <th>ID</th>
            <th>Nome</th>
            <th>Sobrenome</th>
            <th>Altura</th>
            <th>Peso</th>
            <th>IMC</th>
            <th>Classificação</th>
            <th>Data de Criação</th>
          </tr>
        </thead>
        <tbody>
          {imcs.map((imc) => (
            <tr key={imc.id}>
              <td>{imc.id}</td>
              <td>{imc.aluno.nome}</td>
              <td>{imc.aluno.sobrenome}</td>
              <td>{imc.altura}</td>
              <td>{imc.peso}</td>
              <td>{imc.valor.toFixed(2)}</td>
              <td>{imc.classificacao}</td>
              <td>{new Date(imc.dataCriacao).toLocaleDateString()}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

