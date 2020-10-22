import React from "react";
import { Grid } from "semantic-ui-react";
import { IActivity } from "../../../../models";
import ActivityDetails from "../ActivityDetails/ActivityDetails";
import ActivityForm from "../ActivityForm/ActivityForm";
import ActivityList from "../ActivityList/ActivityList";

// * Interfaces
interface IProps {
  activities: IActivity[];
  editMode: boolean;
  setEditMode: (editMode: boolean) => void;
  selectedActivity: IActivity | null;
  selectActivity: (id: string | null) => void;
  handleCreateActivity: (activity: IActivity) => void;
  handleEditActivity: (activity: IActivity) => void;
  handleDeleteActivity: (id: string) => void;
}

// * Component
const ActivityDashboard: React.FC<IProps> = ({
  activities,
  editMode,
  setEditMode,
  selectedActivity,
  selectActivity,
  handleCreateActivity,
  handleEditActivity,
  handleDeleteActivity,
}) => (
  <Grid>
    <Grid.Column width={10}>
      <ActivityList
        activities={activities}
        selectActivity={selectActivity}
        handleDeleteActivity={handleDeleteActivity}
      />
    </Grid.Column>
    <Grid.Column width={6}>
      {selectedActivity && !editMode && (
        <ActivityDetails
          selectedActivity={selectedActivity}
          selectActivity={selectActivity}
          setEditMode={setEditMode}
        />
      )}
      {editMode && (
        <ActivityForm
          key={selectedActivity?.id || 0}
          selectedActivity={selectedActivity}
          setEditMode={setEditMode}
          handleCreateActivity={handleCreateActivity}
          handleEditActivity={handleEditActivity}
        />
      )}
    </Grid.Column>
  </Grid>
);

// * Exports
export default ActivityDashboard;
