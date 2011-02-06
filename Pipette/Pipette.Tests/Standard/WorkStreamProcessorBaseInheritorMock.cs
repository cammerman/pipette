using System;
using System.Collections.Generic;

namespace Pipette.Tests.Standard
{
	using Pipette.Standard;
	
	public class WorkStreamProcessorBaseInheritorMock<TIn, TOut> : WorkStreamProcessorBase<TIn, TOut>
	{
		public WorkStreamProcessorBaseInheritorMock()
			:base()
		{
		}
		
		public WorkStreamProcessorBaseInheritorMock(IStreamWork streamWork)
			:base(streamWork)
		{
		}
		
		public override IWorkItemStream<TOut> Process(IEnumerable<TIn> stream, Action<TIn, Exception> processingFailed)
		{
			throw new NotImplementedException ();
		}
		
		public virtual IStreamWork PeekAtStreamWork
		{
			get { return StreamWork; }
		}
	}
}

