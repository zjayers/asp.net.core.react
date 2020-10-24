import React from "react";
import { Form as FinalForm, Field } from "react-final-form";
import { Button, Form } from "semantic-ui-react";
import { useUserStore } from "../../../hooks/useUserStore";
import { TextInput } from "../../shared";

const LoginForm = () => {
  const { login } = useUserStore();

  return (
    <FinalForm
      onSubmit={login}
      render={({ handleSubmit }) => (
        <Form onSubmit={handleSubmit}>
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
          <Button positive content={"Login"} />
        </Form>
      )}
    />
  );
};

export default LoginForm;
