import React from 'react';
import logo from './logo.svg';
import './App.css';
import configureStore from './store/configureStore'
import { Provider } from "react-redux";
import ItemPage from './components/item/ItemPage';

const store = configureStore()

function App() {
  return (
    <Provider store={store}>
      <ItemPage />
    </Provider>
  );
}

export default App;
