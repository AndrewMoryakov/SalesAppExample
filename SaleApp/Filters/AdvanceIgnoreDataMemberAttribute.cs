using System;
using System.Runtime.Serialization;

namespace SaleAppExample.Filters;

[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property | AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class AdvanceIgnoreDataMemberAttribute:Attribute
{
	
}