using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfFinalProject.Infrostructure;
using WpfFinalProject.Model;
using WpfFinalProject.View;

namespace WpfFinalProject.ViewModel
{
   public class CarsViewModel : BaseNotifyPropertyChanged
    {

        public ObservableCollection<Car> Cars { get; set; }
        readonly string str = "1.json";

        public CarsViewModel()
        {
            Cars = new ObservableCollection<Car>();
            StartLoad();
        } 

        private Car selectedCar;
        public Car SelectedCar
        {
            get => selectedCar;
            set
            {
                if (value != selectedCar)
                {
                    selectedCar = value;
                    OnPropertyChanged();
                }
            }
        }
        private RelayCommand openWindowCommand;
        public RelayCommand OpenWindowCommand
        {
            get
            {
                return openWindowCommand ?? (openWindowCommand = new RelayCommand((obj) =>
                {
                     var win = new AddCarWindow(Cars); 
                      win.ShowDialog(); 
                }));
            }
        }
        private RelayCommand dellSelectedCarCommand;
        public RelayCommand DellSelectesCarCommand
        {
            get
            {
                return dellSelectedCarCommand ?? (dellSelectedCarCommand = new RelayCommand((obj) =>
                {
                    if (selectedCar != null)
                    {
                        Cars.Remove(selectedCar);
                    }
                }));
            }
        } 
        private RelayCommand saveAsCommand;
        public RelayCommand SaveAsCommand
        {
            get
            {
                return saveAsCommand ?? (saveAsCommand = new RelayCommand((obj) =>
                {
                    SaveFileDialog saveFile = new SaveFileDialog();
                    saveFile.Filter = "Json files|*.json";
                    if (saveFile.ShowDialog() == true)
                    {
                        string json = JsonConvert.SerializeObject(Cars, Formatting.Indented);
                        File.WriteAllText(saveFile.FileName, json);
                    } 
                }));
            }
        }
        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ?? (saveCommand = new RelayCommand((obj) =>
                { 
                    string json = JsonConvert.SerializeObject(Cars, Formatting.Indented);
                    File.WriteAllText(str, json);

                }));
            }
        } 

        private RelayCommand clearCommand;
        public RelayCommand ClearCommand
        {
            get
            {
                return clearCommand ?? (clearCommand = new RelayCommand((obj) =>
                { 
                     Cars.Clear(); 
                }));
            }
        }  

        private RelayCommand loadFileCommand;
        public RelayCommand LoadFileCommand
        {
            get
            {
                return loadFileCommand ?? (loadFileCommand = new RelayCommand((obj) =>
                {
                    OpenFileDialog openFile = new OpenFileDialog();
                    openFile.Filter = "Json files|*.json";
                    if (openFile.ShowDialog() == true)
                    {
                        string json = File.ReadAllText(openFile.FileName);
                        ObservableCollection<Car> tmp = JsonConvert.DeserializeObject<ObservableCollection<Car>>(json);
                        foreach (var item in tmp)
                        {
                            Cars.Add(new Car
                            {
                                Brand = item.Brand,
                                NameModel = item.NameModel,
                                Volume = item.Volume,
                                Power = item.Power,
                                ReleseDate = item.ReleseDate,
                                ImageUrl = item.ImageUrl
                            });
                        }
                    }
                }));
            }
        } 

        private RelayCommand startLoadFileCommand;
        public RelayCommand StartLoadFileCommand
        {
            get
            {
                return startLoadFileCommand ?? (startLoadFileCommand = new RelayCommand((obj) =>
                {
                    StartLoad();
                }));
            }
        }
         
        public void StartLoad()
        {
            if (File.Exists(str))
            {
                string json = File.ReadAllText(str);
                ObservableCollection<Car> tmp = JsonConvert.DeserializeObject<ObservableCollection<Car>>(json);
                foreach (var item in tmp)
                {
                    Cars.Add(new Car
                    {
                        Brand = item.Brand,
                        NameModel = item.NameModel,
                        Volume = item.Volume,
                        Power = item.Power,
                        ReleseDate = item.ReleseDate,
                        ImageUrl = item.ImageUrl
                    });
                }
            }
        }





        //private static ObservableCollection<Car> GenerateCarRepository()
        //{
        //    var tmp = new ObservableCollection<Car>()
        //    {
        //        new Car(){Brand="Porsche", NameModel="911" , Volume="3,0",Power="379", ReleseDate="2022", 
        //            ImageUrl=@"https://images.dealer.com/ddc/vehicles/2022/Porsche/911/Coupe/color/Aventurine%20Green%20Metallic-U4-42,58,44-640-en_US.jpg"},
        //        new Car(){Brand="Jaguar",  NameModel="F-TYPE P450", Volume="5,0",Power="444", ReleseDate="2022", 
        //            ImageUrl=@"https://images.dealer.com/ddc/vehicles/2022/Jaguar/F-TYPE/Coupe/color/Velocity%20Blue%20Gloss-005DV-13,76,171-640-en_US.jpg?_ga=2.213991767.1509510408.1639858108-672154892.1639858108"},
        //        new Car(){Brand="Mercedes",  NameModel ="AMG GT", Volume="4,0",Power="510", ReleseDate="2015", 
        //            ImageUrl=@"http://www.3dnews.ru/assets/external/illustrations/2014/10/06/903064/merc2.jpg"},
        //        new Car(){Brand="Chevrolet", NameModel="Corvette C8", Volume="6,2",Power="495", ReleseDate="2020", 
        //            ImageUrl=@"https://5sector.com.ua/wp-content/uploads/2020/08/Chevrolet-Corvette-C8-Stingray-2020-Model-124-1.jpg"},
        //        new Car(){Brand="Audi", NameModel="TT RS", Volume="2.48",Power="340", ReleseDate="2021", 
        //            ImageUrl=@"https://images.dealer.com/ddc/vehicles/2021/Audi/TT%20RS/Coupe/color/Daytona%20Gray%20Pearl%20Effect-6Y6Y-70,72,69-640-en_US.jpg"}
        //    }; return tmp;
        //}

        //public void Load()
        //{
        //    OpenFileDialog openFile = new OpenFileDialog();
        //    if (openFile.ShowDialog() == true)
        //    {
        //        string json = File.ReadAllText(openFile.FileName);
        //        ObservableCollection<Car> tmp = JsonConvert.DeserializeObject<ObservableCollection<Car>>(json);
        //        foreach (var item in tmp)
        //        {
        //            Cars.Add(new Car
        //            {
        //                Brand = item.Brand,
        //                NameModel = item.NameModel,
        //                Volume = item.Volume,
        //                Power = item.Power,
        //                ReleseDate = item.ReleseDate,
        //                ImageUrl = item.ImageUrl
        //            });
        //        }
        //    }
        //}
    }
}
