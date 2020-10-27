import { observer } from "mobx-react-lite";
import React, { Fragment, useEffect, useState } from "react";
import { Button, Grid, Header } from "semantic-ui-react";
import ProfilePhotoCropper from "../ProfilePhotoCropper/ProfilePhotoCropper";
import ProfilePhotoDropZone from "../ProfilePhotoDropZone/ProfilePhotoDropZone";

interface IProps {
  uploadingFile: boolean;
  uploadPhoto: (file: string) => void;
}

const PhotoUploadWidget: React.FC<IProps> = ({
  uploadingFile,
  uploadPhoto,
}) => {
  const [files, setFiles] = useState<any[]>([]);
  const [image, setImage] = useState<string | null>(null);

  useEffect(
    () => () => files.forEach((file) => URL.revokeObjectURL(file.preview)),
    [files]
  );

  return (
    <Fragment>
      <Grid>
        <Grid.Column width={4}>
          <Header
            color="teal"
            sub
            content="Step 1 - Add Photo"
            textAlign={"center"}
          />
          <ProfilePhotoDropZone setFiles={setFiles} />
        </Grid.Column>
        <Grid.Column width={1} />
        <Grid.Column width={4}>
          <Header
            sub
            color="teal"
            content="Step 2 - Resize image"
            textAlign={"center"}
          />
          {files.length > 0 && (
            <ProfilePhotoCropper
              setImage={setImage}
              imagePreview={files[0].preview}
            />
          )}
        </Grid.Column>
        <Grid.Column width={1} />
        <Grid.Column width={4}>
          <Header
            sub
            color="teal"
            content="Step 3 - Preview & Upload"
            textAlign={"center"}
          />
          {files.length > 0 && (
            <Fragment>
              <div
                className={"img-preview"}
                style={{
                  minHeight: "200px",
                  minWidth: "200px",
                  maxWidth: "200px",
                  overflow: "hidden",
                }}
              />
              <Button.Group
                widths={2}
                style={{
                  minWidth: "200px",
                  maxWidth: "200px",
                }}
              >
                <Button
                  positive
                  icon={"check"}
                  loading={uploadingFile}
                  onClick={() => uploadPhoto(image!)}
                />
                <Button
                  icon={"close"}
                  disabled={uploadingFile}
                  onClick={() => setFiles([])}
                />
              </Button.Group>
            </Fragment>
          )}
        </Grid.Column>
      </Grid>
    </Fragment>
  );
};

export default observer(PhotoUploadWidget);
