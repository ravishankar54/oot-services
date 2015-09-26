using System.Text;
using Microsoft.Practices.Unity;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Reflection;
using CabAgeResolver;

namespace CabAgeResolver
{
    internal class RegisterComponent : IRegisterComponent
    {
        private readonly IUnityContainer _container;

        public RegisterComponent(IUnityContainer container)
        {
            this._container = container;
            //Register interception behaviour if any
        }

        public void RegisterType<TFrom, TTo>(bool withInterception = false) where TTo : TFrom
        {
            if (withInterception)
            {
                //register with interception 
            }
            else
            {
                this._container.RegisterType<TFrom, TTo>();
            }
        }

        public void RegisterTypeWithControlledLifeTime<TFrom, TTo>(bool withInterception = false) where TTo : TFrom
        {
            this._container.RegisterType<TFrom, TTo>(new ContainerControlledLifetimeManager());
        }
    }
}
