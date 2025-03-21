using System.ComponentModel.DataAnnotations;

namespace CheckListBuild_BE.DTOs
{
    public class AuthenticateRequestModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        //internal void DecryptData()
        //{
        //    this.Password = EncryptHandshakeFEUtil.Decrypt(this.Password);
        //}
    }
}
