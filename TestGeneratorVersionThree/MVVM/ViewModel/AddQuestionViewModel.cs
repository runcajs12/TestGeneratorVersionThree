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

namespace TestGeneratorVersionThree.MVVM.ViewModel
{
    public class AddQuestionViewModel : ViewModelBase
    {

        public ICommand SaveCommand { get; }
        public event EventHandler QuestionAdded;


        public AddQuestionViewModel()
        {          
            LoadCategories();
            SaveCommand = new Commands.RelayComand((param)=>SaveQuestion());
          
        }

        public AddQuestionViewModel(int _id)
        {
            SaveCommand = new Commands.RelayComand((param) => SaveQuestion());
            Id = _id;
            using (var context = new Data.AppDbContext())
            {
                EditQuestionModel = context.Questions.Where(q => q.Id == Id).FirstOrDefault();

                QuestionProp = EditQuestionModel.QuestionText;
                AnswerAProp = EditQuestionModel.AnswerA;
                AnswerBProp = EditQuestionModel.AnswerB;
                AnswerCProp = EditQuestionModel.AnswerC;
                AnswerDProp = EditQuestionModel.AnswerD;
            }

        }

        private void LoadCategories()
        {
            using (var context = new Data.AppDbContext())
            {
                var categories = context.Categories.ToList();
                Categories = new ObservableCollection<CategoryModel>(categories);
            }

        }

        private void SaveQuestion()
        {
           
                int newId; CategoryModel category = default;
                using (var context = new Data.AppDbContext())
                {
                    newId = context.Questions.Max(q => q.Id) + 1;

                    if (SelectedCategory != null)
                    {
                      category = context.Categories.FirstOrDefault(c => c.Id == SelectedCategory.Id);

                    }
                  
                    var question = new QuestionModel
                    {
                        Id = newId,
                        QuestionText = QuestionProp,
                        AnswerA = AnswerAProp,
                        AnswerB = AnswerBProp,
                        AnswerC = AnswerCProp,
                        AnswerD = AnswerDProp,
                        CorrectAnswer = _correctAnswer,
                        Category = category
                    };
                    //var category = SelectedCategory;
                    //category.Questions.Add(question);
                    context.Questions.Add(question);
                    context.SaveChanges();
                }
                MessageBox.Show("Pytanie zostało dodane.");
                QuestionAdded?.Invoke(this, EventArgs.Empty);
          

        }
        #region Properties
        private int? _id;
        public int? Id
        {
            get { return _id; }
            set { _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private QuestionModel _editQuestionModel;
        public QuestionModel EditQuestionModel
        {
            get { return _editQuestionModel; }
            set { _editQuestionModel = value;
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
        #endregion
    }
}

