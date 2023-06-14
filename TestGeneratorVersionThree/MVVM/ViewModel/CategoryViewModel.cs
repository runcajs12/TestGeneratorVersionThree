using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TestGeneratorVersionThree.Core;
using TestGeneratorVersionThree.MVVM.Model;
using TestGeneratorVersionThree.MVVM.View;
using TestGeneratorVersionThree.Services;


namespace TestGeneratorVersionThree.MVVM.ViewModel;

public class CategoryViewModel : Core.ViewModel
{
    public ICommand AddCategoryCommand { get; set; }

    public CategoryViewModel()
    {
        AddCategoryCommand = new RelayCommand(OpenAddCategoryWindow); // Inicjalizacja polecenia OpenAddQuestionWindow
        Categories = new ObservableCollection<CategoryModel>();
        LoadCategories();
    }

    private void OpenAddCategoryWindow(object parameter)
    {
        AddCategoryView addCategoryViewWindow = new AddCategoryView();
        addCategoryViewWindow.ShowDialog();

    }

    private void LoadCategories()
    {
        using (var context = new Data.AppDbContext())
        {
            var categories = context.Categories.ToList();

            Categories = new ObservableCollection<CategoryModel>(categories);
        }

    }

    private ObservableCollection<CategoryModel> _categories;
    public ObservableCollection<CategoryModel> Categories
    {
        get { return _categories; }
        set
        {
            _categories = value;
            OnPropertyChanged(nameof(Categories));
        }
    }
}