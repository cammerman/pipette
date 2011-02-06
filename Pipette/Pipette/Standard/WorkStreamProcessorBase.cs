using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pipette.Standard
{
	public abstract class WorkStreamProcessorBase<TIn, TOut> : IWorkStreamProcessor<TIn, TOut>
	{
		protected virtual IStreamWork StreamWork
		{
			get;
			private set;
		}

		public WorkStreamProcessorBase()
		{
			StreamWork = new StreamWork();
		}

		public WorkStreamProcessorBase(IStreamWork streamWork)
		{
			StreamWork = streamWork.ThrowIfNull("streamWork");
		}

		protected virtual TResult TryOp<TResult>(Func<TResult> op, Func<Exception, TResult> processingFailed)
		{
			try
			{
				return op();
			}
			catch (Exception ex)
			{
				return processingFailed(ex);
			}
		}

		protected virtual TResult TryOp<TResult>(TIn workItem, Func<TIn, TResult> op, Func<TIn, Exception, TResult> processingFailed)
		{
			try
			{
				return op(workItem);
			}
			catch (Exception ex)
			{
				return processingFailed(workItem, ex);
			}
		}

		protected virtual Func<TIn, Exception, TResult> CallbackAndContinue<TResult>(Action<TIn, Exception> processingFailed, TResult continueValue)
		{
			return
				(batch, ex) =>
				{
					processingFailed(batch, ex);
					return continueValue;
				};
		}

		protected virtual Func<Exception, TResult> CallbackAndContinue<TResult>(Action<Exception> processingFailed, TResult continueValue)
		{
			return
				(ex) =>
				{
					processingFailed(ex);
					return continueValue;
				};
		}

		protected virtual Func<TIn, Action<Exception>> FailedCallbackGenerator(Action<TIn, Exception> callback)
		{
			return
				batch =>
					ex => callback(batch, ex);
		}

		public abstract IWorkItemStream<TOut> Process(IEnumerable<TIn> stream, Action<TIn, Exception> processingFailed);
	}
}
