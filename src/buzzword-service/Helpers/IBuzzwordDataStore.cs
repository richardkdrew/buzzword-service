using System.Collections.Generic;

namespace BuzzwordService.Helpers
{
    public interface IBuzzwordDataStore
    {
        List<string> GetByCategory(string category);
        bool CategoryExists(string category);
    }
}