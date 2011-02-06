using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pipette
{
	public interface IWorkItemStream<TItem> : IEnumerable<TItem>
	{
		IWorkItemStream<TOut> PipeTo<TOut>(IWorkStreamProcessor<TItem, TOut> processor, Action<TItem, Exception> processingFailed);
		IMergeableStreams<TItem> MergeWith(IWorkItemStream<TItem> otherStream);
		IMergeableStreams<TItem> MergeWith(IMergeableStreams<TItem> otherStreams);
		void Process();
	}
}
