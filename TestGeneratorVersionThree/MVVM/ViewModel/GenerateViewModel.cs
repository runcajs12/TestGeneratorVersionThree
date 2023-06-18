using TestGeneratorVersionThree.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
//using TestGeneratorVersionThree.Commands;
using TestGeneratorVersionThree.MVVM.Model;
using TestGeneratorVersionThree.Commands;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text;

namespace TestGeneratorVersionThree.MVVM.ViewModel
{
    public class GenerateViewModel : Core.ViewModel
    {

        public ICommand SaveCommand { get; }
        public event EventHandler QuestionAdded;
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

                // Określenie ścieżki do pliku PDF
                string filePath = $"{nazwaTestu}.pdf";

                // Tworzenie strumienia zapisu dla pliku PDF
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));

                // Otwarcie dokumentu do edycji
                document.Open();

                using (var context = new Data.AppDbContext())
                {
                    var allQuestions = context.Questions.ToList();

                    if (x > allQuestions.Count)
                    {
                        MessageBox.Show("Nie ma tylu pytan w bazie");
                        return;
                    }
                    else for(int i =0;i<x;i++)
                    {

                        var randomIndex = new Random().Next(0, allQuestions.Count);

                        // Pobranie losowego pytania
                        var randomQuestion = allQuestions[randomIndex];

                        // Tworzenie zawartości pytania i odpowiedzi w dokumencie PDF
                        Paragraph questionParagraph = new Paragraph(i+1 +". " + randomQuestion.QuestionText);
                        Paragraph answersParagraph = new Paragraph();

                        answersParagraph.Add(new Chunk("A. ", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                        answersParagraph.Add(randomQuestion.AnswerA);
                        answersParagraph.Add(Chunk.NEWLINE);

                        answersParagraph.Add(new Chunk("B. ", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                        answersParagraph.Add(randomQuestion.AnswerB);
                        answersParagraph.Add(Chunk.NEWLINE);

                        answersParagraph.Add(new Chunk("C. ", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                        answersParagraph.Add(randomQuestion.AnswerC);
                        answersParagraph.Add(Chunk.NEWLINE);

                        answersParagraph.Add(new Chunk("D. ", FontFactory.GetFont(FontFactory.HELVETICA, 12)));
                        answersParagraph.Add(randomQuestion.AnswerD);
                        answersParagraph.Add(Chunk.NEWLINE);
                        answersParagraph.Add(Chunk.NEWLINE);
                            // Dodawanie pytania i odpowiedzi do dokumentu
                        document.Add(questionParagraph);
                        document.Add(answersParagraph);
                        allQuestions.RemoveAt(randomIndex);
                    }
                    // Tworzenie zawartości pliku PDF na podstawie pobranych danych
                    // ...

                    // Dodawanie zawartości do dokumentu
                    // ...

                    // Zamknięcie dokumentu
                    document.Close();
                    MessageBox.Show("Wygenerowano test");
                }
                // Zaktualizuj listę pytań na podstawie wyników wyszukiwania
                // (przykładowo przypisz do nowej właściwości QuestionsFiltered)                                       // Wykonaj odpowiednie działania na podstawie nazwy testu
            }
        }



       
        #region Properties
        private int? _id;
        public int? Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private QuestionModel _editQuestionModel;
        public QuestionModel EditQuestionModel
        {
            get { return _editQuestionModel; }
            set
            {
                _editQuestionModel = value;
                OnPropertyChanged(nameof(EditQuestionModel));
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

        private string _question;
        public string QuestionProp
        {
            get
            {
                return _question;
            }
            set
            {
                _question = value;
                OnPropertyChanged(nameof(QuestionProp));
            }
        }
        private string _anaswerA;
        public string AnswerAProp
        {
            get
            {
                return _anaswerA;
            }
            set
            {
                _anaswerA = value;
                OnPropertyChanged(nameof(AnswerAProp));
            }
        }
        private string _anaswerB;
        public string AnswerBProp
        {
            get
            {
                return _anaswerB;
            }
            set
            {
                _anaswerB = value;
                OnPropertyChanged(nameof(AnswerBProp));
            }
        }
        private string _anaswerC;
        public string AnswerCProp
        {
            get
            {
                return _anaswerC;
            }
            set
            {
                _anaswerC = value;
                OnPropertyChanged(nameof(AnswerCProp));
            }
        }
        private string _anaswerD;
        public string AnswerDProp
        {
            get
            {
                return _anaswerD;
            }
            set
            {
                _anaswerD = value;
                OnPropertyChanged(nameof(AnswerDProp));
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
        private CategoryModel _selectedCategory;
        public CategoryModel SelectedCategory
        {
            get
            {
                return _selectedCategory;
            }
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
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
        #endregion
    }
}

