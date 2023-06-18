using System.Collections.Generic;
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

public class QuestionViewModel : Core.ViewModel
{

    public ICommand AddQuestionCommand { get; set; }
    public ICommand SearchCommand { get; set; }
    public ICommand EditQuestionCommand { get; set; }
    public ICommand DeleteQuestionCommand { get; set; }
    //public ICommand Questions { get; set; }
    //public ICommand QuestionText { get; set; }
    //public ICommand Answers { get; set; }

    public QuestionViewModel()
    {
        SearchCommand = new RelayCommand(ExecuteSearch);
        EditQuestionCommand = new RelayCommand(OpenEditQuestionWindow);
        DeleteQuestionCommand = new RelayCommand(DeleteQuestion);
        AddQuestionCommand = new RelayCommand(OpenAddQuestionWindow); // Inicjalizacja polecenia OpenAddQuestionWindow
        Questions = new ObservableCollection<QuestionModel>(); // Inicjalizacja właściwości reprezentującej listę pytań pobraną z bazy
        LoadQuestion();
    }

    private void ExecuteSearch(object parameter)
    {
        // Przykładowa implementacja wyszukiwania
        
        using (var context = new Data.AppDbContext())
        {
            var filteredQuestions = context.Questions.Where(q => q.QuestionText.Contains(SearchText)).ToList();
            Questions = new ObservableCollection<QuestionModel>(filteredQuestions);
        }
        // Zaktualizuj listę pytań na podstawie wyników wyszukiwania
        // (przykładowo przypisz do nowej właściwości QuestionsFiltered)
       
    }

    // Usuwanie pytania
    private void DeleteQuestion(object parameter)
    {
        MessageBoxResult result = MessageBox.Show("Czy na pewno chcesz usunąć pytanie?", 
            "Potwierdzenie usunięcia", MessageBoxButton.YesNo, MessageBoxImage.Question);
        if (SelectedQuestion != null && result == MessageBoxResult.Yes) 
        {
            using (var context = new Data.AppDbContext())
            {
                context.Questions.Remove(SelectedQuestion);
                context.SaveChanges();
            }
        }
        LoadQuestion();
    }

    // Otwieranie okna z dodawaniem pytania
    private void OpenAddQuestionWindow(object parameter)
    {
        AddQuestionView addQuestionViewWindow= new AddQuestionView();
            addQuestionViewWindow.ShowDialog();

    }

    private void OpenEditQuestionWindow(object parameter)
    {
        if (selectedQuestion != null)
        {
            EditQuestionView editQuestionViewWindow = new EditQuestionView(selectedQuestion.Id);
            editQuestionViewWindow.ShowDialog();
        }
    }
    // Ładowanie pytań z bazy
    private void LoadQuestion()
    {
        using (var context = new Data.AppDbContext())
        {
            var questions = context.Questions.ToList();
            Questions = new ObservableCollection<QuestionModel>(questions);
        }

    }
    #region Properties
    private ObservableCollection<QuestionModel> _questions;
    public ObservableCollection<QuestionModel> Questions
    {
        get { return _questions; }
        set
        {
            _questions = value;
            OnPropertyChanged(nameof(Questions));
        }
    }

    private QuestionModel selectedQuestion;
    public QuestionModel SelectedQuestion
    {
        get { return selectedQuestion; }
        set
        {
            selectedQuestion = value;
            OnPropertyChanged(nameof(SelectedQuestion));
        }
    }

    private string _searchText;
    public string SearchText
    {
        get { return _searchText; }
        set
        {
            _searchText = value;
            OnPropertyChanged(nameof(SearchText));
            SearchCommand.Execute(null); // Wywołanie metody wyszukiwania przy każdej zmianie tekstu
        }
    }
    #endregion

}