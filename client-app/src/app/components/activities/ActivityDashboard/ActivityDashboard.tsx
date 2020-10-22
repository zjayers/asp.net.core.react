import { observer } from "mobx-react";
import React, { useContext } from "react";
import { Grid } from "semantic-ui-react";
import ActivityContext from "../../../store/Activities/activityStore";
import ActivityDetails from "../ActivityDetails/ActivityDetails";
import ActivityForm from "../ActivityForm/ActivityForm";
import ActivityList from "../ActivityList/ActivityList";

// * Component
const ActivityDashboard = () => {
  const { editMode, selectedActivity } = useContext(ActivityContext);
  return (
    <Grid>
      <Grid.Column width={10}>
        <ActivityList />
      </Grid.Column>
      <Grid.Column width={6}>
        {selectedActivity && !editMode && <ActivityDetails />}
        {editMode && <ActivityForm key={selectedActivity?.id || 0} />}
      </Grid.Column>
    </Grid>
  );
};

// * Exports
export default observer(ActivityDashboard);
