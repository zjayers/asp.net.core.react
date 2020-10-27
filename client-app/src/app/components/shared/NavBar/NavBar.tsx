import { observer } from "mobx-react";
import React from "react";
import { Link, NavLink } from "react-router-dom";
import { Button, Container, Dropdown, Menu, Image } from "semantic-ui-react";
import { useActivityStore } from "../../../../hooks/useActivityStore";
import { useUserStore } from "../../../../hooks/useUserStore";

const NavBar = () => {
  const { clearSelectedActivity } = useActivityStore();
  const { user, logout } = useUserStore();

  return (
    <Menu fixed={"top"} inverted>
      <Container>
        <Menu.Item header as={NavLink} to={"/"} exact>
          <img className={"navbar-logo"} src={"/assets/logo.png"} alt="logo" />
          Lively
        </Menu.Item>
        <Menu.Item name={"Events"} as={NavLink} to={"/events"} />
        <Menu.Item>
          <Button
            positive
            content={"Create Event"}
            as={NavLink}
            to={"/createEvent"}
            onClick={clearSelectedActivity}
          />
        </Menu.Item>
        {user && (
          <Menu.Item position="right">
            <Image
              avatar
              spaced="right"
              src={user.image || "/assets/user.png"}
            />
            <Dropdown pointing="top left" text={user.displayName}>
              <Dropdown.Menu>
                <Dropdown.Item
                  as={Link}
                  to={`/profile/${user.userName}`}
                  text="My profile"
                  icon="user"
                />
                <Dropdown.Item onClick={logout} text="Logout" icon="power" />
              </Dropdown.Menu>
            </Dropdown>
          </Menu.Item>
        )}
      </Container>
    </Menu>
  );
};

export default observer(NavBar);
