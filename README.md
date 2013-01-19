# crossfit-benchmarks-services
============================

repo for crossfit benchmarks web services
## Site Url
* http://crossfitbenchmarkservices.azurewebsites.net

## Service Endpoints
You will find the following service uri's available to your clients
* WorkoutTypes => api/WorkoutTypes


### Workout Types
* this endpoint serves up DTO objects that define workout types
URI: [HttpGet] api/WorkoutTypes => returns a list of workout types


#### Sample Header:
> GET http://crossfitbenchmarkservices.azurewebsites.net/api/workouttypes HTTP/1.1
> Accept: application/json

#### Sample Response:
```javascript
[{
		"WorkoutTypeId" : "B",
		"Name" : "Benchmark"
	}, {
		"WorkoutTypeId" : "G",
		"Name" : "The Girls"
	}, {
		"WorkoutTypeId" : "H",
		"Name" : "The Heros"
	}
]
```

