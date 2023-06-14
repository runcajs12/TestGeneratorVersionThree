using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TestGeneratorVersionThree.MVVM.Model;

namespace TestGeneratorVersionThree.MVVM.ViewModel
{
    class AddCategoryViewModel : ViewModelBase
    {

        public ICommand SaveCommand { get; }

        public AddCategoryViewModel()
        {
            SaveCommand = new Commands.RelayComand((param) => SaveQuestion(param));

        }

        private void SaveQuestion(object parameter)
        {
           
                using (var context = new Data.AppDbContext())
                {
                    var category = new CategoryModel
                    {
                       CategoryName = categoryTB
                    };

                    context.Categories.Add(category);
                    context.SaveChanges();
                }
                MessageBox.Show("Kategoria została dodana.");
           
        }

        #region Properties
        private string _category;
        public string categoryTB
        {
            get
            {
                return _category;
            }
            set
            {
                _category = value;
                OnPropertyChanged(nameof(categoryTB));
            }
        }
        #endregion
    }
}
