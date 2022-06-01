<template>
  <n-data-table
      ref="table"
      :columns="columns"
      :data="query.measurements"
      :loading="query.loading"
      :row-key="(row) => row.id"
      max-height="250"
  />
</template>

<script setup lang="ts">
import {NDataTable,} from "naive-ui";
import {useQueryStore} from "../store/query";

const query = useQueryStore();

const columns = [
  {
    title: "Location",
    key: "pos",
    sorter: "default",
  },
  {
    title: "Property",
    key: "prop",
    sorter: "default",
  },
  {
    title: "Value",
    key: "value",
    sorter: "default",
  },
  {
    title: "Unit",
    key: "unit",
    sorter: "default",
  }
];

</script>


<style scoped>
</style>
