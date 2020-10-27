import React, { useRef } from "react";
import Cropper from "react-cropper";
import "cropperjs/dist/cropper.css";

interface IProps {
  setImage: (file: string) => void;
  imagePreview: string;
}

const ProfilePhotoCropper: React.FC<IProps> = ({ setImage, imagePreview }) => {
  const cropperRef = useRef<HTMLImageElement>(null);

  const onCrop = () => {
    const imageElement: any = cropperRef?.current;
    const cropper: any = imageElement?.cropper;
    setImage(cropper.getCroppedCanvas().toDataURL());
  };

  return (
    <Cropper
      src={imagePreview}
      style={{
        height: 200,
        width: "100%",
      }}
      initialAspectRatio={1}
      viewMode={1}
      preview={".img-preview"}
      dragMode={"move"}
      scalable
      cropBoxMovable
      cropBoxResizable
      guides={false}
      crop={onCrop}
      ref={cropperRef}
    />
  );
};

export default ProfilePhotoCropper;
