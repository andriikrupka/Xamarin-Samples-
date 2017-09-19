using ForceTouchNavigationSample.DataAccess;
using ForceTouchNavigationSample.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;

namespace ForceTouchNavigationSample
{
    public class MvxApp : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();
            Mvx.ConstructAndRegisterSingleton<IEmployeesProvider, EmployeesProvider>();
            Mvx.RegisterType<MainViewModel, MainViewModel>();
            Mvx.RegisterType<DetailsViewModel, DetailsViewModel>();
            RegisterAppStart<MainViewModel>();
        }
    }
}
