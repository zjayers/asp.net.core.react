// * Imports
import { observer } from "mobx-react";
import React, { useContext } from "react";
import { Item, Segment } from "semantic-ui-react";
import ActivityContext from "../../../store/Activities/activityStore";
import ActivityItem from "../ActivityItem/ActivityItem";

// * Component
const ActivityList = () => {
  const { activitiesByDate } = useContext(ActivityContext);

  return (
    <Segment clearing>
      <Item.Group divided>
        {activitiesByDate.map((activity) => (
          <ActivityItem activity={activity} key={activity.id} />
        ))}
      </Item.Group>
    </Segment>
  );
};

// * Exports
export default observer(ActivityList);
