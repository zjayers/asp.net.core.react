// * Imports
import { observer } from "mobx-react";
import React, { useContext } from "react";
import { Button, Card, Image } from "semantic-ui-react";
import { IActivity } from "../../../../models";
import ActivityContext from "../../../store/Activities/activityStore";

// * Component
const ActivityDetails = () => {
  const { selectedActivity, setSelectedActivity, setEditMode } = useContext(
    ActivityContext
  );
  const { title, category, date, description } = selectedActivity as IActivity;

  return (
    <Card fluid>
      <Image
        src={`/assets/categoryImages/${category}.jpg`}
        wrapped
        ui={false}
      />
      <Card.Content>
        <Card.Header>{title}</Card.Header>
        <Card.Meta>
          <span>{date}</span>
        </Card.Meta>
        <Card.Description>{description}</Card.Description>
      </Card.Content>
      <Card.Content extra>
        <Button.Group widths={2}>
          <Button
            basic
            color={"blue"}
            content={"Edit"}
            onClick={() => setEditMode(true)}
          />
          <Button
            basic
            color={"grey"}
            content={"Cancel"}
            onClick={() => setSelectedActivity(null)}
          />
        </Button.Group>
      </Card.Content>
    </Card>
  );
};

// * Exports
export default observer(ActivityDetails);
