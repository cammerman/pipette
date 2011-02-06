using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pipette.Standard
{
	public class MergeableStreams<TItem> : IMergeableStreams<TItem>
	{
		protected virtual IEnumerable<IWorkItemStream<TItem>> Streams
		{
			get;
			private set;
		}

		public MergeableStreams(IEnumerable<IWorkItemStream<TItem>> streams)
		{
			Streams = streams;
		}

		public IMergeableStreams<TItem> AndWith(IWorkItemStream<TItem> additionalStream)
		{
			return new
				MergeableStreams<TItem>(
					Streams.Append(additionalStream));
		}

		protected virtual IMergeableStreams<TItem> Accumulator(IMergeableStreams<TItem> runningProduct, IWorkItemStream<TItem> nextStream)
		{
			return runningProduct.AndWith(nextStream);
		}

		public IMergeableStreams<TItem> AndWith(IMergeableStreams<TItem> additionalStreams)
		{
			return
				Streams.Aggregate(
					additionalStreams,
					Accumulator);
		}

		public IWorkItemStream<TItem> Using(IWorkStreamMerger<TItem> merger)
		{
			return merger.Merge(Streams);
		}
	}
}
