import { useState } from "react";
import axios from "axios";

export default function AlunoCadastrar() {
  const [nome, setNome] = useState("");
  const [sobrenome, setSobrenome] = useState("");

  const cadastrarAluno = async () => {
    await axios.post("/api/aluno/cadastrar", { nome, sobrenome });
  };

  return (
    <div>
      <input placeholder="Nome" value={nome} onChange={(e) => setNome(e.target.value)} />
      <input placeholder="Sobrenome" value={sobrenome} onChange={(e) => setSobrenome(e.target.value)} />
      <button onClick={cadastrarAluno}>Cadastrar</button>
    </div>
  );
}

