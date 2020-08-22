import React from 'react';
import logo from './logo.svg';
import './App.css';
import { store } from "./actions/store";
import { Provider } from "react-redux";
import Portfolios from './components/Portfolios';

function App() {
  return (
    <Provider store={store}>
      <Portfolios />
    </Provider>
  );
}

export default App;
