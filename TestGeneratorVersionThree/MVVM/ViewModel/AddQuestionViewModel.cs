using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TestGeneratorVersionThree.Commands;
using TestGeneratorVersionThree.MVVM.Model;

namespace TestGeneratorVersionThree.MVVM.ViewModel
{
    public class AddQuestionViewModel : ViewModelBase
    {
        public ICommand SaveCommand { get; }

        public AddQuestionViewModel()
        {
            SaveCommand = new Commands.RelayComand((param)=>SaveQuestion(param));
        }

        private void SaveQuestion(object parameter)
        {
           
            using (var context = new Data.AppDbContext())
            {
                var question = new QuestionModel
                {
                    QuestionText = QuestionProp,
                    AnswerA = AnswerAProp,
                    AnswerB = AnswerBProp,
                    AnswerC = AnswerCProp,
                    AnswerD = AnswerDProp,
                    CorrectAnswer = _correctAnswer,
                    Category=SelectedCategory     
                };
                
                context.Questions.Add(question);
                context.SaveChanges();
            }
            MessageBox.Show("Pytanie zostało dodane.");

        }
        #region Properties
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
        #endregion
    }
}

