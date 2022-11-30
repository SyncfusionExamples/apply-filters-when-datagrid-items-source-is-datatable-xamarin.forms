using Syncfusion.SfDataGrid.XForms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DataGridXamarin
{
    public class PageBehavior : Behavior<ContentPage>
    {
        #region Fields

        private ViewModel viewModel = null;
        private SearchBar searchBar = null;

        #endregion

        #region Overrides

        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            viewModel = bindable.FindByName<ViewModel>("viewModel");
            searchBar = bindable.FindByName<SearchBar>("filterText");
            if (searchBar != null)
            {
                searchBar.TextChanged += OnSearchBarTextChanged;
            }
        }

        private void OnSearchBarTextChanged(object sender, TextChangedEventArgs e)
        {
            if (viewModel != null && viewModel.PersonInfo != null)
            {
                if (!string.IsNullOrEmpty(e.NewTextValue))
                    viewModel.PersonInfo.RowFilter = "Country = '" + e.NewTextValue + "'";
                else
                    viewModel.PersonInfo.RowFilter = "";
            }
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            searchBar.TextChanged -= OnSearchBarTextChanged;
            searchBar = null;
            viewModel = null;
        }

    }
    #endregion

}
