using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pipette
{
	public interface IMergeableStreams<TItem>
	{
		IMergeableStreams<TItem> AndWith(IWorkItemStream<TItem> additionalStream);
		IMergeableStreams<TItem> AndWith(IMergeableStreams<TItem> additionalStreams);
		IWorkItemStream<TItem> Using(IWorkStreamMerger<TItem> merger);
	}
}
