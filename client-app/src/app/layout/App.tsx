import { observer } from "mobx-react";
import React, { Fragment, useContext, useEffect } from "react";
import { Container } from "semantic-ui-react";
import { ActivityDashboard } from "../components/activities";
import { NavBar } from "../components/shared";
import LoadingSpinner from "../components/shared/LoadingSpinner/LoadingSpinner";
import ActivityContext from "../store/Activities/activityStore";

const App = () => {
  const activityStore = useContext(ActivityContext);

  // * Lifecycle
  useEffect(() => {
    activityStore.getAllActivities();
  }, [activityStore]);

  // * Render
  return activityStore.loadingInitial ? (
    <LoadingSpinner content={"Loading activities..."} />
  ) : (
    <Fragment>
      <NavBar />
      <Container className={"app__list-container"}>
        <ActivityDashboard />
      </Container>
    </Fragment>
  );
};

// * Exports
export default observer(App);
