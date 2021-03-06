import React from "react";
import Card from "@material-ui/core/Card";
import Typography from "@material-ui/core/Typography";
import CardContent from "@material-ui/core/CardContent";
import styled from "styled-components";
import { Draggable } from "react-beautiful-dnd";
import { connect } from "react-redux";
import { deleteCard } from "../../../redux/actions";

// import Card from '@mui/material/Card';
// import Typography from '@mui/material/Typography';

const CardContainer = styled.div`
  margin-bottom: 8px;
`;

const TrelloCard = ({ text, id, index, dispatch, listID }) => {
  return (
    <Draggable draggableId={String(id)} index={index}>
      {(provided) => (
        <CardContainer
          ref={provided.innerRef}
          {...provided.draggableProps}
          {...provided.dragHandleProps}
        >
          <Card>
            <CardContent>
              <Typography gutterBottom>{text}</Typography> {/* Card info */}
              <button onClick={() => dispatch(deleteCard(listID, id))}> {/* Delete card with help of listID & id */}
                Delete
              </button>
            </CardContent>
          </Card>
        </CardContainer>
      )}
    </Draggable>
  );
};

export default connect()(TrelloCard);
