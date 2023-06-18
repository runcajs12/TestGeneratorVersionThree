using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using TestGeneratorVersionThree.Commands;
using TestGeneratorVersionThree.Core;
using TestGeneratorVersionThree.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestGeneratorVersionThree.MVVM.ViewModel;

public class GenerateViewModel : Core.ViewModel
{
    public ICommand GenerateCommand { get; set; }


    public GenerateViewModel()
    {
        GenerateCommand = new RelayComand(GenerateTest);

    }

    private void GenerateTest(object parameter)
    {
        var dialog = new CustomDialog("Podaj nazwę testu:");
        var result = dialog.ShowDialog();

        if (result == true)
        {
            string nazwaTestu = dialog.NazwaTestu; // Pobranie wprowadzonej nazwy testu
                                                   // Przykładowa implementacja wyszukiwania
                                                   // Tworzenie dokumentu PDF
            Document document = new Document();
            int x = int.Parse(QuestionNumberProp);
            string correctAnswchu = CorrectAnswerProp;

            // Określenie ścieżki do pliku PDF
            string filePath = $"{nazwaTestu}.pdf";

            // Tworzenie strumienia zapisu dla pliku PDF
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));

            // Otwarcie dokumentu do edycji
            document.Open();


            // Tworzenie zawartości pliku PDF na podstawie pobranych danych
            // ...

            // Dodawanie zawartości do dokumentu
            // ...

            // Zamknięcie dokumentu
            document.Close();
            // Zaktualizuj listę pytań na podstawie wyników wyszukiwania
            // (przykładowo przypisz do nowej właściwości QuestionsFiltered)                                       // Wykonaj odpowiednie działania na podstawie nazwy testu
        }
    }

    private string _questionNumber;
    public string QuestionNumberProp
    {
        get
        {
            return _questionNumber;
        }
        set
        {
            _questionNumber = value;
            OnPropertyChanged(nameof(QuestionNumberProp));
        }
    }
    private string _correctAnswer;
    public string CorrectAnswerProp
    {
        get
        {
            return _correctAnswer;
        }
        set
        {
            _correctAnswer = value.Substring(value.Length - 1);
            OnPropertyChanged(nameof(CorrectAnswerProp));
        }
    }
}