// * Imports
import { observer } from "mobx-react";
import React, { useEffect, useState } from "react";
import { Field, Form as FinalForm } from "react-final-form";
import { useHistory, useParams } from "react-router-dom";
import {
  combineValidators,
  composeValidators,
  hasLengthGreaterThan,
  isRequired,
} from "revalidate";
import { Button, Form, Grid, Segment } from "semantic-ui-react";
import { v4 as uuid } from "uuid";
import { IEvent } from "../../../../models";
import { combinedDateAndTime } from "../../../../util/combine-date-and-time";
import { categoryOptions } from "../../../../store/data/category-options";
import { useEventStore } from "../../../../hooks/useEventStore";
import { useGuiStore } from "../../../../hooks/useGuiStore";

import {
  DateInput,
  SelectionInput,
  TextAreaInput,
  TextInput,
} from "../../shared";

const validate = combineValidators({
  title: isRequired({ message: "The event title is required." }),
  category: isRequired({ message: "The event category is required." }),
  description: composeValidators(
    isRequired({ message: "The event description is required." }),
    hasLengthGreaterThan(4)
  )({ message: "Description must be at least 5 characters" }),
  venue: isRequired("The event venue is required"),
  city: isRequired("The event city is required."),
  date: isRequired("The event date is required."),
  time: isRequired("The event time is required."),
});

// * Component
const ActivityForm = () => {
  const {
    selectedEvent,
    createOneActivity,
    editOneActivity,
    getOneActivity,
    clearSelectedActivity,
  } = useEventStore();

  const { submitting } = useGuiStore();

  const history = useHistory();
  const { id } = useParams();

  const [activity, setActivity] = useState<IEvent>(selectedEvent);
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    if (id) {
      setLoading(true);
      getOneActivity(id)
        .then((activity) => {
          setActivity(activity);
        })
        .finally(() => setLoading(false));
    }
  }, [clearSelectedActivity, getOneActivity, id]);

  const { title, description, category, date, city, venue, time } = activity;

  /**
   * Handle Form Submission
   */
  const handleFinalFormSubmit = async (values: any) => {
    const dateAndTime = combinedDateAndTime(values.date, values.time);
    const { date, time, ...activity } = values;
    activity.date = dateAndTime;

    if (!activity.id) {
      return await createOneActivity({
        ...activity,
        id: uuid(),
      });
    }

    await editOneActivity(activity);
  };

  return (
    <Grid>
      <Grid.Column width={16}>
        <Segment clearing>
          <FinalForm
            initialValues={activity}
            validate={validate}
            onSubmit={handleFinalFormSubmit}
            render={({ handleSubmit, invalid, pristine }) => (
              <Form onSubmit={handleSubmit} loading={loading}>
                <Field
                  name={"title"}
                  placeholder={"Title"}
                  value={title}
                  component={TextInput}
                />
                <Field
                  name={"description"}
                  rows={2}
                  placeholder={"Description"}
                  value={description}
                  component={TextAreaInput}
                />
                <Field
                  name={"category"}
                  placeholder={"Category"}
                  options={categoryOptions}
                  value={category}
                  component={SelectionInput}
                />
                <Form.Group widths={"equal"}>
                  <Field
                    name={"date"}
                    placeholder={"Date"}
                    value={date}
                    date
                    component={DateInput}
                  />
                  <Field
                    name={"time"}
                    placeholder={"Time"}
                    value={time}
                    time
                    component={DateInput}
                  />
                </Form.Group>
                <Field
                  name={"city"}
                  placeholder={"City"}
                  value={city}
                  component={TextInput}
                />
                <Field
                  name={"venue"}
                  placeholder={"Venue"}
                  value={venue}
                  component={TextInput}
                />
                <Button.Group widths={2}>
                  <Button
                    loading={submitting}
                    floated={"right"}
                    positive
                    type={"submit"}
                    content={"submit"}
                    disabled={loading || invalid || pristine}
                  />
                  <Button
                    floated={"right"}
                    type={"button"}
                    content={"cancel"}
                    disabled={loading}
                    onClick={() =>
                      id
                        ? history.push(`/events/${id}`)
                        : history.push(`/events`)
                    }
                  />
                </Button.Group>
              </Form>
            )}
          />
        </Segment>
      </Grid.Column>
    </Grid>
  );
};

// * Exports
export default observer(ActivityForm);
