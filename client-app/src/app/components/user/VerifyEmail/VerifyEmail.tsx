import queryString from "query-string";
import React, { useEffect, useState } from "react";
import { RouteComponentProps } from "react-router-dom";
import { toast } from "react-toastify";
import { Button, Header, Icon, Segment } from "semantic-ui-react";
import { usersApi } from "../../../../api";
import { useModalStore } from "../../../../hooks/useModalStore";
import LoginForm from "../LoginForm/LoginForm";

const VerifyEmail: React.FC<RouteComponentProps> = ({ location }) => {
  const Status = {
    Verifying: "Verifying",
    Failed: "Failed",
    Success: "Success",
  };

  const [status, setStatus] = useState(Status.Verifying);
  const { openModal } = useModalStore();
  const { token, email } = queryString.parse(location.search);

  useEffect(() => {
    usersApi
      .verifyEmail(token as string, email as string)
      .then(() => setStatus(Status.Success))
      .catch(() => setStatus(Status.Failed));
  }, [Status.Failed, Status.Success, email, token]);

  const handleConfirmEmailResend = async () => {
    await usersApi.resendEmailVerification(email as string);
    toast.success("Verification email sent. Please check your inbox.");
  };

  const getBody = () => {
    switch (status) {
      case Status.Verifying:
        return <p>Verifying...</p>;
      case Status.Failed:
        return (
          <div className={"center"}>
            <p>
              Verification failed. Please try re-sending the verification email.
            </p>
            <Button
              primary
              size={"huge"}
              content={"Resend Email"}
              onClick={handleConfirmEmailResend}
            />
          </div>
        );
      case Status.Success:
        return (
          <div className={"center"}>
            <p>Email has been verified- You can now login!</p>
            <Button
              primary
              size={"large"}
              content={"Login"}
              onClick={() => openModal(<LoginForm />)}
            />
          </div>
        );
    }
  };
  return (
    <Segment placeholder>
      <Header>
        <Icon name={"envelope"} />
        Email Verification
      </Header>
      <Segment.Inline>{getBody()}</Segment.Inline>
    </Segment>
  );
};

export default VerifyEmail;
