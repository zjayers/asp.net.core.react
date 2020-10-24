// * Imports
import React from "react";
import { FieldRenderProps } from "react-final-form";
import { DateTimePicker } from "react-widgets";
import { Form, FormFieldProps, Label } from "semantic-ui-react";

// * Interfaces
interface IProps extends FieldRenderProps<Date>, FormFieldProps {}

// * Component
const DateInput: React.FC<IProps> = ({
  input,
  width,
  id = null,
  placeholder,
  date = false,
  time = false,
  meta: { touched, error },
  ...otherProps
}) => {
  return (
    <Form.Field error={touched && !!error} width={width}>
      <DateTimePicker
        {...otherProps}
        placeholder={placeholder}
        value={input.value || null}
        onBlur={input.onBlur}
        onKeyDown={(e) => e.preventDefault()}
        onChange={input.onChange}
        date={date}
        time={time}
      />
      {touched && error && (
        <Label basic color={"red"}>
          {error}
        </Label>
      )}
    </Form.Field>
  );
};

// * Exports
export default DateInput;
