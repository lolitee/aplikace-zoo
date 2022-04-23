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

        private string _latin;

        [Required(ErrorMessage = "Cannot be empty!")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Must be at least 1 character long.")]
        [RegularExpression(@"(''|[^'])*", ErrorMessage = "Characters are not allowed.")]
        public string Latin
        {
            get { return _latin; }
            set
            {
                ValidateProperty(value, "Latin");
                OnPropertyChanged(ref _latin, value);
            }
        }
    }
}