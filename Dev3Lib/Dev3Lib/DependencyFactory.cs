using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Dev3Lib
{
    public static class DependencyFactory
    {
        const string _dependencyFactory = "{EE9E78D1-7740-4C18-B139-3A323E79E238}";
        private static Func<IContainer> _containerFunc;
        private static readonly object _obj = new object();
        private static IContainer _container;
        private static IContainer Container
        {
            get
            {
                if (_container != null)
                    return _container;
                else
                {
                    lock (_obj)
                    {
                        if (_container == null)
                        {
                            _container = _containerFunc();
                        }
                    }
                }

                return _container;
            }
        }


        public static void SetContainer(Func<IContainer> setContainer)
        {
            _containerFunc = setContainer;
        }

        public static T Resolve<T>()
        {
            if (_scope == null)
                throw new InvalidOperationException("scope has not been set");

            return _scope.Resolve<T>();
        }

        private static ILifetimeScope _scope = null;
        private static bool _isDisposed = true;
        public static DependencyScope BeginScope()
        {
            if (!_isDisposed)
                throw new InvalidOperationException("can't start scope");

            _scope = Container.BeginLifetimeScope();

            return new DependencyScope(ref _scope, ref _isDisposed);
        }

    }

    public class DependencyScope : IDisposable
    {
        private ILifetimeScope _scope;
        private bool _isDisposed;
        public DependencyScope(ref ILifetimeScope scope, ref bool isDisposed)
        {
            _scope = scope;
            _isDisposed = isDisposed;
        }
        public void Dispose()
        {
            _scope.Disposer.Dispose();
            _scope.Dispose();
            _scope = null;
            _isDisposed = true;
        }
    }

}
