using Bonus.DataModel.UnitOfWork;
using System.ComponentModel.Composition;
using UnityResolver;

namespace Bonus.DataModel.DependencyResolver
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IUnitOfWork, UnitOfWork.UnitOfWork>();
        }
    }
}
