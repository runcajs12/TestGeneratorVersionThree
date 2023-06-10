using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TestGeneratorVersionThree.MVVM.Model
{
    public class QuestionModel 
    {
        [DisplayName("Numer pytania")]
        public int Id { get; set; }
        [DisplayName("Treść")]
        public string QuestionText { get; set; }
        [DisplayName("A")]
        public string AnswerA { get; set; }
        [DisplayName("B")]
        public string AnswerB { get; set; }
        [DisplayName("C")]
        public string AnswerC { get; set; }
        [DisplayName("D")]
        public string AnswerD { get; set; }
        [DisplayName("Poprawna")]
        public string CorrectAnswer { get; set; }
        [DisplayName("Kategoria")]
        public CategoryModel Category { get; set; }
    }
}
