using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.RegisterDto
{
    public class CreateNewUserDto
    {
        [Required(ErrorMessage="Ad alanı gereklidir.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad alanı gereklidir.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Kullanıcı Adı alanı gereklidir.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Mail alanı gereklidir.")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Şifre alanı gereklidir.")]
        public string City { get; set; }
        public string WorkDepartment { get; set; }

        public int WorkLocationId { get; set; }
        public string ImageUrl { get; set; }
        public string Password { get; set; }
        [Required(ErrorMessage = "Şifre tekrar alanı gereklidir.")]
        [Compare("Password",ErrorMessage ="Şifreler aynı olmalıdır")]/*şifre karşılaştırma*/
        public string ConfirmPassword { get; set; }
    }
}
