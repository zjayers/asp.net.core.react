import React, { useEffect, useState } from "react";
import { List } from "semantic-ui-react";
import { api } from "../services/api";

interface IValue {
  id: number;
  name: string;
}

function ValueList() {
  const [values, setValues] = useState<IValue[]>([]);

  useEffect(() => {
    fetchValuesFromApi();
  }, []);

  /**
   * Fetch Values from the API and store them in state
   */
  const fetchValuesFromApi = async () => {
    const { data: newValues } = await api.get("/api/values");
    setValues((values) => [...values, ...newValues]);
  };

  return (
    <div>
      <List>
        {values.map((value: IValue) => (
          <List.Item key={value.id}>{value.name}</List.Item>
        ))}
      </List>
    </div>
  );
}

export default ValueList;
