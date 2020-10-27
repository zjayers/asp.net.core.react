import React from "react";
import { Tab } from "semantic-ui-react";
import ProfileDescription from "../ProfileDescription/ProfileDescription";
import ProfilePhotos from "../ProfilePhotos/ProfilePhotos";

const panes = [
  { menuItem: "About", render: () => <ProfileDescription /> },
  { menuItem: "Photos", render: () => <ProfilePhotos /> },
  { menuItem: "Followers", render: () => <Tab.Pane>Followers</Tab.Pane> },
  { menuItem: "Following", render: () => <Tab.Pane>Following</Tab.Pane> },
  { menuItem: "Hosted Events", render: () => <Tab.Pane>Events</Tab.Pane> },
];

const ProfileContent = () => {
  return (
    <Tab
      menu={{ fluid: true, vertical: true }}
      menuPosition={"right"}
      panes={panes}
    />
  );
};

export default ProfileContent;
