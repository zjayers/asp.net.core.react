// * Imports
import { format } from "date-fns";
import { observer } from "mobx-react";
import React from "react";
import { Link } from "react-router-dom";
import { Button, Header, Image, Item, Segment } from "semantic-ui-react";
import { IActivity } from "../../../../models";
import { useActivityStore } from "../../../hooks/useActivityStore";
import { useGuiStore } from "../../../hooks/useGuiStore";

// * Styles
const activityImageStyle = {
  filter: "brightness(30%)",
};

const activityImageTextStyle = {
  position: "absolute",
  bottom: "5%",
  left: "5%",
  width: "100%",
  height: "auto",
  color: "white",
};

interface IProps {
  activity: IActivity;
}

// * Component
const ActivityDetailsHeader: React.FC<IProps> = ({
  activity: { id, category, title, date, attendees, isHost, isGoing },
}) => {
  const host = attendees.find((a) => a.isHost);
  const {
    createAttendanceForOneActivity,
    cancelAttendanceForOneActivity,
  } = useActivityStore();
  const { loadingSecondary } = useGuiStore();

  return (
    <Segment.Group>
      <Segment basic attached="top" style={{ padding: "0" }}>
        <Image
          src={`/assets/categoryImages/${category}.jpg`}
          fluid
          style={activityImageStyle}
        />
        <Segment basic style={activityImageTextStyle}>
          <Item.Group>
            <Item>
              <Item.Content>
                <Header
                  size="huge"
                  content={title}
                  style={{ color: "white" }}
                />
                <p>{format(date, "eeee, MMMM do")}</p>
                <p>
                  Hosted by <strong>{host?.displayName || ""}</strong>
                </p>
              </Item.Content>
            </Item>
          </Item.Group>
        </Segment>
      </Segment>
      <Segment clearing attached="bottom">
        {isHost ? (
          <Button
            loading={loadingSecondary}
            as={Link}
            to={`/manage/${id}`}
            color="orange"
            floated="right"
            fluid
          >
            Manage Event
          </Button>
        ) : isGoing ? (
          <Button
            loading={loadingSecondary}
            onClick={cancelAttendanceForOneActivity}
            fluid
          >
            Cancel Attendance
          </Button>
        ) : (
          <Button
            loading={loadingSecondary}
            onClick={createAttendanceForOneActivity}
            fluid
            color="teal"
          >
            Join Event
          </Button>
        )}
      </Segment>
    </Segment.Group>
  );
};

// * Exports
export default observer(ActivityDetailsHeader);
