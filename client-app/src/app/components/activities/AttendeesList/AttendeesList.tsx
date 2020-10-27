import React from "react";
import { Link } from "react-router-dom";
import { Image, List, Popup } from "semantic-ui-react";
import { IAttendee } from "../../../../models/IAttendee";

interface IProps {
  attendees: IAttendee[];
}

const styles = {
  border: "3px solid orange",
};

const AttendeesList: React.FC<IProps> = ({ attendees }) => {
  return (
    <List horizontal>
      {attendees.map((a) => (
        <List.Item key={a.userName}>
          <Popup
            header={a.displayName}
            trigger={
              <Image
                as={Link}
                to={`profile/${a.userName}`}
                size={"mini"}
                circular
                bordered
                style={a.following ? styles : null}
                src={a.image || "assets/user.png"}
              />
            }
          />
        </List.Item>
      ))}
    </List>
  );
};

export default AttendeesList;
