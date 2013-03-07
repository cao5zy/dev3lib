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
        const string _scopeKey = "{F7171B48-D1E8-42E7-8EB5-F9583022AE26}";

        private static Func<IContainer> _containerFunc;
        private static readonly object _obj = new object();
        private static IContainer _container = null;
        private static ILifetimeScope _scope = null;

        private static IContainer Container
        {
            get
            {
                if (_container != null)
                {
                    return _container;
                }
                else
                {
                    if (HttpContext.Current != null)
                    {
                        var container = HttpContext.Current.Application[_dependencyFactory] as IContainer;
                        if (container != null)
                            return container;
                        else
                        {
                            lock (_obj)
                            {
                                var container1 = HttpContext.Current.Application[_dependencyFactory] as IContainer;
                                if (container1 == null)
                                {
                                    HttpContext.Current.Application[_dependencyFactory] = _containerFunc();
                                }
                            }

                            return (IContainer)HttpContext.Current.Application[_dependencyFactory];
                        }
                    }
                    else
                    {
                        lock (_obj)
                        {
                            if (_container == null)
                            {
                                _container = _containerFunc();
                            }

                            return _container;
                        }
                    }
                }
            }
        }

        public static ILifetimeScope Scope
        {
            get
            {
                if (HttpContext.Current == null)
                    return _scope;
                else
                    return HttpContext.Current.Items[_scopeKey] as ILifetimeScope;
            }
            set
            {
                if (HttpContext.Current == null)
                    _scope = value;
                else
                    HttpContext.Current.Items[_scopeKey] = value;
            }
        }

        public static void SetContainer(Func<IContainer> setContainer)
        {
            _containerFunc = setContainer;
        }

        public static T Resolve<T>()
        {
            if (Scope == null)
                throw new InvalidOperationException("scope has not been set");

            return Scope.Resolve<T>();
        }

        public static DependencyScope BeginScope()
        {
            if (Scope != null)
                throw new InvalidOperationException("can't start scope");

            Scope = Container.BeginLifetimeScope();
            return new DependencyScope();
        }

    }

    public class DependencyScope : IDisposable
    {
        public void Dispose()
        {
            DependencyFactory.Scope.Disposer.Dispose();
            DependencyFactory.Scope.Dispose();
            DependencyFactory.Scope = null;
        }
    }

}
