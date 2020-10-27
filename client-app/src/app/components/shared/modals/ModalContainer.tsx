import { observer } from "mobx-react";
import React from "react";
import { Modal } from "semantic-ui-react";
import { useModalStore } from "../../../../hooks/useModalStore";

const ModalContainer = () => {
  const {
    modal: { open, body },
    closeModal,
  } = useModalStore();

  return (
    <Modal open={open} onClose={closeModal} size={"mini"} dimmer={"blurring"}>
      <Modal.Content>{body}</Modal.Content>
    </Modal>
  );
};

export default observer(ModalContainer);
