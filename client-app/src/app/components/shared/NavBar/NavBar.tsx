import React, { useContext } from "react";
import { Button, Container, Menu } from "semantic-ui-react";
import ActivityContext from "../../../store/Activities/activityStore";

const NavBar = () => {
  const { openCreateForm } = useContext(ActivityContext);

  return (
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
            onClick={openCreateForm}
          />
        </Menu.Item>
      </Container>
    </Menu>
  );
};

export default NavBar;
