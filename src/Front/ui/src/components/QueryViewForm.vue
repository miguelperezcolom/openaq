<template>
  <n-form
      ref="formRef"
      inline
      :label-width="80"
      :model="query"
      :rules="rules"
  >
    <n-form-item label="City" path="city">
      <n-select v-model:value="query.city" :options="query.cities" style="min-width: 250px;"/>
    </n-form-item>
    
    <n-form-item>
      <n-button @click="search" type="primary">
        <template #icon>
          <n-icon>
            <search-icon />
          </n-icon>
        </template>
        Search
      </n-button>
    </n-form-item>
  </n-form>
</template>

<script setup lang="ts">
import {onMounted, ref} from 'vue'
import {FormInst, NSelect, NButton, NForm, NFormItem, NIcon, useMessage, FormRules} from "naive-ui";
import {Search as SearchIcon} from "@vicons/ionicons5";
import {useQueryStore} from "../store/query";

const query = useQueryStore();

const formRef = ref<FormInst | null>(null);
const message = useMessage();

const rules: FormRules = {
  city: {
    required: true,
    type: "string",
    message: "Please select a valid city",
    trigger: ["input"],
  },
};

const search = (e: MouseEvent) => {
  e.preventDefault();
  formRef.value?.validate((errors) => {
    if (!errors) {
      query.fetchMeasurements();
    } else {
      //message.error("Invalid");
    }
  });
};

onMounted(() => {
  query.fetchCities();
});

</script>


<style scoped>
</style>
