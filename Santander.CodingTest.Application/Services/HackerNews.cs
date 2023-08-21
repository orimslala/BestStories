using System.Text.Json;
using Santander.CodingTest.Application.Interfaces;
using Santander.CodingTest.DataProvider.Model;

namespace Santander.CodingTest.Application.Services;

public class HackerNews : IDataProvider
{
	private const string BaseUrl = "https://hacker-news.firebaseio.com";
	private readonly IHttpClientFactory _httpClientFactory;
	public HackerNews(IHttpClientFactory factory)
		=> (_httpClientFactory) = (factory);

	public async Task<IEnumerable<int>> GetBestStories()
	{
		var client = _httpClientFactory.CreateClient();
		var response = await client.GetAsync($"{BaseUrl}/v0/beststories.json");
		var result = await response.Content.ReadAsStringAsync();
		return JsonSerializer.Deserialize<List<int>>(result) ?? Enumerable.Empty<int>();
	}

	public async Task<Item?> GetStory(int id)
	{
		var client = _httpClientFactory.CreateClient();
		var response = await client.GetAsync($"{BaseUrl}/v0/item/{id}.json");
		var result = await response.Content.ReadAsStringAsync();
		return JsonSerializer.Deserialize<Item>(result);
	
	}
}
