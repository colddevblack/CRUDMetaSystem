using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CadastroWebMETAEnterprise.Models
{
    public class ProdutoModel
    {


        [Key]
        public int id { get; set; }
        public string nomeProduto { get; set; }

        public double preco { get; set; }


        [Display(Name = "Data de criação do Produto")]
        public DateTime dataCriacaoProduto { get; set; }


        ////referencias outra model Cliente
        //public int orcaid { get; set; }
        //public virtual OrcamentoModel orcamentomodel { get; set; }





        public List<OrcamentoModel> orcamentosprodutoslist { get; set; }

    }





}