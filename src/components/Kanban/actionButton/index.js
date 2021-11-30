import React from "react";
import Icon from "@material-ui/core/Icon";
import Textarea from "react-textarea-autosize";
import Card from "@material-ui/core/Card";
import Button from "@material-ui/core/Button";
import { connect } from "react-redux";
import { addList, addCard } from "../../../redux/actions";

class TrelloActionButton extends React.Component {
  state = {
    formOpen: false, //Textarea is not displayed till you click on add another card
    text: "", //blank textarea til you insert something
  };

  //open function
  openForm = () => {
    this.setState({
      formOpen: true,
    });
  };

  //close function
  closeForm = (e) => {
    this.setState({
      formOpen: false,
    });
  };

  //better performance and only create this once, otherwise it will always create a new instance
  handleInputChange = (e) => {
    this.setState({
      text: e.target.value,
    });
  };

  //add list function
  handleAddList = () => {
    const { dispatch } = this.props;
    const { text } = this.state;

    if (text) {
      this.setState({
        text: ""
      })
      dispatch(addList(text));

    }
  };

  //add card function
  handleAddCard = () => {
    const { dispatch, listID } = this.props;
    const { text } = this.state;

    if (text) {
      this.setState({
        text: ""
      })
      dispatch(addCard(listID, text));
    }
  };

  //display different state/text of button
  renderAddButton = () => {
    const { list } = this.props;

    const buttonText = list ? "Add another list" : "Add another card";
    const buttonTextOpacity = list ? 1 : 0.5;
    const buttonTextColor = list ? "white" : "inherit";
    const buttonTextBackground = list ? "rgba(0,0,0,.15)" : "inherit";

    return (
      <div
        onClick={this.openForm}
        style={{
          ...styles.openFormButtonGroup,
          opacity: buttonTextOpacity,
          color: buttonTextColor,
          backgroundColor: buttonTextBackground,
        }}
      >
        
        <Icon>add</Icon> {/* Add + icon */}
        <p>{buttonText}</p>
      </div>
    );
  };

  //display different state/text in form/textarea
  renderForm = () => {
    const { list } = this.props;

    const placeholder = list
      ? "Enter list title"
      : "Enter a title for this card...";

    const buttonTitle = list ? "Add List" : "Add Card";

    return (
      <div>
        <Card
          style={{
            minHeight: 80,
            minWidth: 272,
            padding: "6px 8px 2px",
          }}
        >
          {/* textarea when adding new card */}
          <Textarea
            placeholder={placeholder}
            autoFocus //when click you can write in textarea right away
            onBlur={this.closeForm} //occurs when an object loses focus
            value={this.state.text}
            onChange={this.handleInputChange}
            style={{
              resize: "none",
              width: "100%",
              outline: "none",
              border: "none",
              overflow: "hidden",
            }}
          />
        </Card>

        <div style={styles.formButtonGroup}>
          <Button
            onMouseDown={list ? this.handleAddList : this.handleAddCard}
            variant="contained"
            style={{ color: "white", backgroundColor: "#5aac44" }}
          >
            {buttonTitle}{" "}
          </Button>
          <Icon style={{ marginLeft: 8, cursor: "pointer" }} onClick={this.closeForm}>close</Icon> {/* close X icon */}
        </div>
      </div>
    );
  };

  render() {
    return this.state.formOpen ? this.renderForm() : this.renderAddButton();
  }
}

const styles = {
  openFormButtonGroup: {
    display: "flex",
    alignItems: "center",
    cursor: "pointer",
    borderRadius: 3,
    height: 36,
    width: 272,
    paddingLeft: 10,
  },
  formButtonGroup: {
    marginTop: 8,
    display: "flex",
    alignItems: "center",
  },
};

export default connect()(TrelloActionButton);
