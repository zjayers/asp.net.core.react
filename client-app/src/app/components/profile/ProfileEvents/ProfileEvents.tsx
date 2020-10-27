import { format } from "date-fns";
import { observer } from "mobx-react-lite";
import React, { useEffect } from "react";
import { Link } from "react-router-dom";
import { Card, Grid, Header, Image, Tab, TabProps } from "semantic-ui-react";
import { useProfileStore } from "../../../../hooks/useProfileStore";
import { IUserEvent } from "../../../../models";

const panes = [
  { menuItem: "Future Events", pane: { key: "futureEvents" } },
  { menuItem: "Past Events", pane: { key: "pastEvents" } },
  { menuItem: "Hosting", pane: { key: "hosted" } },
];

const ProfileEvents = () => {
  const {
    getUserEvents,
    profile,
    loadingUserEvents,
    userEvents,
  } = useProfileStore();

  useEffect(() => {
    getUserEvents(profile!.userName);
  }, [getUserEvents, profile]);

  const handleTabChange = async (
    e: React.MouseEvent<HTMLDivElement, MouseEvent>,
    data: TabProps
  ) => {
    let predicate;
    switch (data.activeIndex) {
      case 1:
        predicate = "past";
        break;
      case 2:
        predicate = "hosting";
        break;
      default:
        predicate = "future";
        break;
    }
    await getUserEvents(profile!.userName, predicate);
  };

  return (
    <Tab.Pane loading={loadingUserEvents}>
      <Grid>
        <Grid.Column width={16}>
          <Header floated="left" icon="calendar" content={"Events"} />
        </Grid.Column>
        <Grid.Column width={16}>
          <Tab
            panes={panes}
            menu={{ secondary: true, pointing: true }}
            onTabChange={(e, data) => handleTabChange(e, data)}
          />
          <br />
          <Card.Group itemsPerRow={4}>
            {userEvents.map((activity: IUserEvent) => (
              <Card as={Link} to={`/events/${activity.id}`} key={activity.id}>
                <Image
                  src={`/assets/categoryImages/${activity.category}.jpg`}
                  style={{ minHeight: 100, objectFit: "cover" }}
                />
                <Card.Content>
                  <Card.Header textAlign="center">{activity.title}</Card.Header>
                  <Card.Meta textAlign="center">
                    <div>{format(new Date(activity.date), "do LLL")}</div>
                    <div>{format(new Date(activity.date), "h:mm a")}</div>
                  </Card.Meta>
                </Card.Content>
              </Card>
            ))}
          </Card.Group>
        </Grid.Column>
      </Grid>
    </Tab.Pane>
  );
};

export default observer(ProfileEvents);
