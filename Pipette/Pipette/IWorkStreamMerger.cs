using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pipette
{
	public interface IWorkStreamMerger<TItem>
	{
		IWorkItemStream<TItem> Merge(IEnumerable<IWorkItemStream<TItem>> streams);
	}
}
