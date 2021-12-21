using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfFinalProject.Infrostructure;

namespace WpfFinalProject.Model
{
    class ThemeAndLanguage : BaseNotifyPropertyChanged
    {
        #region Filds

        private string _languageSource;
        private string _themeSource;

        #endregion

        #region Propertys

        public string LanguageSource
        {
            get => _languageSource;
            set
            {
                if (value != _languageSource)
                {
                    _languageSource = value;
                    OnPropertyChanged();
                }
            }
        }
        public string ThemeSource
        {
            get => _themeSource;
            set
            {
                if (value != _themeSource)
                {
                    _themeSource = value;
                    OnPropertyChanged();
                }
            }
        }


        #endregion

    }
}