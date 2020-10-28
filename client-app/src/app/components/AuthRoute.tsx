import { observer } from "mobx-react";
import React from "react";
import {
  Redirect,
  Route,
  RouteComponentProps,
  RouteProps,
} from "react-router-dom";
import { useUserStore } from "../../hooks/useUserStore";

interface IProps extends RouteProps {
  component: React.ComponentType<RouteComponentProps<any>>;
}

const AuthRoute: React.FC<IProps> = ({
  component: Component,
  ...otherProps
}) => {
  const { isTokenValid, setUserToNull } = useUserStore();

  if (isTokenValid) {
    return (
      <Route {...otherProps} render={(props) => <Component {...props} />} />
    );
  }

  setUserToNull();
  return <Route {...otherProps} render={(props) => <Redirect to={"/"} />} />;
};

export default observer(AuthRoute);
