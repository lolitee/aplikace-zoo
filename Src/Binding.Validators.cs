using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Zoo
{
    public partial class MainWindow
    {
        private string _animal;

        [Required(ErrorMessage = "Cannot be empty!")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Must be at least 1 character long.")]
        [RegularExpression(@"(''|[^'])*", ErrorMessage = "Characters are not allowed.")]
        public string Animal
        {
            get { return _animal; }
            set
            {
                ValidateProperty(value, "Animal");
                OnPropertyChanged(ref _animal, value);
            }
        }
    }
}
