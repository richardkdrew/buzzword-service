using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using BuzzwordService.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.IO;

namespace BuzzwordService
{
    public class Startup
    {        
        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddRouting();

            // Register the main service
            services.AddSingleton<IBuzzwordService, BuzzwordService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IBuzzwordService service)
        {
            RequestDelegate RequestHandler = async context =>
            {
                try 
                {
                    // Get the request
                    var serviceRequest = new BuzzwordServiceRequest {
                        //Category = context.Request.Query["category"]
                        Category = context.GetRouteValue("category").ToString()
                    };            

                    // var serviceRequest = new BuzzwordServiceRequest {
                    //     Category = context.Request.Query["category"]
                    // };         
                                        
                    //BuzzwordServiceRequest serviceRequest;  

                    // using(var reader = new StreamReader(context.Request.Body))
                    // {
                    //     var request = reader.ReadToEndAsync().Result;
                    //     serviceRequest = JsonConvert.DeserializeObject<BuzzwordServiceRequest>(request);
                    // }         

                    // Call the service
                    var serviceResponse = service.GetBuzzwords(serviceRequest);

                    // Construct the response
                    var response = JsonConvert.SerializeObject(serviceResponse);
                    context.Response.StatusCode = StatusCodes.Status200OK;
                    context.Response.ContentType = "application/json";

                    // Send the response
                    await context.Response.WriteAsync(response);
                }
                // Handle any expected failures
                // Handle any unexpected failures
                catch(Exception ex)
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    await context.Response.WriteAsync(ex.ToString());
                }                    
            };   
            
            // Build the route and tell the app to use it
            app.UseRouter(new RouteBuilder(app).MapGet("buzzwords/{category}", RequestHandler).Build());                                
        }
    }
}
