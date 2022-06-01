export default interface OpenaqClient {
  
  getCities() : any;

  getMeasurements(city: string) : any;

}