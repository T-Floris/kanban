import { CONSTANTS } from "../actions";

let listID = 2;
let cardID = 14;

const initialState = [
  {
    title: "TODO",
    id: `list-${0}`,
    cards: [
      {
        id: `card-${0}`,
        text: "Migrate Java code to Kotlin"
      },
      {
        id: `card-${1}`,
        text: "Refactor contracts"
      }
    ]
  },
  {
    title: "DOING",
    id: `list-${1}`,
    cards: [
      {
        id: `card-${2}`,
        text: "Front end integration with cordova"
      },
      {
        id: `card-${3}`,
        text: "Use Cordova token sdk for settlement"
      }
    ]
  },
  {
    title: "DONE",
    id: `list-${2}`,
    cards: [
      {
        id: `card-${4}`,
        text: "Managing access control for node in flows"
      },
      {
        id: `card-${5}`,
        text: "Issue #3 pushed to Git"
      },
      {
        id: `card-${6}`,
        text: "Drag and drop added to third party"
      }
    ]
  },
  {
    title: "REJECTED",
    id: `list-${3}`,
    cards: [
      {
        id: `card-${7}`,
        text: "Issue #43 rejected due to stability"
      },
      {
        id: `card-${8}`,
        text: "Token id replaced"
      },
      {
        id: `card-${9}`,
        text: "Downgraded v1.7 to v1.6"
      }
    ]
  }
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
      console.log("Added list:", action.payload);
      return [...state, newList];

    case CONSTANTS.ADD_CARD: {
      const newCard = {
        text: action.payload.text,
        id: `card-${cardID}`,
      };
      cardID += 1;
      console.log("Added card:", action.payload);
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
        console.log("Dragged a list:", action.payload);
        
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
