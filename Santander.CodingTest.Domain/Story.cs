using AutoMapper;
using Santander.CodingTest.DataProvider.Model;

namespace Santander.CodingTest.Domain;

public record class Story : IMapFrom<Item>
{
	public string? Title { get; init; }

	public string? Uri { get; init; }

	public string? PostedBy { get; init; }

	public string? Time { get; init; }

	public decimal? Score { get; init; }

	public decimal? CommentCount { get; init; }

	public void Mapping(Profile profile)
	{
		profile.CreateMap<Item, Story>()
			.ForMember(d => d.Uri, opt => opt.MapFrom(s => s.url))
			.ForMember( d => d.Title, opt => opt.MapFrom( s => s.title))
			.ForMember( d => d.Score, opt => opt.MapFrom( s => s.score))
			.ForMember(d => d.PostedBy, opt => opt.MapFrom(s => s.by))
			.ForMember(d => d.Time, opt => opt.MapFrom(s => HandleDateTimeField(s.time)))
			.ForMember(d => d.CommentCount, opt => opt.MapFrom(s => s.descendants));
	}

	private string HandleDateTimeField(double date)
	{
		try
		{
			if( double.IsRealNumber(date) )
			{
				return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(date).ToString("yyyy-MM-dd'T'HH:mm:ss+ff:ff"); 
			}
		}
		catch (Exception /*e*/){ }
		return string.Empty;
	}
}
