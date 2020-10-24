import { observer } from "mobx-react";
import React, { Fragment, useEffect } from "react";
import { Route, Switch, useLocation } from "react-router-dom";
import { ToastContainer } from "react-toastify";
import { Container } from "semantic-ui-react";
import {
  ActivityDashboard,
  ActivityDetails,
  ActivityForm,
} from "./components/activities";
import { LoadingSpinner, NavBar } from "./components/shared";
import ModalContainer from "./components/shared/modals/ModalContainer";
import LoginForm from "./components/user/LoginForm/LoginForm";
import { useGuiStore } from "./hooks/useGuiStore";
import { useUserStore } from "./hooks/useUserStore";
import HomePage from "./pages/HomePage/HomePage";
import NotFound from "./pages/NotFound/NotFound";

const App = () => {
  const location = useLocation();
  const { setAppAsLoaded, appLoaded } = useGuiStore();
  const { getUser, token } = useUserStore();

  useEffect(() => {
    token ? getUser().finally(() => setAppAsLoaded()) : setAppAsLoaded();
  }, [getUser, setAppAsLoaded, token]);

  if (!appLoaded) return <LoadingSpinner content={"Loading app..."} />;

  // * Render
  return (
    <Fragment>
      <ModalContainer />
      <ToastContainer position={"bottom-right"} />
      <Route exact path={"/"} component={HomePage} />
      <Route
        path={"/(.+)"}
        render={() => (
          <Fragment>
            <NavBar />
            <Container className={"app__list-container"}>
              <Switch>
                <Route
                  exact
                  path={"/activities"}
                  component={ActivityDashboard}
                />
                <Route path={"/activities/:id"} component={ActivityDetails} />
                <Route
                  key={location.key}
                  path={["/createActivity", "/manage/:id"]}
                  component={ActivityForm}
                />
                <Route path={"/login"} component={LoginForm} />
                <Route component={NotFound} />
              </Switch>
            </Container>
          </Fragment>
        )}
      />
    </Fragment>
  );
};

// * Exports
export default observer(App);
