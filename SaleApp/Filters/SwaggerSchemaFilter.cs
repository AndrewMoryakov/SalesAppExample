using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SaleAppExample.Filters;

public class SwaggerSchemaFilter : ISchemaFilter
{
	public void Apply(OpenApiSchema schema, SchemaFilterContext context)
	{
		if (schema?.Properties == null)
		{
			return;
		}

		var ignoreDataMemberProperties = context.Type.GetProperties()
			.Where(t => t.GetCustomAttribute<IgnoreDataMemberAttribute>() != null
			            || t.GetCustomAttribute<AdvanceIgnoreDataMemberAttribute>() != null);

		foreach (var ignoreDataMemberProperty in ignoreDataMemberProperties)
		{
			var propertyToHide = schema.Properties.Keys
				.SingleOrDefault(x => x.ToLower() == ignoreDataMemberProperty.Name.ToLower());

			if (propertyToHide != null)
			{
				schema.Properties.Remove(propertyToHide);
			}
		}
	}
}