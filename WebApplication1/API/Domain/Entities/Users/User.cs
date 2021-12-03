using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Domain.Entities.Users
{
    [Table("users")]
    public class User
    {   
        [Key]
        [Column("id_user")]
        public int IdUser { get; set; }
        
        [Column("user_name")]
        public string UserName { get; set; }
        
        [Column("full_name")]
        public string FullName { get; set; }
        
        [Column("password")]
        public string Password { get; set; }
        
        [Column("phone")]
        public string Phone { get; set; }
        
        [Column("cpf")]
        public string Cpf { get; set; }
        
        [Column("email")]
        public string Email { get; set; }
        
        [Column("birth_date")]
        public DateTime BirthDate { get; set; }
        
        [Column("refresh_token")]
        public string RefreshToken { get; set; }
        
        [Column("refresh_token_expiry_time")]
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}