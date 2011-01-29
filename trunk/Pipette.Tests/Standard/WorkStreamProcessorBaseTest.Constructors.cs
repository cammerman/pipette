using System;
using Moq;
using Xunit;

namespace Pipette.Tests.Standard
{
	using Pipette.Standard;
	
	public class WorkStreamProcessorBaseTest_Constructors
	{
		public WorkStreamProcessorBaseTest_Constructors ()
		{
		}
		
		[Fact]
		public void ctor_GivenNullArgument_ShouldThrowArgumentNullException()	
		{
			Assert.Throws<ArgumentNullException>(
				() => new WorkStreamProcessorBaseInheritorMock<String, String>(null));
		}
		
		[Fact]
		public void ctor_GivenAnArgument_StreamWorkShouldYieldTheArgument()	
		{
			var dummyStreamWork = new Mock<IStreamWork>().Object;
			
			var sut = new WorkStreamProcessorBaseInheritorMock<String, String>(dummyStreamWork);
			
			Assert.Same(dummyStreamWork, sut.PeekAtStreamWork);
		}
		
		[Fact]
		public void When_ConstructedWithNoArgCtor_StreamWorkShouldStandardStreamWorkInstance()
		{
			var sut = new WorkStreamProcessorBaseInheritorMock<String, String>();
			
			Assert.IsType<StreamWork>(sut.PeekAtStreamWork);
		}
	}
}

