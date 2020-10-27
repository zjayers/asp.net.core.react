import { observer } from "mobx-react";
import React from "react";
import {
  RouteProps,
  RouteComponentProps,
  Redirect,
  Route,
} from "react-router-dom";
import { useUserStore } from "../../hooks/useUserStore";

interface IProps extends RouteProps {
  component: React.ComponentType<RouteComponentProps<any>>;
}

const AuthRoute: React.FC<IProps> = ({
  component: Component,
  ...otherProps
}) => {
  const { isUserLoggedIn } = useUserStore();

  return (
    <Route
      {...otherProps}
      render={(props) =>
        isUserLoggedIn ? <Component {...props} /> : <Redirect to={"/"} />
      }
    />
  );
};

export default observer(AuthRoute);