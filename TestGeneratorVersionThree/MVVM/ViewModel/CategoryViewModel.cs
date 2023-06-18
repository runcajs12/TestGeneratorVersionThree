using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TestGeneratorVersionThree.Commands;
using TestGeneratorVersionThree.Core;
using TestGeneratorVersionThree.MVVM.Model;
using TestGeneratorVersionThree.MVVM.View;
using TestGeneratorVersionThree.Services;


namespace TestGeneratorVersionThree.MVVM.ViewModel;

public class CategoryViewModel : Core.ViewModel
{
    public ICommand AddCategoryCommand { get; set; }
    public ICommand DeleteCategoryCommand { get; set; }

    public CategoryViewModel()
    {
        AddCategoryCommand = new RelayComand(OpenAddCategoryWindow); // Inicjalizacja polecenia OpenAddQuestionWindow
        DeleteCategoryCommand = new RelayCommand(DeleteCategory);
        Categories = new ObservableCollection<CategoryModel>();
        LoadCategories();
    }

    private void OpenAddCategoryWindow(object parameter)
    {
        AddCategoryView addCategoryViewWindow = new AddCategoryView();
        addCategoryViewWindow.ShowDialog();

    }

    private void DeleteCategory(object parameter)
    {
        MessageBoxResult result = MessageBox.Show("Czy na pewno chcesz usunąć kategorię?",
            "Potwierdzenie usunięcia", MessageBoxButton.YesNo, MessageBoxImage.Question);
        if (SelectedCategory != null && result == MessageBoxResult.Yes)
        {
            using (var context = new Data.AppDbContext())
            {
                context.Categories.Remove(SelectedCategory);
                context.SaveChanges();
            }
        }
        LoadCategories();
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

    private CategoryModel selectedCategory;
    public CategoryModel SelectedCategory
    {
        get { return selectedCategory; }
        set
        {
            selectedCategory = value;
            OnPropertyChanged(nameof(SelectedCategory));
        }
    }
}