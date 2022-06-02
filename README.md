# OpenAQ web client

This project contains a simplified web client for the OpenAQ API (https://api.openaq.org/docs).

## The project

This was quite a simple one (3 cards only), and the board is available at https://github.com/users/miguelperezcolom/projects/3/views/1

Mainly, I have built a SPA which relies in its own backend which, in fact, is just a facade for the OpenAQ API. Some hexagonal/clean architecture and CQRS complete the picture. 

## The Web Client

I have used Vue + TS to build the web client. It uses Pinia (https://pinia.vuejs.org/) to build the state store and Naive UI (https://www.naiveui.com) as the design system.

All the logic was first implemented at the client side (no need for anything else, indeed) and, when it worked, I migrated the facade to Azure functions. To put some c# there.

The app has been published using Netlify at it's available at https://glistening-bublanina-53138f.netlify.app/

## The API

I have implemented only 2 methods: one for getting the cities list and another for retrieving the latest measurements for a city.

They (simple GETs) are available at:

- https://miguelperezcolom-openaq.azurewebsites.net/api/GetCitiesFunction
- https://miguelperezcolom-openaq.azurewebsites.net/api/GetMeasurementsFunction?city=Madrid

They have been published as Azure functions using an Azure free account.

## Pending

I have not yet focused on the last feature (enable the user to replay the last queries). 
For the sake of simplicity, I would just implement this feature in the client side to avoid adding authentication. Just some nice DDD stuff in the client side using the browser storage.

I have not created the technical documentation for my API. That could also easily be done, if needed.

## Conclusion

Up to now I have create a web client using Vue and an API which has been published as Azure Functions. Nothing complex, here.




