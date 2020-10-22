// * Imports
import React from "react";
import { Button, Card, Image } from "semantic-ui-react";
import { IActivity } from "../../../../models";

// * Interfaces
interface IProps {
  selectedActivity: IActivity;
  selectActivity: (id: string | null) => void;
  setEditMode: (editMode: boolean) => void;
}

// * Component
const ActivityDetails: React.FC<IProps> = ({
  selectedActivity: { title, category, date, description },
  setEditMode,
  selectActivity,
}) => {
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
            onClick={() => selectActivity(null)}
          />
        </Button.Group>
      </Card.Content>
    </Card>
  );
};

// * Exports
export default ActivityDetails;
