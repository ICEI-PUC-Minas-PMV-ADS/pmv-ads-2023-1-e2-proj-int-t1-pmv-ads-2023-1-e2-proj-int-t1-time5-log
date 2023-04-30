﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Commpay.Models
{
    [Table("ItemVenda")]
    public class ItemVenda
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Obrigatório o Preenchimento da quantidade!")]
        public int Quantidade { get; set; }        

        [ForeignKey("Venda")]
        public int VendaId { get; set; }       

        public Venda Venda { get; set; }

        [ForeignKey("Produto")]
        public int ProdutoId { get; set; }       

        public Produto Produto { get; set; }
    }
}
