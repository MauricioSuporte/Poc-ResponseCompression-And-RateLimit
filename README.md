# Poc Response Compression And Rate Limit

## Description
This repository contains a C# application that demonstrates the usage of Response Compression and Rate Limiting in ASP.NET Core. The application is built using the ASP.NET Core 7 framework, and it showcases how to implement response compression and rate limiting techniques to optimize web API performance and improve API security.

## Features
The application includes the following features:

### Response Compression
The application implements response compression using ASP.NET Core's built-in middleware for gzip compression. This reduces the size of the response payload, resulting in faster transmission over the network and improved performance for clients with limited bandwidth. The implementation includes configuration settings for customizing the compression type, content types, and compression for HTTPS connections.

### Rate Limiting
The application also includes rate limiting functionality using ASP.NET Core's middleware for rate limiting. It allows you to limit the rate at which API requests can be made from a particular client within a specified time window. This helps to prevent abuse and protect your API from malicious attacks. The implementation includes configuration settings for specifying the rate limits, including the number of requests allowed, the time window for counting requests, the order in which requests are processed and optionally requeuing any requests.

## Installation and Usage
To run the application locally, follow these steps:

1) Clone the repository to your local machine.
2) Open the solution in Visual Studio or any other C# IDE.
3) Build the solution to restore NuGet packages and compile the application.
4) Update the configuration settings for response compression and rate limiting in the appsettings.json file, if needed.
5) Run the application using the built-in development server or by publishing it to a hosting environment of your choice.
6) Access the API endpoints using a web browser, Postman, or any other REST client to see the response compression and rate limiting in action.

## Configuration
If you want to change how Response Copression and Rate Limit work, feel free to change the settings in Program.cs.

## License
This project is licensed under the MIT License.
