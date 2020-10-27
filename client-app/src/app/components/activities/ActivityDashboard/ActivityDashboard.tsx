import { observer } from "mobx-react";
import React, { useEffect, useState } from "react";
import InfiniteScroll from "react-infinite-scroller";
import { Grid, Loader } from "semantic-ui-react";
import { useEventStore } from "../../../../hooks/useEventStore";
import { useGuiStore } from "../../../../hooks/useGuiStore";
import { LoadingSpinner } from "../../shared";
import ActivityFilters from "../ActivityFilters/ActivityFilters";
import ActivityList from "../ActivityList/ActivityList";

// * Component
const ActivityDashboard = () => {
  const {
    getAllActivities,
    setPageNumber,
    eventPage,
    totalNumberOfPages,
  } = useEventStore();
  const { loadingInitial } = useGuiStore();

  const [loadingMore, setLoadingMore] = useState(false);

  const handleGetMoreEvents = async () => {
    setLoadingMore(true);
    setPageNumber(eventPage + 1);
    await getAllActivities();
    setLoadingMore(false);
  };

  // * Lifecycle
  useEffect(() => {
    getAllActivities();
  }, [getAllActivities]);

  return loadingInitial && eventPage === 0 ? (
    <LoadingSpinner content={"Loading activities..."} />
  ) : (
    <Grid>
      <Grid.Column width={10}>
        <InfiniteScroll
          pageStart={0}
          loadMore={handleGetMoreEvents}
          hasMore={!loadingMore && eventPage + 1 < totalNumberOfPages}
          initialLoad={false}
        >
          <ActivityList />
        </InfiniteScroll>
      </Grid.Column>
      <Grid.Column width={6}>
        <ActivityFilters />
      </Grid.Column>
      <Grid.Column width={10}>
        <Loader active={loadingMore} />
      </Grid.Column>
    </Grid>
  );
};

// * Exports
export default observer(ActivityDashboard);
