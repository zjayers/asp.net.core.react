import React from "react";
import { NavLink } from "react-router-dom";
import { Button, Container, Menu } from "semantic-ui-react";
import { useActivityStore } from "../../../hooks/useActivityStore";

const NavBar = () => {
  const { clearSelectedActivity } = useActivityStore();

  return (
    <Menu fixed={"top"} inverted>
      <Container>
        <Menu.Item header as={NavLink} to={"/"} exact>
          <img className={"navbar-logo"} src={"/assets/logo.png"} alt="logo" />
          Reactivities
        </Menu.Item>
        <Menu.Item name={"Activities"} as={NavLink} to={"/activities"} />
        <Menu.Item>
          <Button
            positive
            content={"Create Activity"}
            as={NavLink}
            to={"/createActivity"}
            onClick={clearSelectedActivity}
          />
        </Menu.Item>
      </Container>
    </Menu>
  );
};

export default NavBar;
