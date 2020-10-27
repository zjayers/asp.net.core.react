import React from "react";
import { Tab } from "semantic-ui-react";
import { useProfileStore } from "../../../../hooks/useProfileStore";
import ProfileDescription from "../ProfileDescription/ProfileDescription";
import ProfileFollowings from "../ProfileFollowings/ProfileFollowings";
import ProfilePhotos from "../ProfilePhotos/ProfilePhotos";

const panes = [
  { menuItem: "About", render: () => <ProfileDescription /> },
  { menuItem: "Photos", render: () => <ProfilePhotos /> },
  { menuItem: "Followers", render: () => <ProfileFollowings /> },
  { menuItem: "Following", render: () => <ProfileFollowings /> },
  { menuItem: "Hosted Events", render: () => <Tab.Pane>Events</Tab.Pane> },
];

const ProfileContent = () => {
  const { setActiveTab } = useProfileStore();

  return (
    <Tab
      menu={{ fluid: true, vertical: true }}
      menuPosition={"right"}
      panes={panes}
      onTabChange={(e, data) => setActiveTab(data.activeIndex)}
    />
  );
};

export default ProfileContent;
