using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pipette.Standard
{
	public interface IWorkProcessor
	{
		IWorkStreamProcessor<TIn, TOut> From<TIn, TOut>(Func<TIn, TOut> processor);
	}
}
