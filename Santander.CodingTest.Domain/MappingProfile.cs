
using AutoMapper;
using System.Reflection;

namespace Santander.CodingTest.Domain;
public class MappingProfile : Profile
{
	public MappingProfile() 
	{ 
		MappingsFromAssembly(Assembly.GetExecutingAssembly());
	}
	private void MappingsFromAssembly(Assembly assembly)
	{
		var types = assembly.GetExportedTypes()
							.Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
							.ToList();
		foreach (var type in types)
		{
			var instance = Activator.CreateInstance(type);
			var methodInfo = type.GetMethod("Mapping");
			methodInfo?.Invoke(instance, new object[] { this });
		}
	}
}