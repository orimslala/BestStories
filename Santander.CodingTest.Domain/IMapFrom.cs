
using AutoMapper;

namespace Santander.CodingTest.Domain;
public interface IMapFrom<T>
{
	void Mapping(Profile profile)
		=> profile.CreateMap(typeof(T), GetType());
}
