import { observer } from "mobx-react";
import React, { useState } from "react";
import { Button, Card, Grid, Header, Image, Tab } from "semantic-ui-react";
import { useProfileStore } from "../../../../hooks/useProfileStore";
import PhotoUploadWidget from "../PhotoUpload/PhotoUploadWidget";

const ProfilePhotos = () => {
  const {
    profile,
    isCurrentUser,
    uploadingFile,
    uploadPhoto,
    setAvatar,
    loadingAvatar,
    deletePhoto,
  } = useProfileStore();
  const [addPhotoMode, setAddPhotoMode] = useState(false);
  const [targetButton, setTargetButton] = useState<string | undefined>(
    undefined
  );
  const [targetDeleteButton, setTargetDeleteButton] = useState<
    string | undefined
  >(undefined);

  const handleUploadImage = async (photo: string) => {
    await uploadPhoto(photo);
    setAddPhotoMode(false);
  };

  return (
    <Tab.Pane>
      <Grid>
        <Grid.Column width={16} style={{ paddingBottom: 0 }}>
          <Header floated={"left"} icon={"image"} content={"Photos"} />
          {isCurrentUser && (
            <Button
              floated={"right"}
              basic
              content={addPhotoMode ? "Cancel" : "Add Photo"}
              onClick={() => setAddPhotoMode(!addPhotoMode)}
            />
          )}
        </Grid.Column>
        <Grid.Column width={16}>
          {addPhotoMode ? (
            <PhotoUploadWidget
              uploadingFile={uploadingFile}
              uploadPhoto={handleUploadImage}
            />
          ) : (
            <Card.Group itemsPerRow={5}>
              {profile &&
                profile.photos.map((photo) => (
                  <Card key={photo.id}>
                    <Image src={photo.url} />
                    {isCurrentUser && (
                      <Button.Group fluid widths={2}>
                        <Button
                          basic
                          positive
                          loading={loadingAvatar && targetButton === photo.id}
                          name={photo.id}
                          onClick={async (e) => {
                            setTargetButton(e.currentTarget.name);
                            await setAvatar(photo);
                            setTargetButton(undefined);
                          }}
                          disabled={photo.isAvatar}
                          content={"Main"}
                          style={{
                            padding: 0,
                            display: "flex",
                            alignItems: "center",
                            justifyContent: "center",
                          }}
                        />
                        <Button
                          basic
                          negative
                          icon={"trash"}
                          name={photo.id}
                          loading={
                            loadingAvatar && targetDeleteButton === photo.id
                          }
                          disabled={photo.isAvatar}
                          onClick={async (e) => {
                            setTargetDeleteButton(e.currentTarget.name);
                            await deletePhoto(photo);
                            setTargetDeleteButton(undefined);
                          }}
                        />
                      </Button.Group>
                    )}
                  </Card>
                ))}
            </Card.Group>
          )}
        </Grid.Column>
      </Grid>
    </Tab.Pane>
  );
};

export default observer(ProfilePhotos);
