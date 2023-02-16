using Balta_EntityFramework.Models;
using Blog.Data;

using (var context = new BlogDataContext())
{
    /*
        Exemplo de INSERT no banco.
        um objeto instanciado com new não possui TRACKING do EF
        e não pode ser rastreado.
    */
    // var tag = new Tag { Name = "ASP.NET", Slug = "aspnet" };
    // context.Tags.Add(tag);
    // context.SaveChanges(); // Faz o commit no banco

    /*
        Exemplo de UPDATE no banco.
        É realizada operação de REHYDRATATION ou reidratação.
        Sempre é necessario resgatar do banco o item a ser atualizado.

        O EF tem o retorno dos METADADOS e sabe quais campos devem 
        ser atualizados.
    */
    // var tag = context.Tags.FirstOrDefault(x => x.Id == 1);
    // tag.Name = ".NET";
    // tag.Slug = "dotnet";
    // context.Update(tag);
    // context.SaveChanges();

    /*
        Exemplo de DELETE no banco.
        É realizada operação de REHYDRATATION ou reidratação.
        Sempre é necessario resgatar do banco o item a ser excluído.

        O EF tem o retorno dos METADADOS e sabe quais registros devem 
        ser excluídos.
    */
    // var tag = context.Tags.FirstOrDefault(x => x.Id == 1);
    // context.Remove(tag);
    // context.SaveChanges();

    /*
        Exemplo de SELECT no banco.
        O retorno da consulta no banco só é efetivamente realizado quando
        é feita uma chamada de um método (Ex: ToList()) após a atribuição
        do contexto ou quando é feito um ForEach para percorrer os dados.
    */
    // var tags = context.Tags.ToList();
    // foreach (var tag in tags)
    // {
    //     Console.WriteLine($"Tag: {tag.Name} - Slug: {tag.Slug}");
    // }

    /*
        Exemplo de SELECT no banco, filtrando e ordenando.
        É de EXTREMA importância fazer o filtro ANTES de chamar
        o ToList(). Assim evitamos problemas de performance, pois serão
        recuperados apenas os dados já filtrados.
        Caso contrário, todos os registros são retornados e posteriormente
        filtrados na aplicação.
    */
    var tags = context
        .Tags
        .Where(x => x.Name.Contains("DOT"))
        .ToList();

    foreach (var tag in tags)
    {
        Console.WriteLine($"Id: {tag.Id} - Tag: {tag.Name} - Slug: {tag.Slug}");
    }
}

