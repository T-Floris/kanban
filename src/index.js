import React from "react";
import ReactDOM from "react-dom";
import App from "./App";
import Board from "./components/Kanban/board";
import { Provider } from "react-redux";
import store from "./redux/store";

ReactDOM.render(
  <React.StrictMode>
    {/* <Provider store={store}> */}
      <App />
      {/* <Board />
    </Provider> */}
  </React.StrictMode>,
  document.getElementById("root")
);
