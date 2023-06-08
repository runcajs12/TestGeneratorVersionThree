using System.Windows.Input;
using TestGeneratorVersionThree.Core;

namespace TestGeneratorVersionThree.MVVM.ViewModel;

public class QuestionViewModel : Core.ViewModel
{
    public ICommand OpenDialogCommand { get; private set; }

	public QuestionViewModel()
	{
        OpenDialogCommand = new RelayCommand(OpenDialog);

    }
    private void OpenDialog()
    {
        // Logika otwarcia nowego okna dialogowego
        var dialogViewModel = new DialogViewModel(); // Tworzenie ViewModelu dla okna dialogowego
        var dialogWindow = new DialogWindow(); // Tworzenie okna dialogowego
        dialogWindow.DataContext = dialogViewModel; // Przypisanie ViewModelu do okna dialogowego
        dialogWindow.ShowDialog(); // Otwarcie okna dialogowego
    }
}