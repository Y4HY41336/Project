using System.ComponentModel.DataAnnotations;

namespace NewProject.ViewModel;

public class AppUserViewModel
{
    [Required]
    public string UserName { get; set; }
    [Required]
    public string FullName { get; set; }
    [Required,DataType(DataType.Password)]
    public string Pasword { get; set; }
    [Required,DataType(DataType.Password),Compare(nameof(Pasword))]
    public string ConfirmPasword { get; set; }
    [Required, DataType(DataType.EmailAddress)]
    public string Email { get; set; }
}
