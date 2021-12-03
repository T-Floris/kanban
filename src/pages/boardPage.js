import React from "react";
import Board from "../components/Kanban/board";
import DropdownNavbar from "../components/DropdownNavbar";
import { Provider } from "react-redux";
import store from "../redux/store";
import styled from "styled-components";

const BoardContainer = styled.div`
//this make the page fixed so you cant scroll vertical
  bottom: 0;
  left: 0;
  margin-bottom: 8px;
  overflow-x: auto;
  overflow-y: hidden;
  padding-bottom: 8px;
  position: absolute;
  right: 0;
  top: 0;
  -webkit-user-select: none;
  user-select: none;
  white-space: nowrap;
`;

const boardPage = () => {
  return (
    <BoardContainer>
      <Provider store={store}> {/*store is required by redux*/}
        <DropdownNavbar />
        <Board />
      </Provider>
    </BoardContainer>
  );
};

export default boardPage;
