# ubiquity-api-client
C# implementation of a Ubiquity api client

## AWS Parameters
In order to be able to run some integration tests you should ensure that you have access to the following AWS parameters :
```awsParams
/[environment]/Trakx/Ubiquity/ApiClient/UbiquityApiConfiguration/ApiKey
/CiCd/Trakx/Ubiquity/ApiClient/UbiquityApiConfiguration/ApiKey
```

## How to regenerate C# API clients

* If you work with external API, you probably need to update OpenAPI definition added to the project. It's usually openApi3.yaml file.
* Do right click on the project and select Edit Project File. In the file change value of `GenerateApiClient` property to true.
* Rebuild the project. `NSwag` target will be executed as post action.
* The last thing to be done is to run integration test `OpenApiGeneratedCodeModifier` that will rewrite auto generated C# classes to use C# 9 features like records and init keyword.
