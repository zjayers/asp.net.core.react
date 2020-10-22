import React from "react";
import { Button, Container, Menu } from "semantic-ui-react";

interface IProps {
  handleOpenCreateForm: () => void;
}

const NavBar: React.FC<IProps> = ({ handleOpenCreateForm }) => (
  <Menu fixed={"top"} inverted>
    <Container>
      <Menu.Item header>
        <img className={"navbar-logo"} src={"/assets/logo.png"} alt="logo" />
        Reactivities
      </Menu.Item>
      <Menu.Item name={"Activities"} />
      <Menu.Item>
        <Button
          positive
          content={"Create Activity"}
          onClick={handleOpenCreateForm}
        />
      </Menu.Item>
    </Container>
  </Menu>
);

export default NavBar;
