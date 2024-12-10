import { useState, useEffect } from "react";
import axios from "axios";

interface Imc {
  id: number;
  altura: number;
  peso: number;
  valor: number;
  classificacao: string;
  dataCriacao: string;
}

export default function ImcListarPorAluno() {
  const [alunoId, setAlunoId] = useState(0);
  const [imcs, setImcs] = useState<Imc[]>([]);

  const fetchImcs = async () => {
    const response = await axios.get(`/api/imc/listarporaluno/${alunoId}`);
    setImcs(response.data);
  };

  return (
    <div>
      <h1>Listar IMCs por Aluno</h1>
      <input
        type="number"
        placeholder="ID do Aluno"
        value={alunoId}
        onChange={(e) => setAlunoId(Number(e.target.value))}
      />
      <button onClick={fetchImcs}>Buscar</button>
      {imcs.length > 0 && (
        <table border={1}>
          <thead>
            <tr>
              <th>ID</th>
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
                <td>{imc.altura}</td>
                <td>{imc.peso}</td>
                <td>{imc.valor.toFixed(2)}</td>
                <td>{imc.classificacao}</td>
                <td>{new Date(imc.dataCriacao).toLocaleDateString()}</td>
              </tr>
            ))}
          </tbody>
        </table>
      )}
    </div>
  );
}

