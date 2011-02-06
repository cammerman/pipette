using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pipette.Standard
{
	public class StreamWork : IStreamWork
	{
		public virtual IWorkItemStream<TItem> From<TItem>(IEnumerable<TItem> workItems)
		{
			return new WorkItemStream<TItem>(workItems);
		}
	}
}
