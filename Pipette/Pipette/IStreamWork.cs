using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pipette
{
	public interface IStreamWork
	{
		IWorkItemStream<TItem> From<TItem>(IEnumerable<TItem> workItems);
	}
}
