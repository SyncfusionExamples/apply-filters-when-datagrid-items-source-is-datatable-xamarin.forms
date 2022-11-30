using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridXamarin
{
    public class ViewModel : INotifyPropertyChanged
    {
        private DataTable Person;
        private ObservableCollection<Person> personCollection;
        private DataView personInfo;
        public DataView PersonInfo
        {
            get { return personInfo; }
            set
            {
                this.personInfo = value;
                RaisePropertyChanged("PersonInfo");
            }
        }
        public ViewModel()
        {
            personCollection = new ObservableCollection<Person>();
            Person = new DataTable();
            personInfo = new DataView();
            GenerateData();
            GenerateTable();
        }

        private void GenerateTable()
        {
            DataColumn col1 = new DataColumn();
            col1.DataType = typeof(string);
            col1.ColumnName = "FirstName";
            Person.Columns.Add(col1);

            DataColumn col2 = new DataColumn();
            col2.DataType = typeof(string);
            col2.ColumnName = "LastName";
            Person.Columns.Add(col2);

            DataColumn col3 = new DataColumn();
            col3.DataType = typeof(string);
            col3.ColumnName = "Country";
            Person.Columns.Add(col3);

            foreach(var item in personCollection)
            {
                System.Data.DataRow dt = Person.NewRow();
                dt[0] = item.FirstName;
                dt[1] = item.LastName;
                dt[2] = item.Country;
                Person.Rows.Add(dt);
            }
            Person.TableName = "Person";
            PersonInfo.Table = Person;
        }

        private void GenerateData()
        {
            personCollection.Add(new Person() { FirstName = "Steve", LastName = "Harris", Country = "Greece" });
            personCollection.Add(new Person() { FirstName = "John", LastName = "Dickinson", Country = "Greece" });
            personCollection.Add(new Person() { FirstName = "Dave", LastName = "Murray", Country = "Greece" });
            personCollection.Add(new Person() { FirstName = "Maria", LastName = "Anders", Country = "Berlin" });
            personCollection.Add(new Person() { FirstName = "Ana", LastName = "Trujillo", Country = "Sweden" });
            personCollection.Add(new Person() { FirstName = "Ant", LastName = "Fuller", Country = "Sweden" });
            personCollection.Add(new Person() { FirstName = "Thomas", LastName = "Hardy", Country = "Germany" });
            personCollection.Add(new Person() { FirstName = "Tim", LastName = "Adams", Country = "Germany" });
            personCollection.Add(new Person() { FirstName = "Hanna", LastName = "Moos", Country = "France" });
            personCollection.Add(new Person() { FirstName = "Lenny", LastName = "Lin", Country = "Berlin" });
            personCollection.Add(new Person() { FirstName = "Martin", LastName = "King", Country = "France" });
            personCollection.Add(new Person() { FirstName = "Anne", LastName = "Wilson", Country = "Canada" });
            personCollection.Add(new Person() { FirstName = "Laura", LastName = "King", Country = "UK" });
            personCollection.Add(new Person() { FirstName = "Gina", LastName = "Dickinson", Country = "Berlin" });
            personCollection.Add(new Person() { FirstName = "Dave", LastName = "Murray", Country = "Sweden" });
            personCollection.Add(new Person() { FirstName = "Gina", LastName = "Irene", Country = "UK" });
            personCollection.Add(new Person() { FirstName = "Ana", LastName = "Trujillo", Country = "Sweden" });
            personCollection.Add(new Person() { FirstName = "Irene", LastName = "Fuller", Country = "Sweden" });


        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this,new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
