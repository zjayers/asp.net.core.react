import { observer } from "mobx-react";
import React, { Fragment } from "react";
import { Menu, Header } from "semantic-ui-react";
import { Calendar } from "react-widgets";
import { useEventStore } from "../../../../hooks/useEventStore";

const ActivityFilters = () => {
  const { queryRepository, setQueryRepository } = useEventStore();

  return (
    <Fragment>
      <Menu vertical size={"large"} style={{ width: "100%", marginTop: 50 }}>
        <Header icon={"filter"} attached color={"teal"} content={"Filters"} />
        <Menu.Item
          active={queryRepository.size === 0}
          onClick={() => setQueryRepository("all", "true")}
          color={"blue"}
          name={"all"}
          content={"All Events"}
        />
        <Menu.Item
          active={queryRepository.has("isGoing")}
          onClick={() => setQueryRepository("isGoing", "true")}
          color={"blue"}
          name={"username"}
          content={"Events I'm Attending"}
        />
        <Menu.Item
          active={queryRepository.has("isHost")}
          onClick={() => setQueryRepository("isHost", "true")}
          color={"blue"}
          name={"host"}
          content={"Events I'm Hosting"}
        />
      </Menu>
      <Header
        icon={"calendar"}
        attached
        color={"teal"}
        content={"Select Date"}
      />
      <Calendar
        onChange={(date) => setQueryRepository("startDate", date!)}
        value={queryRepository.get("startDate") || new Date()}
      />
    </Fragment>
  );
};

export default observer(ActivityFilters);
