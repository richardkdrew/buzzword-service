using System;
using BuzzwordService.Helpers;
using Nancy;

namespace BuzzwordService 
{
    public class BuzzwordModule : NancyModule
    {
        public BuzzwordModule(IBuzzwordDataStore buzzwordDataStore)
        {  
            Get("/buzzwords/{category}", parameters => {
                string category = ((string)parameters.category).ToLower();
                if(!buzzwordDataStore.CategoryExists(category)) return HttpStatusCode.NotFound;                      

                return new {
                    buzzwords = buzzwordDataStore.GetByCategory(category),
                    category = category,
                    serviceId = Environment.MachineName
                };       
            });                   
        }
    }
}