using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfFinalProject.Infrostructure;
using WpfFinalProject.Model;

namespace WpfFinalProject.ViewModel
{
    class AddWindowViewModel : BaseNotifyPropertyChanged
    {
        private Car newCar;
        public Car NewCar
        {
            get => newCar;
            set
            {
                newCar = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Car> Cars { get; set; }
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ?? (addCommand = new RelayCommand((obj) =>
                {
                    Cars.Insert(0, NewCar);
                }));
            }
        }
        private RelayCommand loadFile;
        public RelayCommand LoadFile
        {
            get
            {
                return loadFile ?? (loadFile = new RelayCommand((obj) =>
                {
                    OpenFileDialog fn = new OpenFileDialog();
                    fn.Filter = "All files (*.*)|*.*|Text files (*.txt)|*.txt";
                    if (fn.ShowDialog() == true)
                    {
                        NewCar.ImageUrl = fn.FileName;
                    }
                }));
            }
        }
        public AddWindowViewModel(ObservableCollection<Car> cnt)
        {
            NewCar = new Car();
            Cars = cnt;
        }
    }
}
