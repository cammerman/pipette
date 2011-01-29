using System;
namespace Pipette
{
	internal static class GenericExtensions
	{
		public static TSource ThrowIfNull<TSource>(this TSource source, String argumentName)
		{
			if (source == null)
				throw new ArgumentNullException(argumentName, "Argument cannot be null");
			
			return source;
		}
	}
}

