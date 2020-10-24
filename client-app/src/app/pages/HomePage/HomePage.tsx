// * Imports
import React from "react";
import { Link } from "react-router-dom";
import { Button, Container, Header, Image, Segment } from "semantic-ui-react";

// * Component
const HomePage = () => {
  return (
    <Segment inverted textAlign="center" vertical className="masthead">
      <Container text>
        <Header as="h1" inverted>
          <Image
            size="massive"
            src="/assets/logo.png"
            alt="logo"
            style={{ marginBottom: 12 }}
          />
          Lively
        </Header>
        <Header as="h2" inverted content="Welcome to Lively" />
        <Button as={Link} to="/activities" size="huge" inverted>
          Take me to the activities!
        </Button>
      </Container>
    </Segment>
  );
};

// * Exports
export default HomePage;
