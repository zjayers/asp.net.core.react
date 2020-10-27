// * Imports
import { observer } from "mobx-react";
import React, { Fragment } from "react";
import { Item, Label } from "semantic-ui-react";
import { useEventStore } from "../../../../hooks/useEventStore";
import ActivityItem from "../ActivityItem/ActivityItem";
import { format } from "date-fns";

// * Component
const ActivityList = () => {
  const { activitiesByDate } = useEventStore();

  return (
    <Fragment>
      {activitiesByDate.map(([group, activities]) => (
        <Fragment key={group}>
          <Label size={"large"} color={"blue"}>
            {format(group, "eeee, MMMM do")}
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
