using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pipette
{
	public interface IWorkStreamProcessor<TIn, TOut>
	{
		IWorkItemStream<TOut> Process(IEnumerable<TIn> stream, Action<TIn, Exception> processingFailed);
	}
}
