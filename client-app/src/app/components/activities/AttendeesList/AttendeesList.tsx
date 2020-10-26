import React from "react";
import { Image, List, Popup } from "semantic-ui-react";
import { IAttendee } from "../../../../models/IAttendee";

interface IProps {
  attendees: IAttendee[];
}

const AttendeesList: React.FC<IProps> = ({ attendees }) => {
  return (
    <List horizontal>
      {attendees.map((a) => (
        <List.Item key={a.userName}>
          <Popup
            header={a.displayName}
            trigger={
              <Image
                size={"mini"}
                circular
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
