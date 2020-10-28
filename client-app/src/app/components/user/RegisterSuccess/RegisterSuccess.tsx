import React from "react";
import { RouteComponentProps } from "react-router-dom";
import queryString from "query-string";
import { toast } from "react-toastify";
import { Segment, Header, Icon, Button } from "semantic-ui-react";
import { usersApi } from "../../../../api";

const RegisterSuccess: React.FC<RouteComponentProps> = ({ location }) => {
  const { email } = queryString.parse(location.search);

  const handleConfirmEmailResend = async () => {
    await usersApi.resendEmailVerification(email as string);
    toast.success("Verification email sent. Please check your inbox.");
  };

  return (
    <Segment placeholder>
      <Header icon>
        <Icon name={"check"} />
        Successfully registered!
      </Header>

      <Segment.Inline>
        <div className={"center"}>
          <p>
            Please check your email (including junk folder) for the verification
            email.
          </p>
          {email && (
            <>
              <p>
                Didn't receive the email? Please click the button below to
                resend a verification email.
              </p>
              <Button
                primary
                content={"Resend Email"}
                size={"huge"}
                onClick={handleConfirmEmailResend}
              />
            </>
          )}
        </div>
      </Segment.Inline>
    </Segment>
  );
};

export default RegisterSuccess;
