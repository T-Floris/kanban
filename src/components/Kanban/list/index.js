import React from "react";
import TrelloCard from "../card";
import TrelloActionButton from "../actionButton";
import { Droppable, Draggable } from "react-beautiful-dnd";
import styled from "styled-components";

const ListContainer = styled.div`
  background-color: #dfe3e6;
  border-radius: 3px;
  width: 300px;
  padding: 8px;
  margin-right: 8px;
  height: 100%; //important: makes the list prolong when clicked and shrinks when not, and fixes the problem of all lists prolong with clicked on 1 list
`;
const CardContainer = styled.div`
  overflow-y: auto; //display scroll when needed
  overflow-x: hidden; // hidding horizontal scroll
  max-height: 610px;
`;

const TrelloList = ({ title, cards, listID, index }) => {
  console.log(cards);
  return (
    <Draggable draggableId={String(listID)} index={index}>
      {(provided) => (
        <ListContainer
          {...provided.draggableProps}
          ref={provided.innerRef}
          {...provided.dragHandleProps}
        >
          <Droppable droppableId={String(listID)}>
            {(provided) => (
              <div {...provided.droppableProps} ref={provided.innerRef}>
                <h4>{title}</h4>
                <CardContainer>
                  {cards.map((card, index) => (
                    <TrelloCard
                      key={card.id}
                      index={index}
                      text={card.text}
                      id={card.id}
                    />
                  ))}
                  {provided.placeholder}
                  
                </CardContainer>
                <TrelloActionButton listID={listID} />
              </div>
            )}
          </Droppable>
        </ListContainer>
      )}
    </Draggable>
  );
};

export default TrelloList;
