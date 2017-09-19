using System;
using ForceTouchNavigationSample.Models;
using MvvmCross.Core.ViewModels;

namespace ForceTouchNavigationSample.ViewModels
{
    public class ChildViewModel : MvxViewModel<Employee>
    {
        private Employee employee;
       
        public ChildViewModel()
        {
        }

        public Employee Emplyee 
        {
            get => employee;
            set
            {
                if (employee != value)
                {
                    employee = value;
                    RaisePropertyChanged(nameof(Emplyee));
                }
            }
        }

        public override void Prepare(Employee parameter)
        {
            Emplyee = parameter;
        }
    }
}
