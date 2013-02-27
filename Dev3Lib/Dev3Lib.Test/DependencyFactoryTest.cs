using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dev3Lib.Web;
using Autofac;

namespace Dev3Lib.Test
{
    [TestClass]
    public class DependencyFactoryTest
    {
        [TestMethod]
        public void Resolve_Normal_ReturnInstance()
        {
            DependencyFactory.SetContainer(() =>
            {
                ContainerBuilder builder = new ContainerBuilder();
                builder.RegisterType<TestClass>();

                return builder.Build();
            });

            Assert.IsNotNull(DependencyFactory.Resolve<TestClass>());
        }

        class TestClass
        {
            public string Name { get { return "hello"; } }
        }

    }
}
