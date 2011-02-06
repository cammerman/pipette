using System;
using System.Linq;
using System.Collections.Generic;

namespace Pipette
{
	internal static class IEnumerable_T_Extensions
	{
		public static IEnumerable<TItem> Append<TItem>(this IEnumerable<TItem> source, TItem item)
		{
			source.ThrowIfNull("source");
			
			return
				Enumerable.Repeat(item, 1)
					.Concat(source);
		}
		
		public static IEnumerable<TItem> EmptyIfNull<TItem>(this IEnumerable<TItem> source)
		{
			if (source == null)
				return Enumerable.Empty<TItem>();
			
			return source;
		}
	}
}

