import { observer } from "mobx-react-lite";
import React, { useState } from "react";
import { Button, Grid, Header, Tab } from "semantic-ui-react";
import { useProfileStore } from "../../../../hooks/useProfileStore";
import ProfileEditForm from "../ProfileEditForm/ProfileEditForm";

const ProfileDescription = () => {
  const { updateProfile, profile, isCurrentUser } = useProfileStore();
  const [editMode, setEditMode] = useState(false);

  const handleProfileUpdate = async (values: any) => {
    await updateProfile(values);
    setEditMode(false);
  };

  return (
    <Tab.Pane>
      <Grid>
        <Grid.Column width={16}>
          <Header
            floated="left"
            icon="user"
            content={`About ${profile!.displayName}`}
          />
          {isCurrentUser && (
            <Button
              floated="right"
              basic
              content={editMode ? "Cancel" : "Edit Profile"}
              onClick={() => setEditMode(!editMode)}
            />
          )}
        </Grid.Column>
        <Grid.Column width={16}>
          {editMode ? (
            <ProfileEditForm
              updateProfile={handleProfileUpdate}
              profile={profile!}
            />
          ) : (
            <span>{profile!.bio}</span>
          )}
        </Grid.Column>
      </Grid>
    </Tab.Pane>
  );
};

export default observer(ProfileDescription);
