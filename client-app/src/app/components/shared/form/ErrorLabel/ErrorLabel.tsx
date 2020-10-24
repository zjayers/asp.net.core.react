import { AxiosResponse } from "axios";
import React from "react";
import { Message } from "semantic-ui-react";

interface IProps {
  error?: AxiosResponse;
  text?: string;
}

const ErrorLabel: React.FC<IProps> = ({ error, text }) => {
  const flattenValidationErrors = () => {
    if (error && error.data && Object.keys(error.data.errors).length > 0)
      return (
        <Message.List>
          {Object.values(error.data.errors)
            .flat()
            .map((e, i) => (
              <Message.Item key={i}>{e}</Message.Item>
            ))}
        </Message.List>
      );
  };

  return (
    <Message error>
      {flattenValidationErrors()}
      {text && <Message.Content content={text} />}
    </Message>
  );
};

export default ErrorLabel;
