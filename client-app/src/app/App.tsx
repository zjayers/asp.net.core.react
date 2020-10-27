import { observer } from "mobx-react";
import React, { Fragment, useEffect } from "react";
import { Route, Switch, useLocation } from "react-router-dom";
import { ToastContainer } from "react-toastify";
import { Container } from "semantic-ui-react";
import { useGuiStore } from "../hooks/useGuiStore";
import { useUserStore } from "../hooks/useUserStore";
import {
  ActivityDashboard,
  ActivityDetails,
  ActivityForm,
} from "./components/activities";
import { LoadingSpinner, NavBar } from "./components/shared";
import ModalContainer from "./components/shared/modals/ModalContainer";
import HomePage from "./pages/HomePage/HomePage";
import NotFound from "./pages/NotFound/NotFound";
import ProfilePage from "./pages/ProfilePage/ProfilePage";

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
                <Route exact path={"/events"} component={ActivityDashboard} />
                <Route path={"/events/:id"} component={ActivityDetails} />
                <Route
                  key={location.key}
                  path={["/createEvent", "/manage/:id"]}
                  component={ActivityForm}
                />
                <Route path={"/profile/:username"} component={ProfilePage} />
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
