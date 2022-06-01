<template>
  <n-message-provider>
    <n-grid x-gap="12" cols="12" item-responsive>
      <n-grid-item offset="0 600:1 800:2 1200:3" span="12 600:10 800:8 1200:6">
        <query-view />
      </n-grid-item>
    </n-grid>
  </n-message-provider>
</template>

<script setup lang="ts">
import {NGrid, NGridItem, NMessageProvider,} from "naive-ui";
import QueryView from './components/QueryView.vue'</script>

<style>
</style>
