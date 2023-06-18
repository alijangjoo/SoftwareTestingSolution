namespace TestingSolution.TestProject.UI.ConsumerApp
{
    public static class ConsumerApiClient
    {
        static public async Task<HttpResponseMessage> ValidateDateTimeUsingProviderApi(string dateTimeToValidate, string baseUri)
        {
            using (var client = new HttpClient { BaseAddress = new Uri(baseUri) })
            {
                try
                {
                    var response = await client.GetAsync($"/api/provider?validDateTime={dateTimeToValidate}");
                    return response;
                }
                catch (Exception ex)
                {
                    throw new Exception("There was a problem connecting to Provider API.", ex);
                }
            }
        }
    }
}