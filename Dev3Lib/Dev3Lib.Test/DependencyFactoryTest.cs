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

            using (DependencyFactory.BeginScope())
            {
                Assert.IsNotNull(DependencyFactory.Resolve<TestClass>());
            }

        }

        [TestMethod]
        public void Resolve_NestedScope()
        {
            DependencyFactory.SetContainer(() =>
            {
                ContainerBuilder builder = new ContainerBuilder();
                builder.RegisterType<TestClass>();

                return builder.Build();
            });

            using (DependencyFactory.BeginScope())
            {
                using (DependencyFactory.BeginScope())
                {
                    DependencyFactory.Resolve<TestClass>();
                }

                Assert.IsFalse(DependencyFactory.IsScopeEmpty());
            }

            Assert.IsTrue(DependencyFactory.IsScopeEmpty());
        }
        class TestClass
        {
            public string Name { get { return "hello"; } }
        }

    }
}
