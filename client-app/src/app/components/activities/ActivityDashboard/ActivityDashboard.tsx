import { observer } from "mobx-react";
import React, { useEffect } from "react";
import { Grid } from "semantic-ui-react";
import { useActivityStore } from "../../../hooks/useActivityStore";
import { useGuiStore } from "../../../hooks/useGuiStore";
import { LoadingSpinner } from "../../shared";
import ActivityList from "../ActivityList/ActivityList";

// * Component
const ActivityDashboard = () => {
  const { getAllActivities } = useActivityStore();
  const { loadingInitial } = useGuiStore();

  // * Lifecycle
  useEffect(() => {
    getAllActivities();
  }, [getAllActivities]);

  return loadingInitial ? (
    <LoadingSpinner content={"Loading activities..."} />
  ) : (
    <Grid>
      <Grid.Column width={10}>
        <ActivityList />
      </Grid.Column>
      <Grid.Column width={6}>
        <h2>Activity Filters</h2>
      </Grid.Column>
    </Grid>
  );
};

// * Exports
export default observer(ActivityDashboard);
