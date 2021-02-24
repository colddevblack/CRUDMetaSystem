using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CadastroWebMETAEnterprise.Models
{
    public class OrcamentoModel
    {
        [Key]
        public int id { get; set; }

        public double valor { get; set; }


        [Display(Name = "Data de criação do Orçamento")]
        public DateTime dataCriacaoOrcamento { get; set; }

        //referencias outra model FKs
        //FK1
        public int clienteid { get; set; }
        public virtual ClienteModel clientemodel { get; set; }

        //referencia ProdutoModel
        public int produtoid { get; set; }
        public virtual ProdutoModel produtomodel { get; set; }

        // Listas de relacionamento
        //public List<ClienteModel> clienteslistorca { get; set; }

        //public List<ProdutoModel> produtoslistorca { get; set; }
    }
}