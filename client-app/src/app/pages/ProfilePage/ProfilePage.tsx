import { observer } from "mobx-react";
import React, { useEffect } from "react";
import { Grid } from "semantic-ui-react";
import { useProfileStore } from "../../../hooks/useProfileStore";
import ProfileContent from "../../components/profile/ProfileContent/ProfileContent";
import ProfileHeader from "../../components/profile/ProfileHeader/ProfileHeader";
import { useParams } from "react-router-dom";
import { LoadingSpinner } from "../../components/shared";

const ProfilePage = () => {
  const { loadingProfile, profile, loadProfile } = useProfileStore();
  const { username } = useParams();

  useEffect(() => {
    loadProfile(username);
  }, [loadProfile, username]);

  return loadingProfile ? (
    <LoadingSpinner content={"Loading profile..."} />
  ) : (
    <Grid>
      <Grid.Column width={16}>
        <ProfileHeader profile={profile} />
        <ProfileContent />
      </Grid.Column>
    </Grid>
  );
};

export default observer(ProfilePage);
