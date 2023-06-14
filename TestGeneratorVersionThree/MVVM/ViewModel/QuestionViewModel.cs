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
    //public ICommand SearchCommand { get; set; }
    public ICommand EditQuestionCommand { get; set; }
    //public ICommand DeleteQuestionCommand { get; set; }
    //public ICommand Questions { get; set; }
    //public ICommand QuestionText { get; set; }
    //public ICommand Answers { get; set; }

    public QuestionViewModel()
    {
        EditQuestionCommand = new RelayCommand(OpenEditQuestionWindow);
        AddQuestionCommand = new RelayCommand(OpenAddQuestionWindow); // Inicjalizacja polecenia OpenAddQuestionWindow
        Questions = new ObservableCollection<QuestionModel>(); // Inicjalizacja właściwości reprezentującej listę pytań pobraną z bazy
        LoadQuestion();
    }
    private void OpenAddQuestionWindow(object parameter)
    {
        AddQuestionView addQuestionViewWindow= new AddQuestionView();
            addQuestionViewWindow.ShowDialog();

    }

    private void OpenEditQuestionWindow(object parameter)
    {

        if (selectedQuestion != null)
        {
            AddQuestionView addQuestionViewWindow = new AddQuestionView(selectedQuestion.Id);
            addQuestionViewWindow.ShowDialog();
        }
    }

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
    #endregion

}