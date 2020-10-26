// * Imports
import { format } from "date-fns";
import { observer } from "mobx-react";
import React from "react";
import { Link } from "react-router-dom";
import { Button, Icon, Item, Label, Segment } from "semantic-ui-react";
import { IActivity } from "../../../../models";
import { useActivityStore } from "../../../hooks/useActivityStore";
import AttendeesList from "../AttendeesList/AttendeesList";

// * Interfaces
interface IProps {
  activity: IActivity;
}

// * Component
const ActivityItem: React.FC<IProps> = ({
  activity: {
    attendees,
    isHost,
    isGoing,
    title,
    date,
    description,
    category,
    city,
    venue,
    id,
  },
}) => {
  const { setSelectedActivity } = useActivityStore();
  const host = attendees.find((a) => a.isHost);
  return (
    <Segment.Group>
      <Segment>
        <Item.Group>
          <Item>
            <Item.Image
              size={"tiny"}
              circular
              src={host?.image || "/assets/user.png"}
            />
            <Item.Content>
              <Item.Header as={Link} to={`/events/${id}`}>
                {title}
              </Item.Header>
              <Item.Description>
                Hosted by{" "}
                <Item.Description as={Link} to={`/profile/${host?.userName}`}>
                  {host?.displayName || ""}
                </Item.Description>
              </Item.Description>

              {isHost && (
                <Item.Description>
                  <Label
                    basic
                    color={"orange"}
                    content={"You are hosting this event"}
                  />
                </Item.Description>
              )}

              {!isHost && isGoing && (
                <Item.Description>
                  <Label
                    basic
                    color={"green"}
                    content={"You are attending this event"}
                  />
                </Item.Description>
              )}
            </Item.Content>
          </Item>
        </Item.Group>
      </Segment>
      <Segment>
        <Icon name={"clock"} /> {format(date!, "h:mm a")}
        <Icon name={"marker"} /> {venue}, {city}
      </Segment>
      <Segment secondary>
        <AttendeesList attendees={attendees} />
      </Segment>
      <Segment clearing>
        <span>{description}</span>
        <Button
          as={Link}
          to={`/events/${id}`}
          floated={"right"}
          content={"View"}
          color={"blue"}
          onClick={() => setSelectedActivity(id)}
        />
      </Segment>
    </Segment.Group>
  );
};

// * Exports
export default observer(ActivityItem);
