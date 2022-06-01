﻿import OpenaqClient from "./OpenaqClient";
import {useMessage} from "naive-ui";

export default class HttpOpenaqClient implements OpenaqClient {

  message = useMessage();
  
  async getCities() : Promise<any> {
    const data = await fetch("https://api.openaq.org/v2/cities?limit=500&page=1&offset=0&sort=asc&country_id=ES&order_by=city")
      .then((response) => response.text())
      .then((text) => JSON.parse(text).results.map((r: any) => ({
        label: r.city,
        value: r.city
      })))
      .catch((error) => {
        this.message.error(error);
      });
    return data;
  }

  async getMeasurements(city: string) : Promise<any> {
    const data = await fetch("https://api.openaq.org/v2/latest?limit=5000&page=1&offset=0&sort=desc&radius=1000&city="
      + encodeURIComponent(city) + "&order_by=lastUpdated&dumpRaw=false")
      .then((response) => response.text())
      .then((text) => JSON.parse(text).results.map((r: any) => r.measurements.map((x: any) => ({...x, pos: r.location}))).flatMap((m: any) => m).map((m: any) => ({
            id: m.pos + "-" + m.parameter,
            pos: m.pos,
            prop: m.parameter,
            value: m.value,
            unit: m.unit,
          })))
      .catch((error) => {
        console.log(error);
      })
    return data;
  }

}