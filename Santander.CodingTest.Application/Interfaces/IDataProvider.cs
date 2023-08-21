using Santander.CodingTest.DataProvider.Model;

namespace Santander.CodingTest.Application.Interfaces;

public interface IDataProvider
{
	Task<Item?> GetStory(int id);

	Task<IEnumerable<int>> GetBestStories();
}
