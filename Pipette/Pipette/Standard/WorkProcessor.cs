using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pipette.Standard
{
	public class WorkProcessor : IWorkProcessor
	{
		protected virtual IStreamWork StreamWork
		{
			get;
			private set;
		}

		public WorkProcessor()
		{
			StreamWork = new StreamWork();
		}

		public WorkProcessor(IStreamWork streamWork)
		{
			StreamWork = streamWork.ThrowIfNull("streamWork");
		}

		public virtual IWorkStreamProcessor<TIn, TOut> From<TIn, TOut>(Func<TIn, TOut> processorDelegate)
		{
			return new DelegateWorkProcessor<TIn, TOut>(StreamWork, processorDelegate);
		}
	}
}
