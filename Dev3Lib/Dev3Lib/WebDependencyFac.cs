using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Dev3Lib
{
    public static class WebDependencyFac
    {
        const string _dependencyFactory = "{EE9E78D1-7740-4C18-B139-3A323E79E238}";
        private static Func<IContainer> _containerFunc;
        private static readonly object _obj = new object();
        private static IContainer _container;

        private static IContainer Container
        {
            get
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

        public const string ScopeKey = "{F7171B48-D1E8-42E7-8EB5-F9583022AE26}";

        private static ILifetimeScope Scope
        {
            get
            {
                return HttpContext.Current.Items[ScopeKey] as ILifetimeScope;
            }
            set
            {
                HttpContext.Current.Items[ScopeKey] = value;
            }
        }
        public static DependencyScope BeginScope()
        {
            if (Scope != null)
                throw new InvalidOperationException("can't start scope");

            Scope = Container.BeginLifetimeScope();

            return new DependencyScope();
        }

        public class DependencyScope : IDisposable
        {
            public DependencyScope()
            {
            }
            public void Dispose()
            {
                var scope = HttpContext.Current.Items[ScopeKey] as ILifetimeScope;
                if (scope != null)
                {
                    scope.Disposer.Dispose();
                    scope.Dispose();
                    HttpContext.Current.Items[ScopeKey] = null;
                }
            }
        }
    }
}
