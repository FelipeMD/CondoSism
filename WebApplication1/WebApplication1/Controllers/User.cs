using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Controllers
{
    [Table("users")]
    public class User
    {   
        [Key]
        [Column("id_user")]
        public long idUser { get; set; }
        
        [Column("user_name")]
        public string UserName { get; set; }
        
        [Column("password")]
        public string fullName { get; set; }
        
        [Column("phone")]
        public string Password { get; set; }
        
        [Column("cpf")]
        public string Phone { get; set; }
        
        [Column("email")]
        public string Cpf { get; set; }
        
        [Column("id_user")]
        public string email { get; set; }
        
        [Column("birth_date")]
        public DateTime BirthDate { get; set; }
        
        [Column("refresh_token")]
        public string RefreshToken { get; set; }
        
        [Column("refresh_token_expiry_time")]
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}