import { observer } from "mobx-react";
import React from "react";
import {
  Button,
  Divider,
  Grid,
  Header,
  Item,
  Reveal,
  Segment,
  Statistic,
} from "semantic-ui-react";
import { useProfileStore } from "../../../../hooks/useProfileStore";
import { IProfile } from "../../../../models";

interface IProps {
  profile: IProfile | null;
}

const ProfileHeader: React.FC<IProps> = ({ profile }) => {
  const { follow, unFollow, isCurrentUser } = useProfileStore();

  return (
    <Segment>
      <Grid>
        <Grid.Column width={12}>
          <Item.Group>
            <Item>
              <Item.Image
                avatar
                size="small"
                src={profile?.image || "/assets/user.png"}
              />
              <Item.Content verticalAlign="middle">
                <Header as="h1">{profile?.displayName}</Header>
              </Item.Content>
            </Item>
          </Item.Group>
        </Grid.Column>
        <Grid.Column width={4}>
          <Statistic.Group widths={2}>
            <Statistic label="Followers" value={profile?.followersCount} />
            <Statistic label="Following" value={profile?.followingCount} />
          </Statistic.Group>
          <Divider />

          {!isCurrentUser && (
            <Reveal animated="move">
              <Reveal.Content visible style={{ width: "100%" }}>
                <Button
                  fluid
                  color={profile?.following ? "teal" : "red"}
                  content={profile?.following ? "Following" : "Not Following"}
                />
              </Reveal.Content>
              <Reveal.Content hidden>
                <Button
                  fluid
                  basic
                  color={profile?.following ? "red" : "green"}
                  content={profile?.following ? "Unfollow" : "Follow"}
                  onClick={
                    profile?.following
                      ? () => unFollow(profile?.userName)
                      : () => follow(profile?.userName)
                  }
                />
              </Reveal.Content>
            </Reveal>
          )}
        </Grid.Column>
      </Grid>
    </Segment>
  );
};

export default observer(ProfileHeader);
