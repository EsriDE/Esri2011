using Castle.Facilities.FactorySupport;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using EsriDE.Trials.CastleWindsor.ResolvingPrimitives.Contracts;
using EsriDE.Trials.CastleWindsor.ResolvingPrimitives.Implementations;
using NUnit.Framework;

namespace EsriDE.Trials.CastleWindsor.ResolvingPrimitives
{
	// ReSharper disable InconsistentNaming
	[TestFixture]
	public class Fixture
	{
		private IWindsorContainer _container;

		[Test]
		public void ResolveWithFluentSyntax()
		{
			InitializeContainerWithFluentSyntax();

			var o = _container.Resolve<IAbc>();
			Assert.That(o, !Is.Null, "Could not resolve IAbc");
		}

		private void InitializeContainerWithFluentSyntax()
		{
			_container = new WindsorContainer();
			_container.Register(Component.For<IAbc>().ImplementedBy<Abc>());
			_container.Register(Component.For<IXyz>().ImplementedBy<Xyz>());
			_container.Register(Component.For<IA>().ImplementedBy<A>());
			_container.Register(Component.For<IB>().ImplementedBy<B>());
			_container.Register(Component.For<IC>().ImplementedBy<C>());
		}

		[Test]
		public void ResolveWithRegisterAllTypesFromThisAssembly()
		{
			InitializeContainerWithRegisterAllTypesFromThisAssembly();

			var o = _container.Resolve<IAbc>();
			Assert.That(o, !Is.Null, "Could not resolve IAbc");
		}

		private void InitializeContainerWithRegisterAllTypesFromThisAssembly()
		{
			_container = new WindsorContainer();
			//_container.Register(AllTypes.FromThisAssembly().Pick());
			_container.Register(
				AllTypes
					.FromThisAssembly()
					//.Where(type => type.Namespace.StartsWith(
					//    "EsriDE.Trials.CastleWindsor.ResolvingPrimitives"))
					.Where(_ => true)
					.WithService
					.FirstInterface());
		}

		[Test]
		public void ResolveWithFactorySupportFacility()
		{
			return;
			_container.AddFacility<FactorySupportFacility>();
		}
	}
	// ReSharper restore InconsistentNaming
}