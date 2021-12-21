using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfFinalProject.Infrostructure;

namespace WpfFinalProject.Model
{
    public class Car : BaseNotifyPropertyChanged
    {
        #region Filds

        private string _brand;
        private string _nameModel;
        private string _volume;
        private string _power;
        private string _releseDate;
        private string _imageUrl;

        #endregion



        #region Propertys
        public string Brand
        {
            get => _brand;
            set
            {
                if (value != _brand)
                {
                    _brand = value;
                    OnPropertyChanged();
                }
            }
        }
        public string NameModel
        {
            get => _nameModel;
            set
            {
                if (value != _nameModel)
                {
                    _nameModel = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Volume
        {
            get => _volume;
            set
            {
                if (value != _volume)
                {
                    _volume = value;
                    OnPropertyChanged();
                }
            }
        }
        public string ReleseDate
        {
            get => _releseDate;
            set
            {
                if (value != _releseDate)
                {
                    _releseDate = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Power
        {
            get => _power;
            set
            {
                if (value != _power)
                {
                    _power = value;
                    OnPropertyChanged();
                }
            }
        }
        public string ImageUrl
        {
            get => _imageUrl;
            set
            {
                if (value != _imageUrl)
                {
                    _imageUrl = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion


        public override string ToString()
        {
            return $"{Brand} {NameModel}";
        }
    }
}
