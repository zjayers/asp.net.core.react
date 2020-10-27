import { observer } from "mobx-react";
import React from "react";
import { Card, Grid, Header, Tab } from "semantic-ui-react";
import { useProfileStore } from "../../../../hooks/useProfileStore";
import ProfileCard from "../ProfileCard/ProfileCard";

const ProfileFollowings = () => {
  const {
    isCurrentUser,
    profile,
    followings,
    loadingFollows,
    activeTab,
  } = useProfileStore();

  return (
    <Tab.Pane loading={loadingFollows}>
      <Grid>
        <Grid.Column width={16}>
          <Header
            floated="left"
            icon="user"
            content={
              activeTab === 2
                ? `People following ${
                    isCurrentUser ? "you" : profile!.displayName
                  }`
                : `People ${
                    isCurrentUser ? "you are" : profile!.displayName + " is"
                  } following`
            }
          />
        </Grid.Column>
        <Grid.Column width={16}>
          <Card.Group itemsPerRow={5}>
            {followings.map((profile) => (
              <ProfileCard key={profile.userName} profile={profile} />
            ))}
          </Card.Group>
        </Grid.Column>
      </Grid>
    </Tab.Pane>
  );
};

export default observer(ProfileFollowings);
