using System.Net.Http.Json;

var httpClient = new HttpClient();


var task1 = httpClient.PostAsJsonAsync(new Uri("http://localhost:5197/add-book-request"),
    new AddBookRequest("Dr. Seuss", "1 Fish 2 Fish"));

// var task2 = httpClient.PostAsJsonAsync(new Uri("http://localhost:5197/add-book-request"),
//     new AddBookRequest("Dr. Seuss", "Green Eggs and Ham"));

// var task3 = httpClient.PostAsJsonAsync(new Uri("http://localhost:5197/add-book-request"),
//     new AddBookRequest("Dr. Seuss", "The Lorax"));
//
// var task4 = httpClient.PostAsJsonAsync(new Uri("http://localhost:5197/add-book-request"),
//     new AddBookRequest("Dr. Seuss", "Cat in the Hat"));

var results = await Task.WhenAll(task1);


public record AddBookRequest(string AuthorId, string Title);
public record EditBookRequest(string AuthorId, string Title, string NewTitle);
