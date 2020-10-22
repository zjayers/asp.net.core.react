// * Imports
import React from "react";
import { Button, Item, Label } from "semantic-ui-react";
import { IActivity } from "../../../../models";

// * Interfaces
interface IProps {
  activity: IActivity;
  selectActivity: (id: string | null) => void;
  handleDeleteActivity: (id: string) => void;
}

// * Component
const ActivityItem: React.FC<IProps> = ({
  activity: { id, title, date, description, city, venue, category },
  selectActivity,
  handleDeleteActivity,
}) => {
  return (
    <Item>
      <Item.Content>
        <Item.Header as="a">{title}</Item.Header>
        <Item.Meta>{date}</Item.Meta>
        <Item.Description>
          <div>{description}</div>
          <div>
            {city}, {venue}
          </div>
        </Item.Description>
        <Item.Extra>
          <Button
            floated={"right"}
            content={"View"}
            color={"blue"}
            onClick={() => selectActivity(id)}
          />
          <Button
            floated={"right"}
            content={"Delete"}
            color={"red"}
            onClick={() => handleDeleteActivity(id)}
          />
          <Label basic content={category} />
        </Item.Extra>
      </Item.Content>
    </Item>
  );
};

// * Exports
export default ActivityItem;
