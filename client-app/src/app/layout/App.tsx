import React, { Fragment, useEffect, useState } from "react";
import { Container } from "semantic-ui-react";
import { IActivity } from "../../models";
import { api } from "../../services/api";
import { ActivityDashboard } from "../components/activities";
import { NavBar } from "../components/shared";

function App() {
  // * State
  const [activities, setActivities] = useState<IActivity[]>([]);
  const [selectedActivity, setSelectedActivity] = useState<IActivity | null>(
    null
  );
  const [editMode, setEditMode] = useState(false);

  // * Lifecycle
  useEffect(() => {
    fetchValuesFromApi();
  }, []);

  /**
   * Fetch Values from the API and store them in state
   */
  const fetchValuesFromApi = async () => {
    const { data: newActivities } = await api.get<IActivity[]>(
      "/api/activities"
    );

    setActivities(
      newActivities.map((at) => ({ ...at, date: at.date.split(".")[0] }))
    );
  };

  /**
   * Select activity by ID
   * @param id
   */
  const handleSelectActivity = (id: string | null) => {
    setEditMode(false);

    if (id) {
      const activityToSet = activities.find((a) => a.id === id);

      if (activityToSet) {
        return setSelectedActivity(activityToSet);
      }
    }

    setSelectedActivity(null);
  };

  /**
   * Open the creation form
   */
  const handleOpenCreateForm = () => {
    setSelectedActivity(null);
    setEditMode(true);
  };

  /**
   * Create Activity
   * @param activity
   */
  const handleCreateActivity = (activity: IActivity) => {
    setActivities([...activities, activity]);
    setSelectedActivity(activity);
    setEditMode(false);
  };

  /**
   * Edit Activity
   * @param activity
   */
  const handleEditActivity = (activity: IActivity) => {
    setActivities(activities.map((a) => (a.id === activity.id ? activity : a)));
    setSelectedActivity(activity);
    setEditMode(false);
  };

  /**
   * Delete Activity
   * @param id
   */
  const handleDeleteActivity = (id: string) => {
    setActivities(activities.filter((a) => a.id !== id));

    if (selectedActivity?.id === id) {
      setSelectedActivity(null);
      setEditMode(false);
    }
  };

  // * Render
  return (
    <Fragment>
      <NavBar handleOpenCreateForm={handleOpenCreateForm} />
      <Container className={"app__list-container"}>
        <ActivityDashboard
          activities={activities}
          editMode={editMode}
          setEditMode={setEditMode}
          selectedActivity={selectedActivity}
          selectActivity={handleSelectActivity}
          handleCreateActivity={handleCreateActivity}
          handleEditActivity={handleEditActivity}
          handleDeleteActivity={handleDeleteActivity}
        />
      </Container>
    </Fragment>
  );
}

// * Exports
export default App;
