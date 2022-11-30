using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridXamarin
{ 
    public class Person : INotifyPropertyChanged
    {
        private string firstname;
        private string lastname;
        private string country;
     
        public string FirstName
        {
            get { return firstname; }
            set
            {
                this.firstname = value;
                RaisePropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get { return lastname; }
            set
            {
                this.lastname = value;
                RaisePropertyChanged("LastName");
            }
        }

        public string Country
        {
            get { return this.country; }
            set
            {
                this.country = value;
                RaisePropertyChanged("Country");
            }
        }


        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
