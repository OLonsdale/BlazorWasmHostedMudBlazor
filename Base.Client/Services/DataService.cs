using Base.Shared.Statics;

namespace Base.Client.Services;

public class DataService(HttpClient httpClient)
{

    public async Task<string> GetTestMessage()
    {
        var res = await httpClient.GetAsync(ApiRoutes.GetTestMessage);
        if (res.IsSuccessStatusCode)
        {
            return await res.Content.ReadAsStringAsync();
        }
        else
        {
            return "Error";
        }
        
    }

    
}