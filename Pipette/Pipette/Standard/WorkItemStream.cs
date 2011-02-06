using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pipette.Standard
{
	public class WorkItemStream<TItem> : IWorkItemStream<TItem>
	{
		protected virtual IEnumerable<TItem> RawStream
		{
			get;
			private set;
		}

		public WorkItemStream(IEnumerable<TItem> rawStream)
		{
			RawStream = rawStream.EmptyIfNull();
		}

		public virtual IWorkItemStream<TOut> PipeTo<TOut>(IWorkStreamProcessor<TItem, TOut> processor, Action<TItem, Exception> processingFailed)
		{
			return processor.Process(this, processingFailed);
		}

		public virtual IEnumerator<TItem> GetEnumerator()
		{
			return RawStream.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public virtual IMergeableStreams<TItem> MergeWith(IWorkItemStream<TItem> otherStream)
		{
			return new MergeableStreams<TItem>(new IWorkItemStream<TItem>[] { this, otherStream });
		}

		public virtual IMergeableStreams<TItem> MergeWith(IMergeableStreams<TItem> otherStreams)
		{
			return otherStreams.AndWith(this);
		}

		public virtual void Process()
		{
			foreach (var item in RawStream)
			{
				// Do nothing. The act of iterating triggers all deferred work.
			}
		}
	}
}
