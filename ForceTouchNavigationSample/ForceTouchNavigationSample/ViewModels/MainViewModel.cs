using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using ForceTouchNavigationSample.DataAccess;
using ForceTouchNavigationSample.Models;
using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;

namespace ForceTouchNavigationSample.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly IEmployeesProvider _employeesProvider;
        private List<Employee> _employees;
        private readonly IMvxNavigationService _navigationService;

        public MainViewModel(IEmployeesProvider employeesProvider, IMvxNavigationService navigationService)
        {
            _employeesProvider = employeesProvider;
            _navigationService = navigationService;
            ViewDetailsCommand = new MvxAsyncCommand<Models.Employee>(ViewDetailsAsync);
        }

        private Task ViewDetailsAsync(Employee employee)
        {
            return _navigationService.Navigate<ChildViewModel, Employee>(employee);
        }

        public MvxAsyncCommand<Employee> ViewDetailsCommand { get; set; }

        public List<Employee> Employee
        {
            get => _employees;
            set
            {
                if (value != _employees)
                {
                    _employees = value;
                    RaisePropertyChanged(nameof(Employee));
                }
            }
        }

        public override  void Start()
        {
            base.Start();
            Employee = _employeesProvider.GetEmployees();
        }
    }
}
