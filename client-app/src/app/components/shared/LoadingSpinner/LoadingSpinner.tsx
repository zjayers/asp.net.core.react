// * Imports
import React from "react";
import { Dimmer, Loader } from "semantic-ui-react";

// * Interfaces
interface IProps {
  inverted?: boolean;
  content?: string;
}

// * Component
const LoadingSpinner: React.FC<IProps> = ({ inverted = true, content }) => {
  return (
    <Dimmer active inverted={inverted}>
      <Loader content={content} />
    </Dimmer>
  );
};

// * Exports
export default LoadingSpinner;
