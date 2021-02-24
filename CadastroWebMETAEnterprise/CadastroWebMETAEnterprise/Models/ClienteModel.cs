using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CadastroWebMETAEnterprise.Models
{
    public class ClienteModel
    {
     
        [Key]
        public int id { get; set; }
        public string nomeCliente { get; set; }
        public string telefone { get; set; }
        public string endereco { get; set; }

      

        [Display(Name = "Data de criação do Usuario")]
        public DateTime dataCriacao { get; set; }

        //public int orcaid { get; set; }
        //public virtual OrcamentoModel orcamentomodel { get; set; }


        public List<OrcamentoModel> orcaclientelist { get; set; }

    }
}