import OpenaqClient from "./OpenaqClient";
import {useMessage} from "naive-ui";

export default class HttpOpenaqClient implements OpenaqClient {

  message = useMessage();
  
  async getCities() : Promise<any> {
    //var url = "https://api.openaq.org/v2/cities?limit=500&page=1&offset=0&sort=asc&country_id=ES&order_by=city";
    var url = "https://miguelperezcolom-openaq.azurewebsites.net/api/GetCitiesFunction";
    const data = await fetch(url)
      .then((response) => response.text())
      .then((text) => JSON.parse(text).results.map((r: any) => ({
        label: r.name,
        value: r.id
      })))
      .catch((error) => {
        this.message.error(error);
      });
    return data;
  }

  async getMeasurements(city: string) : Promise<any> {
    // var url = "https://api.openaq.org/v2/latest?limit=5000&page=1&offset=0&sort=desc&radius=1000&city="
    //   + encodeURIComponent(city) + "&order_by=lastUpdated&dumpRaw=false";
    var url = "https://miguelperezcolom-openaq.azurewebsites.net/api/GetMeasurementsFunction?city=" + encodeURIComponent(city);
    const data = await fetch(url)
      .then((response) => response.text())
      .then((text) => JSON.parse(text).results.map((m: any) => ({
            id: m.id,
            pos: m.position,
            prop: m.name,
            value: m.value,
            unit: m.unit,
          })))
      .catch((error) => {
        console.log(error);
      })
    return data;
  }

}