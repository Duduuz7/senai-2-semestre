import React from "react";
//Import dos componentes de rota

import { BrowserRouter, Routes, Route } from "react-router-dom";

//Import das páginas

import HomePage from "./pages/HomePage/HomePage";
import LoginPage from "./pages/LoginPage/LoginPage";
import ProdutoPage from "./pages/ProdutoPage/ProdutoPage";


const Rotas = () => {
  return (
    //criar estrutura das rotas
    <BrowserRouter>
      <Routes>
        <Route element={<HomePage />} path="/" exact />
        <Route element={<LoginPage />} path="/login" />
        <Route element={<ProdutoPage />} path="/produto" />
      </Routes>
    </BrowserRouter>
  );
};

export default Rotas;
