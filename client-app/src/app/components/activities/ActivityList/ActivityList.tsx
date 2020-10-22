// * Imports
import React from "react";
import { Item, Segment } from "semantic-ui-react";
import { IActivity } from "../../../../models";
import ActivityItem from "../ActivityItem/ActivityItem";

// * Interfaces
interface IProps {
  activities: IActivity[];
  selectActivity: (id: string | null) => void;
  handleDeleteActivity: (id: string) => void;
}

// * Component
const MyComponent: React.FC<IProps> = ({
  activities,
  selectActivity,
  handleDeleteActivity,
}) => {
  return (
    <Segment clearing>
      <Item.Group divided>
        {activities.map((activity) => (
          <ActivityItem
            activity={activity}
            key={activity.id}
            selectActivity={selectActivity}
            handleDeleteActivity={handleDeleteActivity}
          />
        ))}
      </Item.Group>
    </Segment>
  );
};

// * Exports
export default MyComponent;
