import { observer } from "mobx-react";
import { Simulate } from "react-dom/test-utils";
import { Button, Divider, Form, Header } from "semantic-ui-react";
import { Field, Form as FinalForm } from "react-final-form";
import { combineValidators, isRequired } from "revalidate";

import ErrorLabel from "../../shared/form/ErrorLabel/ErrorLabel";
import { FORM_ERROR } from "final-form";
import { IUserFormValues } from "../../../../models";
import React from "react";
import { TextInput } from "../../shared";
import { useAuthRedirect } from "../../../../hooks/useAuthRedirect";
import { useUserStore } from "../../../../hooks/useUserStore";
import SocialLogin from "../SocialLogin/SocialLogin";

const validate = combineValidators({
  email: isRequired("Email"),
  password: isRequired("Password"),
});

const LoginForm = () => {
  const { login, fbLogin, loadingFacebook } = useUserStore();

  return useAuthRedirect(
    <FinalForm
      onSubmit={(values: IUserFormValues) =>
        login(values).catch((e) => ({
          [FORM_ERROR]: e,
        }))
      }
      validate={validate}
      render={({
        handleSubmit,
        submitting,
        submitError,
        invalid,
        pristine,
        dirtySinceLastSubmit,
      }) => (
        <Form onSubmit={handleSubmit} error>
          <Header
            as={"h2"}
            content={"Login"}
            color={"teal"}
            textAlign={"center"}
          />
          <Field
            name={"email"}
            component={TextInput}
            placeholder={"Email"}
            type={"email"}
          />
          <Field
            name={"password"}
            component={TextInput}
            placeholder={"Password"}
            type={"password"}
          />
          {submitError && !dirtySinceLastSubmit && (
            <ErrorLabel text={"Invalid email or password"} />
          )}
          <Button
            fluid
            disabled={(invalid && !dirtySinceLastSubmit) || pristine}
            color={"teal"}
            loading={submitting}
            content={"Login"}
          />
          <Divider horizontal>Or</Divider>
          <SocialLogin fbCallback={fbLogin} loading={loadingFacebook} />
        </Form>
      )}
    />
  );
};

export default observer(LoginForm);
