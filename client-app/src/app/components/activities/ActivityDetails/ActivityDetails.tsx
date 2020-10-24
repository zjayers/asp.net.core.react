// * Imports
import { observer } from "mobx-react";
import React, { useEffect } from "react";
import { useParams } from "react-router-dom";
import { Grid } from "semantic-ui-react";
import { useActivityStore } from "../../../hooks/useActivityStore";
import { useGuiStore } from "../../../hooks/useGuiStore";
import { LoadingSpinner } from "../../shared";
import ActivityDetailsChat from "./ActivityDetailsChat";
import ActivityDetailsHeader from "./ActivityDetailsHeader";
import ActivityDetailsInfo from "./ActivityDetailsInfo";
import ActivityDetailsSideBar from "./ActivityDetailsSideBar";

// * Component
const ActivityDetails = () => {
  const { getOneActivity, selectedActivity } = useActivityStore();
  const { loadingInitial } = useGuiStore();

  const { id } = useParams();

  useEffect(() => {
    getOneActivity(id);
  }, [getOneActivity, id]);

  if (!selectedActivity.id) return <h1>Activity Not Found</h1>;

  return loadingInitial ? (
    <LoadingSpinner content={"Loading activity..."} />
  ) : (
    <Grid>
      <Grid.Column width={10}>
        <ActivityDetailsHeader activity={selectedActivity} />
        <ActivityDetailsInfo activity={selectedActivity} />
        <ActivityDetailsChat activity={selectedActivity} />
      </Grid.Column>
      <Grid.Column width={6}>
        <ActivityDetailsSideBar activity={selectedActivity} />
      </Grid.Column>
    </Grid>
  );
};

// * Exports
export default observer(ActivityDetails);
