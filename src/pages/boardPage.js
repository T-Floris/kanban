import React from "react";
import Board from "../components/Kanban/board";
import { Provider } from "react-redux";
import store from "../redux/store";

const boardPage = () => {
  return (
    <>
      <Provider store={store}>
        
        <Board />
      </Provider>
    </>
  );
};

export default boardPage;
