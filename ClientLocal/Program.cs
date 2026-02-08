Console.WriteLine("Program started.");

string port = "32778";
//string port = "5286";
string url = $"http://localhost:{port}";

var httpClient = new HttpClient();
var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/api/v1/User/GetRandom");
using var response = await httpClient.SendAsync(request);
if (response.IsSuccessStatusCode)
{
    var content = await response.Content.ReadAsStringAsync();
    Console.WriteLine(content);
}
else
{
    Console.WriteLine($"Request failed with status code: {response.StatusCode}");
}

Console.WriteLine("Program ended.");
Console.ReadLine();