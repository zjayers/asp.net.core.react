// * Imports
import { format } from "date-fns";
import { observer } from "mobx-react";
import React, { useContext } from "react";
import { Link } from "react-router-dom";
import { Button, Icon, Item, Segment } from "semantic-ui-react";
import { IActivity } from "../../../../models";
import ActivityContext from "../../../store/Activities/activityStore";

// * Interfaces
interface IProps {
  activity: IActivity;
}

// * Component
const ActivityItem: React.FC<IProps> = ({
  activity: { title, date, description, category, city, venue, id },
}) => {
  const { setSelectedActivity } = useContext(ActivityContext);

  return (
    <Segment.Group>
      <Segment>
        <Item.Group>
          <Item>
            <Item.Image size={"tiny"} circular src={"/assets/user.png"} />
            <Item.Content>
              <Item.Header>{title}</Item.Header>
              <Item.Description>Hosted by Bob</Item.Description>
            </Item.Content>
          </Item>
        </Item.Group>
      </Segment>
      <Segment>
        <Icon name={"clock"} /> {format(date!, "h:mm a")}
        <Icon name={"marker"} /> {venue}, {city}
      </Segment>
      <Segment secondary>Attendees will go here</Segment>
      <Segment clearing>
        <span>{description}</span>
        <Button
          as={Link}
          to={`/activities/${id}`}
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
