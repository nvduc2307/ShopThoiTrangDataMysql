using System.ComponentModel.DataAnnotations;

namespace ShopThoiTrang.BackEnd.Entities;

public class UserEntity {
    [Key]
    public int Id {get; set;}

    [Required]
    public string Email {get; set;}

    [Required]
    public string  UserName {get; set;}

    [Required]
    public string FullName {get; set;}

    [MinLength(6)]
    public string Password {get; set;}

    [Required]
    public bool IsAdmin {get; set;}

}

public class LogginInfo {
    public string UserName{get; set;}
    public string Password{get; set;}
}
public class ModelUser { 
    public string UserName{get; set;}
    public string Email {get; set;}
    public string Password{get; set;}
}