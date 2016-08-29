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
                    // Construct the request
                    BuzzwordServiceRequest request;            

                    using(var reader = new StreamReader(context.Request.Body))
                    {
                        var content = reader.ReadToEndAsync().Result;
                        request = JsonConvert.DeserializeObject<BuzzwordServiceRequest>(content);
                    }         

                    // Construct the response
                    var response = JsonConvert.SerializeObject(service.GetBuzzwords(request));
                    context.Response.StatusCode = StatusCodes.Status200OK;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(response);
                }
                catch(Exception ex)
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    await context.Response.WriteAsync(ex.ToString());
                }                    
            };   
            
            // Build the route and tell the app to use it
            app.UseRouter(new RouteBuilder(app).MapPost("", RequestHandler).Build());                                
        }
    }
}