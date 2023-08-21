using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Santander.CodingTest.Application.Interfaces;
using Santander.CodingTest.DataProvider.Model;
using Santander.CodingTest.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Santander.CodingTest.Application.Queries;

public record GetStoryQuery(int id) : IRequest<Story>;

public class GetStoryQueryHandler : IRequestHandler<GetStoryQuery, Story?>
{
	private readonly IMapper _mapper;
	private readonly ILogger<GetStoryQueryHandler> _logger;
	private readonly IDataProvider _dataProvider;
	public GetStoryQueryHandler(IMapper mapper, IDataProvider dataProvider, ILogger<GetStoryQueryHandler> logger)
		=> (_mapper, _dataProvider, _logger) = (mapper, dataProvider, logger);

	public async Task<Story?> Handle(GetStoryQuery request, CancellationToken cancellationToken)
	{
		try
		{
			var item = await _dataProvider.GetStory(request.id);
			return item != null ? _mapper.Map<Story>(item) : null;
		}
		catch (Exception e) { _logger.LogError(e.Message); }
		return null;
	}
}

