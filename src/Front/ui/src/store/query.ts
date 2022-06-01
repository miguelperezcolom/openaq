import { reactive, ref, watch, computed } from "vue";
import { defineStore } from "pinia";
import HttpOpenaqClient from "../sdk/HttpOpenaqClient";

export const useQueryStore = defineStore("query", () => {
  const api = new HttpOpenaqClient();

  const city = ref("");
  const cities = ref([]);
  const fetchCities = async () => {
    cities.value = await api.getCities();
  };
  
  const measurements = ref([]);
  const loading = ref(false);
  const fetchMeasurements = async () => {
    loading.value = true;
    measurements.value = await api.getMeasurements(city.value);
    loading.value = false;
  };

  return {
    city,
    cities,
    measurements,
    loading,
    fetchCities,
    fetchMeasurements,
  };
});
