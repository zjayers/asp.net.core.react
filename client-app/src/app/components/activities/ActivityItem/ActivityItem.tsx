// * Imports
import { observer } from "mobx-react";
import React, { SyntheticEvent, useContext } from "react";
import { Button, Item, Label } from "semantic-ui-react";
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
  const {
    setSelectedActivity,
    target,
    submitting,
    deleteOneActivity,
  } = useContext(ActivityContext);

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
            onClick={() => setSelectedActivity(id)}
          />
          <Button
            name={id}
            loading={target === id && submitting}
            floated={"right"}
            content={"Delete"}
            color={"red"}
            onClick={(e) => deleteOneActivity(e, id)}
          />
          <Label basic content={category} />
        </Item.Extra>
      </Item.Content>
    </Item>
  );
};

// * Exports
export default observer(ActivityItem);
