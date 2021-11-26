import { CONSTANTS } from "../actions";

let listID = 2;
let cardID = 5;

const initialState = [
  {
    title: "Last Episode0",
    id: `list-${0}`,
    cards: [
      {
        id: `card-${0}`,
        text: "Text test something0",
      },
      {
        id: `card-${1}`,
        text: "Text test something1",
      },
    ],
  },
  {
    title: "Summer Episode1",
    id: `list-${1}`,
    cards: [
      {
        id: `card-${2}`,
        text: "Text test something2",
      },
      {
        id: `card-${3}`,
        text: "Text test something3",
      },
      {
        id: `card-${4}`,
        text: "Text test something4",
      },
      {
        id: `card-${5}`,
        text: "Text test something4",
      },
      {
        id: `card-${6}`,
        text: "Text test something4",
      },
      {
        id: `card-${7}`,
        text: "Text test something4",
      },
      {
        id: `card-${8}`,
        text: "Text test something4",
      },
      {
        id: `card-${9}`,
        text: "Text test something4",
      },
      {
        id: `card-${10}`,
        text: "Text test something4",
      },
      {
        id: `card-${11}`,
        text: "Text test something4",
      },
      {
        id: `card-${12}`,
        text: "Text test something4",
      },
      {
        id: `card-${13}`,
        text: "Text test something4",
      },
    ],
  },
];

const listsReducer = (state = initialState, action) => {
  switch (action.type) {
    case CONSTANTS.ADD_LIST:
      const newList = {
        title: action.payload,
        cards: [],
        id: `list-${listID}`,
      };
      listID += 1;
      return [...state, newList];

    case CONSTANTS.ADD_CARD: {
      const newCard = {
        text: action.payload.text,
        id: `card-${cardID}`,
      };
      cardID += 1;

      const newState = state.map((list) => {
        if (list.id === action.payload.listID) {
          return {
            ...list,
            cards: [...list.cards, newCard],
          };
        } else {
          return list;
        }
      });

      return newState;
    }

    case CONSTANTS.DRAG_HAPPENED: {
      const {
        droppableIdStart,
        droppableIdEnd,
        droppableIndexEnd,
        droppableIndexStart,
        // draggableId,
        type,
      } = action.payload;
      const newState = [...state];

      //dragging lists around
      if (type === "list") {
        const list = newState.splice(droppableIndexStart, 1);
        newState.splice(droppableIndexEnd, 0, ...list);
        return newState;
      }

      // In the same list & if true its in the same container
      if (droppableIdStart === droppableIdEnd) {
        const list = state.find((list) => droppableIdStart === list.id);
        const card = list.cards.splice(droppableIndexStart, 1);
        list.cards.splice(droppableIndexEnd, 0, ...card);
      }

      //other list

      if (droppableIdStart !== droppableIdEnd) {
        //find the list where drag happened
        const listStart = state.find((list) => droppableIdStart === list.id);

        //pull out the card from this listsReducer
        const card = listStart.cards.splice(droppableIndexStart, 1);

        //find the list where drag ended
        const listEnd = state.find((list) => droppableIdEnd === list.id);

        //put the card in the new list
        listEnd.cards.splice(droppableIndexEnd, 0, ...card);
      }

      return newState;
    }
    default:
      return state;
  }
};

export default listsReducer;
