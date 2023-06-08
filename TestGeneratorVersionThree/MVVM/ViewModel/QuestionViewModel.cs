using System.Windows.Controls;
using System.Windows.Input;
using TestGeneratorVersionThree.Core;
using TestGeneratorVersionThree.MVVM.View;
using TestGeneratorVersionThree.Services;

namespace TestGeneratorVersionThree.MVVM.ViewModel;

public class QuestionViewModel : Core.ViewModel
{

    public ICommand AddQuestionCommand { get; set; }
    public ICommand SearchCommand { get; set; }
    public ICommand EditQuestionCommand { get; set; }
    public ICommand DeleteQuestionCommand { get; set; }
    public ICommand Questions { get; set; }
    public ICommand QuestionText { get; set; }
    public ICommand Answers { get; set; }

    //public RelayCommand AddQuestionCommand { get; }

    public QuestionViewModel()
    {
        AddQuestionCommand = new RelayCommand(OpenAddQuestionWindow, xD=>true);
    }
    private void OpenAddQuestionWindow(object parameter)
    {
        var newWindow = new AddQuestionView();
        newWindow.Show();
    }



}