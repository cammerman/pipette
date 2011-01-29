using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pipette.Standard
{
	public class DelegateWorkProcessor<TIn, TOut> : WorkStreamProcessorBase<TIn, TOut>
	{
		protected virtual Func<TIn, TOut> ProcessorDelegate
		{
			get;
			private set;
		}

		public DelegateWorkProcessor(Func<TIn, TOut> processorDelegate)
			:base()
		{
			ProcessorDelegate = processorDelegate.ThrowIfNull("processorDelegate");
		}

		public DelegateWorkProcessor(IStreamWork streamWork, Func<TIn, TOut> processorDelegate)
			:base(streamWork)
		{
			ProcessorDelegate = processorDelegate.ThrowIfNull("processorDelegate");
		}

		protected virtual IEnumerable<TOut> ProcessItems(IEnumerable<TIn> stream, Action<TIn, Exception> processingFailed)
		{
			foreach (var item in stream)
			{
				yield return
					TryOp(
						item,
						ProcessorDelegate,
						CallbackAndContinue(
							processingFailed,
							default(TOut)));
			}
		}

		public override IWorkItemStream<TOut> Process(IEnumerable<TIn> stream, Action<TIn, Exception> processingFailed)
		{
			return
				StreamWork.From(
					ProcessItems(stream, processingFailed));
		}
	}
}
