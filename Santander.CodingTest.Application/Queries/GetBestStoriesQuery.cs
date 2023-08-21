using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Santander.CodingTest.Domain;
using BestStoriesCollection = System.Collections.Generic.IEnumerable<Santander.CodingTest.Domain.Story>;

using MediatR;
using System.Net.Http;
using Santander.CodingTest.Application.Interfaces;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Santander.CodingTest.DataProvider.Model;

namespace Santander.CodingTest.Application.Queries;

public record GetBestStoriesQuery(int count) : IRequest<BestStoriesCollection>;


public class GetBestStoriesQueryHandler : IRequestHandler<GetBestStoriesQuery, BestStoriesCollection?>
{
	private readonly IMapper _mapper;
	private readonly ILogger<GetBestStoriesQueryHandler> _logger;
	private readonly IDataProvider _dataProvider;
	public GetBestStoriesQueryHandler(IMapper mapper, IDataProvider dataProvider, ILogger<GetBestStoriesQueryHandler> logger)
		=> (_mapper, _dataProvider, _logger) = (mapper, dataProvider, logger);

	public async Task<BestStoriesCollection?> Handle(GetBestStoriesQuery request, CancellationToken cancellationToken)
	{
		try
		{
			var results = await _dataProvider.GetBestStories();
			if (results.Any())
			{
				var tasks = new List<Task<Item?>>();
				foreach( var itm in results)
				{
					tasks.Add(_dataProvider.GetStory(itm));
				}
				await Task.WhenAll(tasks);

				return tasks.Where(r => r.Result != null)
							?.Select(r => _mapper.Map<Story>(r.Result))
							?.OrderByDescending(r => r.Score).Take(request.count);

			}
		}
		catch(Exception e) { _logger.LogError(e.Message); }
		return Enumerable.Empty<Story>();
	}
}
	
