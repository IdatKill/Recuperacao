import { useState } from "react";
import axios from "axios";

export default function ImcAlterar() {
  const [imcId, setImcId] = useState(0);
  const [altura, setAltura] = useState(0);
  const [peso, setPeso] = useState(0);

  const fetchImc = async () => {
    const response = await axios.get(`/api/imc/listarporaluno/${imcId}`);
    const imc = response.data;
    setAltura(imc.altura);
    setPeso(imc.peso);
  };

  const alterarImc = async () => {
    await axios.put(`/api/imc/alterar/${imcId}`, { altura, peso });
  };

  return (
    <div>
      <h1>Alterar IMC</h1>
      <input
        type="number"
        placeholder="ID do IMC"
        value={imcId}
        onChange={(e) => setImcId(Number(e.target.value))}
      />
      <button onClick={fetchImc}>Carregar Dados</button>
      <div>
        <input
          type="number"
          placeholder="Altura"
          value={altura}
          onChange={(e) => setAltura(Number(e.target.value))}
        />
        <input
          type="number"
          placeholder="Peso"
          value={peso}
          onChange={(e) => setPeso(Number(e.target.value))}
        />
        <button onClick={alterarImc}>Salvar</button>
      </div>
    </div>
  );
}

