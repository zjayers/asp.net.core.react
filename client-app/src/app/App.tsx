import { observer } from "mobx-react";
import React, { Fragment } from "react";
import { Route, Switch, useLocation } from "react-router-dom";
import { ToastContainer } from "react-toastify";
import { Container } from "semantic-ui-react";
import {
  ActivityDashboard,
  ActivityDetails,
  ActivityForm,
} from "./components/activities";
import { NavBar } from "./components/shared";
import HomePage from "./pages/HomePage/HomePage";
import NotFound from "./pages/NotFound/NotFound";

const App = () => {
  const location = useLocation();

  // * Render
  return (
    <Fragment>
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
