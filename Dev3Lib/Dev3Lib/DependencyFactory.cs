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
        private static ContainerBuilder _containerBuilder = null;
        private static ILifetimeScope _scope = null;
        private static int _scopeCount = 0;

        public static void AddScopeCount()
        {
            _scopeCount++;
        }

        public static void MinusScopeCount()
        {
            if (_scopeCount == 0)
                throw new InvalidOperationException("No scope to minus. It is an internal operation");

            _scopeCount--;
        }

        public static bool IsLastScope()
        {
            return _scopeCount == 1;
        }

        public static bool IsScopeEmpty()
        {
            return _scopeCount == 0;
        }

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
                                    if (_containerFunc != null)
                                    {
                                        HttpContext.Current.Application[_dependencyFactory] = _containerFunc();
                                        _containerFunc = null;
                                    }
                                    else if (_containerBuilder != null)
                                    {
                                        HttpContext.Current.Application[_dependencyFactory] = _containerBuilder.Build();
                                        _containerBuilder = null;
                                    }
                                    else
                                        throw new InvalidOperationException("no container is initialized");
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
                                if (_containerFunc != null)
                                {
                                    _container = _containerFunc();
                                    _containerFunc = null;
                                }
                                else if (_containerBuilder != null)
                                {
                                    _container = _containerBuilder.Build();
                                    _containerBuilder = null;
                                }
                                else
                                    throw new InvalidOperationException("no container is initialized");
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
            if ((Scope != null && _scopeCount == 0) || (Scope == null && _scopeCount != 0))
                throw new InvalidOperationException("can't start scope");

            if (_scopeCount == 0)
            {
                Scope = Container.BeginLifetimeScope();
            }
            return new DependencyScope();
        }

        public static void PartialSetContainer(Action<ContainerBuilder> containerBuilderFunc)
        {
            if (_containerFunc != null)
                throw new InvalidOperationException("the other container has been initialized");

            if (_containerBuilder != null)
                containerBuilderFunc(_containerBuilder);
            else
            {
                lock (_obj)
                {
                    if (_containerBuilder == null)
                    {
                        _containerBuilder = new ContainerBuilder();
                    }

                    containerBuilderFunc(_containerBuilder);
                }
            }
        }



    }

    public class DependencyScope : IDisposable
    {
        public DependencyScope()
        {
            DependencyFactory.AddScopeCount();
        }
        public void Dispose()
        {
            if (DependencyFactory.IsLastScope())
            {
                DependencyFactory.Scope.Disposer.Dispose();
                DependencyFactory.Scope.Dispose();
                DependencyFactory.Scope = null;
            }

            DependencyFactory.MinusScopeCount();
        }
    }

}
