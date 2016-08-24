using BuzzwordService.Contracts;
using BuzzwordService.Helpers;
using System;

namespace BuzzwordService 
{
    public class BuzzwordService : IBuzzwordService
    {
        public BuzzwordServiceResponse GetBuzzwords(BuzzwordServiceRequest request)
        {            
            string[] words = GetHelper(request.Category).GetBuzzwords();

            var response = new BuzzwordServiceResponse();
            response.AddRange(words);

            return response;
        }

        private IBuzzwordHelper GetHelper(string category)
        {
            // Handle a null string
            category = string.IsNullOrEmpty(category) ? "General" : category;

            switch(category.ToLower())
            {
                case "technology":
                    return new TechnologyBuzzwordHelper();
                case "politics":
                    return new PoliticsBuzzwordHelper();
                case "education":
                    return new EducationBuzzwordHelper();
                case "general":                    
                    return new GeneralBuzzwordhelper();
                default:
                    throw new Exception("Unrecognised buzzword category");
            }            
        }
    }
}