// * Imports
import React from "react";
import { Link } from "react-router-dom";
import { Button, Header, Icon, Segment } from "semantic-ui-react";

// * Component
const NotFound = () => {
  return (
    <Segment placeholder>
      <Header icon>
        <Icon name="search" />
        Oops - we've looked everywhere but couldn't find this.
      </Header>
      <Segment.Inline>
        <Button as={Link} to="/events" primary>
          Return to Events page
        </Button>
      </Segment.Inline>
    </Segment>
  );
};

// * Exports
export default NotFound;
