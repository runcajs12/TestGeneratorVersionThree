using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestGeneratorVersionThree.MVVM.Model
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [DisplayName("Kategoria")]
        public string CategoryName { get; set; }
        public List<QuestionModel> Questions { get; set; }
    }
}
