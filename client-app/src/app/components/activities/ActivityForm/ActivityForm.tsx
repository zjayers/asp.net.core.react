// * Imports
import React, { FormEvent, useState } from "react";
import { Button, Form, Segment } from "semantic-ui-react";
import { v4 as uuid } from "uuid";
import { IActivity } from "../../../../models";

// * Interfaces
interface IProps {
  selectedActivity: IActivity | null;
  setEditMode: (editMode: boolean) => void;
  handleCreateActivity: (activity: IActivity) => void;
  handleEditActivity: (activity: IActivity) => void;
}

// * Component
const ActivityForm: React.FC<IProps> = ({
  selectedActivity,
  setEditMode,
  handleCreateActivity,
  handleEditActivity,
}) => {
  // * Initial Form Values
  const initForm = () => {
    if (selectedActivity) {
      return selectedActivity;
    } else {
      return {
        id: "",
        title: "",
        category: "",
        description: "",
        date: "",
        city: "",
        venue: "",
      };
    }
  };

  const [activity, setActivity] = useState<IActivity>(initForm);
  const { title, description, category, date, city, venue } = activity;

  /**
   * Update state on Input Change
   * @param e
   */
  const handleInputChange = (
    e: FormEvent<HTMLInputElement | HTMLTextAreaElement>
  ) => {
    const { name, value } = e.currentTarget;
    setActivity({ ...activity, [name]: value });
  };

  /**
   * Handle Form Submission
   */
  const handleSubmit = () => {
    if (activity.id.length === 0) {
      const newActivity = {
        ...activity,
        id: uuid(),
      };
      return handleCreateActivity(newActivity);
    }

    handleEditActivity(activity);
  };

  return (
    <Segment clearing>
      <Form onSubmit={handleSubmit}>
        <Form.Input
          name={"title"}
          placeholder={"Title"}
          value={title}
          onChange={handleInputChange}
        />
        <Form.TextArea
          name={"description"}
          rows={2}
          placeholder={"Description"}
          value={description}
          onChange={handleInputChange}
        />
        <Form.Input
          name={"category"}
          placeholder={"Category"}
          value={category}
          onChange={handleInputChange}
        />
        <Form.Input
          name={"date"}
          type={"datetime-local"}
          placeholder={"Date"}
          value={date}
          onChange={handleInputChange}
        />
        <Form.Input
          name={"city"}
          placeholder={"City"}
          value={city}
          onChange={handleInputChange}
        />
        <Form.Input
          name={"venue"}
          placeholder={"Venue"}
          value={venue}
          onChange={handleInputChange}
        />
        <Button.Group widths={2}>
          <Button
            floated={"right"}
            positive
            type={"submit"}
            content={"submit"}
          />
          <Button
            floated={"right"}
            type={"button"}
            content={"cancel"}
            onClick={() => setEditMode(false)}
          />
        </Button.Group>
      </Form>
    </Segment>
  );
};

// * Exports
export default ActivityForm;
