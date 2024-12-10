import React from "react";
import ListarAlunos from "./components/listar-aluno";
import { BrowserRouter, Link, Routes, Route } from "react-router-dom";

function App() {
  return (
    <div id="app">
      <BrowserRouter>
        <nav>
          <ul>
            <li>
              <Link to="/alunos">Alunos</Link>
            </li>
          </ul>
        </nav>
        <Routes>
          <Route path="/alunos" element={<ListarAlunos />} />
          <Route
              path="/pages/tarefa/listar"
              element={<ListarAlunos />}
            />
        </Routes>
      </BrowserRouter>
    </div>
  );
}

export default App;
