using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Week14Day5.Models
{
    public class MenuViewModel
    {
        [DisplayName("MenuID")]
        public int Id { get; set; }

        [Required]
        [DisplayName("Nome Menu")]
        public string Nome { get; set; }

        public List<PiattoViewModel> Piatti { get; set; } = new List<PiattoViewModel>();
    }
}
