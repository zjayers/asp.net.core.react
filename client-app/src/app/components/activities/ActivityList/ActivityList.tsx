// * Imports
import { observer } from "mobx-react";
import React, { Fragment } from "react";
import { Item, Label } from "semantic-ui-react";
import { useActivityStore } from "../../../hooks/useActivityStore";
import ActivityItem from "../ActivityItem/ActivityItem";

// * Component
const ActivityList = () => {
  const { activitiesByDate } = useActivityStore();

  return (
    <Fragment>
      {activitiesByDate.map(([group, activities]) => (
        <Fragment key={group}>
          <Label size={"large"} color={"blue"}>
            {group}
          </Label>
          <Item.Group divided>
            {activities.map((activity) => (
              <ActivityItem activity={activity} key={activity.id} />
            ))}
          </Item.Group>
        </Fragment>
      ))}
    </Fragment>
  );
};

// * Exports
export default observer(ActivityList);
