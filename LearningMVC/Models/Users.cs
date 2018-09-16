using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningMVC.Models
{
    [Table("Users")]
    public class Users
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [DisplayFormat(NullDisplayText = "No name entered")]
        public string Username { get; set; }

        [DisplayFormat(NullDisplayText = "No password entered")]
        public string Password { get; set; }
    }
}