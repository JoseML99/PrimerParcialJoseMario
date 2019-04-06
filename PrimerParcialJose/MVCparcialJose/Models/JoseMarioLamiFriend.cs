using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCparcialJose.Models
{
    public class JoseMarioLamiFriend
    {
        public enum FriendType
        {
            Conocido,            //0
            Compañero_Estudio,   //1
            Colega_de_Trabajo,   //2
            Amigo,               //3
            Amigo_de_Infancia,   //4
            Pariente             
        }

        [Key]
        public int FriendId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Nickname { get; set; }
        public DateTime Birthdate { get; set; }

        [Required]
        public FriendType Type { get; set; }
    }
}