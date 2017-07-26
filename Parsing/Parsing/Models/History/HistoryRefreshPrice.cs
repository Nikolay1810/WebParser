using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Parsing.Models.History
{
    [Table("HistoryRefreshPrice")]
    public class HistoryRefreshPrice
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Дата обновления")]
        public DateTime RefreshDate { get; set; }

        [Display(Name = "Цена")]
        public string Price { get; set; }

        [Display(Name = "Id Товара")]
        public int ProductId { get; set; }
    }
}