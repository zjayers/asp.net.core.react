// * Imports
import { observer } from "mobx-react";
import React, { Fragment } from "react";
import { Link } from "react-router-dom";
import { Image, Item, Label, List, Segment } from "semantic-ui-react";
import { IActivity } from "../../../../models";

// * Interfaces
interface IProps {
  activity: IActivity;
}

// * Component
const ActivityDetailsSideBar: React.FC<IProps> = ({
  activity: { attendees },
}) => {
  return (
    <Fragment>
      <Segment
        textAlign="center"
        style={{ border: "none" }}
        attached="top"
        secondary
        inverted
        color="teal"
      >
        {attendees.length} {attendees.length === 1 ? "Person" : "People"} Going
      </Segment>
      <Segment attached>
        <List relaxed divided>
          {attendees.map((a) => (
            <Item style={{ position: "relative" }} key={a.userName}>
              {a.isHost && (
                <Label
                  style={{ position: "absolute" }}
                  color="orange"
                  ribbon="right"
                >
                  Host
                </Label>
              )}
              <Image size="tiny" src={a.image || "/assets/user.png"} />
              <Item.Content verticalAlign="middle">
                <Item.Header as="h3">
                  <Link to={`/profile/${a.userName}`}>{a.displayName}</Link>
                </Item.Header>
                <Item.Extra style={{ color: "orange" }}>Following</Item.Extra>
              </Item.Content>
            </Item>
          ))}
        </List>
      </Segment>
    </Fragment>
  );
};

// * Exports
export default observer(ActivityDetailsSideBar);
