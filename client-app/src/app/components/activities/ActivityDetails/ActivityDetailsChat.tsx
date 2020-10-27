// * Imports
import { formatDistance } from "date-fns";
import { observer } from "mobx-react";
import React, { Fragment, useEffect } from "react";
import { Field, Form as FinalForm } from "react-final-form";
import { Link } from "react-router-dom";
import {
  Button,
  Comment,
  Divider,
  Form,
  Header,
  Segment,
} from "semantic-ui-react";
import { useCommentStore } from "../../../../hooks/useCommentStore";
import { IEvent } from "../../../../models";
import { TextAreaInput } from "../../shared";

// * Interfaces
interface IProps {
  activity: IEvent;
}

// * Component
const ActivityDetailsChat: React.FC<IProps> = ({ activity }) => {
  const {
    createHubConnection,
    stopHubConnection,
    addComment,
  } = useCommentStore();

  useEffect(() => {
    createHubConnection(activity.id);

    return stopHubConnection;
  }, [activity.id, createHubConnection, stopHubConnection]);

  return (
    <Fragment>
      <Segment
        textAlign="center"
        attached="top"
        inverted
        color="teal"
        style={{ border: "none" }}
      >
        <Header>Chat about this event</Header>
      </Segment>
      <Segment attached>
        <Comment.Group>
          {activity &&
            activity.comments &&
            activity.comments.map((comment) => (
              <Fragment key={comment.id}>
                <Comment style={{ marginBottom: "20px" }}>
                  <Comment.Avatar src={comment.image || "assets/user.png"} />
                  <Comment.Content>
                    <Comment.Author
                      as={Link}
                      to={`/profile/${comment.userName}`}
                    >
                      {comment.displayName}
                    </Comment.Author>
                    <Comment.Metadata>
                      <div>
                        {formatDistance(comment.createdAt, new Date())} ago
                      </div>
                    </Comment.Metadata>
                    <Comment.Text>{comment.body}</Comment.Text>
                  </Comment.Content>
                </Comment>
                <Divider />
              </Fragment>
            ))}

          <FinalForm
            onSubmit={addComment}
            render={({ handleSubmit, submitting, form }) => (
              <Form onSubmit={() => handleSubmit()?.then(() => form.reset())}>
                <Field
                  name={"body"}
                  component={TextAreaInput}
                  rows={4}
                  placeholder={"Add your comment"}
                />
                <Button
                  content="Add Reply"
                  labelPosition="left"
                  icon="edit"
                  primary
                  loading={submitting}
                />
              </Form>
            )}
          />
        </Comment.Group>
      </Segment>
    </Fragment>
  );
};

// * Exports
export default observer(ActivityDetailsChat);
