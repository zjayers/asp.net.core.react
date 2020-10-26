// * Imports
import { observer } from "mobx-react";
import React from "react";
import { Button, Container, Header, Image, Segment } from "semantic-ui-react";
import LoginForm from "../../components/user/LoginForm/LoginForm";
import RegisterForm from "../../components/user/RegisterForm/RegisterForm";

import { useAuthRedirect } from "../../hooks/useAuthRedirect";
import { useModalStore } from "../../hooks/useModalStore";

// * Component
const HomePage = () => {
  const { openModal } = useModalStore();

  return useAuthRedirect(
    <Segment inverted textAlign="center" vertical className="masthead">
      <Container className={"home-page-container"} text textAlign={"center"}>
        <Header as="h1" inverted>
          <Image
            size="massive"
            src="/assets/logo.png"
            alt="logo"
            style={{ marginBottom: 12 }}
          />
          Lively
        </Header>
        <Button.Group widths={2} size={"big"}>
          <Button onClick={() => openModal(<LoginForm />)} size="huge" inverted>
            Login
          </Button>
          <Button
            onClick={() => openModal(<RegisterForm />)}
            size="huge"
            inverted
          >
            Register
          </Button>
        </Button.Group>
      </Container>
    </Segment>
  );
};

// * Exports
export default observer(HomePage);
