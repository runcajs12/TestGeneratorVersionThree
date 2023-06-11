using System;
using System.Windows;
using System.Windows.Input;
using TestGeneratorVersionThree.Core;
using TestGeneratorVersionThree.Services;

namespace TestGeneratorVersionThree.MVVM.ViewModel;

public class MainViewModel : Core.ViewModel
{
    private INavigationService _navigation;
    public INavigationService Navigation {
        get => _navigation;
        set
        {
            _navigation = value;
            OnPropertyChanged();
        }
    }

    public RelayCommand NavigateToQuestionCommand { get; set; }
    public RelayCommand NavigateToGenerateCommand { get; set; }
    public RelayCommand NavigateToCategoryCommand { get; set; }
    public ICommand ExitCommand { get; }

    public MainViewModel()
    {
        ExitCommand = new Commands.RelayComand((param) => CloseApp());
    }

    public MainViewModel(INavigationService navService)
    {
        Navigation = navService;
        NavigateToQuestionCommand = new RelayCommand(o => { Navigation.NavigateTo<QuestionViewModel>(); });
        NavigateToGenerateCommand = new RelayCommand(o => { Navigation.NavigateTo<GenerateViewModel>(); });
        NavigateToCategoryCommand = new RelayCommand(o => { Navigation.NavigateTo<CategoryViewModel>(); });
        ExitCommand = new Commands.RelayComand((param) => CloseApp());

    }
    ICommand MinimaizeComand { get; }


    private void CloseApp()
    {
        Application.Current.Shutdown();
    }
}