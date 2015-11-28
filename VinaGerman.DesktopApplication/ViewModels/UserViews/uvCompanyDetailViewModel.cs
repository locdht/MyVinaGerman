using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinaGerman.Entity;
using VinaGerman.Entity.DatabaseEntity;

namespace VinaGerman.DesktopApplication.ViewModels.UserViews
{
    public class uvCompanyDetailViewModel : DialogViewModel
    {
        public CompanyEntity OriginalCompany { get; set; }
        public CompanyEntity ChangedCompany { get; set; }

        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand SaveCommand { get; set; }        
        public uvCompanyDetailViewModel()
        {
            DeleteCommand = new RelayCommand(Delete);
            SaveCommand = new RelayCommand(Save);
        }

        public void Save()
        {
           
        }
        public void Delete()
        {            
        }
    }
}
