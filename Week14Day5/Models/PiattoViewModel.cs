using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Week14Day5.Models
{
    public class PiattoViewModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [DisplayName("Nome Piatto")]
        public string Nome { get; set; }
        public string Descrizione { get; set; }
        public _Tipologia Tipologia { get; set; }
        public decimal Prezzo { get; set; }


        //FK
        public int MenuId { get; set; }
        public MenuViewModel Menu { get; set; }
    }

    public enum _Tipologia
    {
        Primo,
        Secondo,
        Contorno,
        Dolce
    }
}
