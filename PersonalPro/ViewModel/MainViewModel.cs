using PersonalPro.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PersonalPro.ViewModel
{
    public class MainViewModel: ViewModelBase
    {

        private Boolean _isBusy;
        public Boolean IsBusy
        {
            get { return _isBusy; }
            set
            {
                SetProperty(ref _isBusy, value);

            }

        }

        public MainViewModel()
        {
            this.Command = new DelegateCommand(this.ExecuteCommand, this.CanRunCommand);
        }

        DataFactory data = new DataFactory();
        private async void ExecuteCommand(object parameter)
        {
            IsBusy = true;

            await Task.Run(() =>
            {
               
                 Thread.Sleep(3000);

                _projects = data.GetProjects();

            });


            OnPropertyChanged("Projects");



            IsBusy = false;
        }


        private List<Project> _projects;
        public List<Project> Projects
        {
            get { return _projects; }
            set
            {
                SetProperty(ref _projects, value);

            }

        }

        private Project _selectedProject;
        public Project SelectedProject
        {
            get { return _selectedProject; }
            set
            {
                SetProperty(ref _selectedProject, value);

            }

        }

        public bool CanRunCommand(object parameter)
        {
            return true;
        }

        private DelegateCommand command;
        public DelegateCommand Command
        {
            get
            {
                return this.command;
            }
            set
            {
                this.command = value;
            }
        }
    }



    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }
            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }

    public class DelegateCommand : ICommand
    {
        private Action<object> execute;
        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
