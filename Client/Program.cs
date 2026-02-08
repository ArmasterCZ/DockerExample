//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

//string port = "32778";
////string url = $"http://localhost:{port}/api/events/";
//string url = $"http://localhost:{port}";
////string url = $"http://localhost:32778/index.html";
////string url = "http://localhost:5286";

//var httpClient = new HttpClient();
//var request = new HttpRequestMessage(HttpMethod.Get, $"{url}/api/v1/User/Get");
//using var response = await httpClient.SendAsync(request);
//if (response.IsSuccessStatusCode)
//{
//    var content = await response.Content.ReadAsStringAsync();
//    Console.WriteLine(content);
//}
//else
//{
//    Console.WriteLine($"Request failed with status code: {response.StatusCode}");
//}


////Client.UserModel model = new Client.UserModel()
////{
////    Id = "someGuid",
////    Age = 10,
////    FirstName = "John",
////    LastName = "Doe"    
////};

////var httpClient = new HttpClient();
////var client = new NSwagContract.Client(baseUrl: url, httpClient);
//////await client.CreateRandomAsync();
////var result = await client.GetAsync();
////foreach (var item in result) { 
////    Console.WriteLine($"Id: {item.Id}, Name: {item.FirstName} {item.FirstName}, Age: {item.Age}");
////}


////Uri requestUri = new Uri("http://localhost:5239/api/v1/User/Get");
////HttpClient httpClient2 = new HttpClient();
////HttpResponseMessage httpResponse = new HttpResponseMessage();
////httpResponse = await httpClient2.GetAsync(requestUri);

////var restClient = new RestClient("https://v3.fusesport.com/api/events/")
////{
////    Authenticator = new HttpBasicAuthenticator("xxxxx", "xxxxx")
////};
////var request = new RestRequest(Method.GET);
////request.AddHeader("cache-control", "no-cache");
////request.AddHeader("Authorization", "Token 9944b09199c62bcf9418ad846dd0e4bbdfc6ee4b");
////request.AddHeader("content-type", "application/json");
////IRestResponse response = client.Execute(request);

//Console.WriteLine("Press any key to exit.");
//Console.ReadLine();
