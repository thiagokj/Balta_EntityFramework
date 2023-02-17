using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Balta_EntityFramework.Models
{
    [Table("Post")]
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Body { get; set; }
        public string Slug { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

        /*
            Seguindo a convenção de nomes, o EF faz a identificação 
            da classe e da propriedade. Sempre crie as chaves das tabelas
            seguindo o padrão NomeDaProriedadeId.
        */

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; } // Propriedade de navegação do EF

        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }
        public User Author { get; set; } // Propriedade de navegação do EF
    }
}