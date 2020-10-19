import React from "react";
import "./App.css";
import { Header, Icon } from "semantic-ui-react";
import ValueList from "./components/ValueList";

function App() {
  return (
    <div>
      <Header as={"h2"}>
        <Icon name={"users"} />
        <Header.Content>Reactivities</Header.Content>
      </Header>
      <ValueList />
    </div>
  );
}

export default App;
