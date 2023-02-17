# Csharp Entity Framework

Projeto para estudo e revisão de conceitos utilizando o EF.

## Requisitos

```Csharp
dotnet add package Microsoft.EntityFrameworkCore --version 5.0.9
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 5.0.9
```

## Entity Framework

É um conjunto de bibliotecas e ferramentas ORM (Object-Relational Mapping) desenvolvido pela Microsoft para o .NET Framework.

Permite trabalhar com bancos de dados relacionais como se estivessemos trabalhando com objetos. Em resumo, o Entity Framework faz a ponte entre o mundo orientado a objetos e o mundo relacional.

### Entity

Entidade em português, é uma classe que representa uma tabela em um banco de dados. A Entity contém as propriedades que representam as colunas da tabela e pode conter métodos para acessar os dados do banco. Em outras palavras, é uma representação de uma tabela do banco de dados em forma de objeto.

### Model

Modelo em português, é uma classe que representa um conceito ou uma parte da lógica de negócios da aplicação. Uma Model pode ser composta por várias entidades (Entities) e pode conter regras de negócios que governam como essas entidades interagem entre si. Em outras palavras, uma Model é uma representação de uma parte da lógica de negócios da aplicação em forma de objeto.

A principal diferença entre uma Entity e uma Model é que uma Entity representa uma tabela do banco de dados, enquanto uma Model representa um conceito de negócios da aplicação.

### Primeiros passos

1. Inicie organizando o codigo criando as Models.
1. Crie o DataContext para representar o banco de dados em memória.
1. Crie os DbSets que são os conjuntos de dados.
1. Uma boa pratica é criar as propriedades do tipo DbSet colocando o nome no plural.

```Csharp
    public class BlogDataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
    }
```

Toda vez que for necessário interagir com o banco, utilize o método **SaveChanges** para persistir os dados.

```Csharp
    var tag = new Tag { Name = "ASP.NET", Slug = "aspnet" };
    context.Tags.Add(tag);
    context.SaveChanges();

    var tag = context.Tags.FirstOrDefault(x => x.Id == 1);
    tag.Name = ".NET";
    tag.Slug = "dotnet";
    context.Update(tag);
    context.SaveChanges();

    var tag = context.Tags.FirstOrDefault(x => x.Id == 1);
    context.Remove(tag);
    context.SaveChanges();
```

## Mapeamento

O mapeamento dos objetos com as tabelas podem ser feitos de 2 formas:

**DataAnnotations** | Forma mais simples de fazer o DE/PARA, adicionando anotações
nas classes.
Basta informar qual é o nome da tabela e qual é a chave primaria para relacionar.

```Csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Balta_EntityFramework.Models
{
[Table("Category")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(80)]
        [Column("Name", TypeName = "NVARCHAR")]
        public string Name { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(80)]
        [Column("Slug", TypeName = "VARCHAR")]
        public string Slug { get; set; }
    }
}
```

Para indicar a chave estrangeira, deve ser utilizada a anotação **ForeignKey**.
Em seguida, crie uma propriedade do tipo da classe que nos referimos.
Isso permite o Entity Framework faça a navegação pela propriedade.

```Csharp
// Trecho das anotações na classe Post
...
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; } // Propriedade de navegação do EF

        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }
        public User Author { get; set; } // Propriedade de navegação do EF
...
```

**FluentMapping** | Forma aprimorada fazer o DE/PARA, com mais recursos e possibilidades
de automatizar tarefas como criação de telas para interação.
Basta informar qual é o nome da tabela e qual é a chave primaria para relacionar.
