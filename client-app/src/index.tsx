import React from "react";
import ReactDOM from "react-dom";
import { Router } from "react-router-dom";
import "react-toastify/dist/ReactToastify.min.css";
import dateFnsLocalizer from "react-widgets-date-fns";

import "react-widgets/dist/css/react-widgets.css";
import "semantic-ui-css/semantic.min.css";
import App from "./app/App";
import { history } from "./app/features/browser-history";
import ScrollToTop from "./app/features/scroll-to-top";
import "./index.css";
import * as serviceWorker from "./util/serviceWorker";

// Call the date localizer
dateFnsLocalizer();

ReactDOM.render(
  <Router history={history}>
    <ScrollToTop />
    <App />
  </Router>,
  document.getElementById("root")
);

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
