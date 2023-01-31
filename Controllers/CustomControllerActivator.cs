using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace SaleAppExample.Controllers;

public class CustomControllerActivator : IControllerActivator
{
	private readonly IServiceProvider _serviceProvider;

	public CustomControllerActivator(IServiceProvider serviceProvider)
	{
		_serviceProvider = serviceProvider;
	}

	public object Create(ControllerContext context)
	{
		// return _serviceProvider.GetRequiredService(context.ActionDescriptor.ControllerTypeInfo.AsType());
		Type controllerType = context.ActionDescriptor.ControllerTypeInfo.AsType();
		return _serviceProvider.GetService(controllerType);
	}

	public void Release(ControllerContext context, object controller)
	{
		// Custom logic to release resources held by the controller
	}
}