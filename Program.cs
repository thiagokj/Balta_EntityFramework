using Balta_EntityFramework.Models;
using Blog.Data;
using Microsoft.EntityFrameworkCore;

Console.Clear();

using (var context = new BlogDataContext())
{

    ExemploDiferencaEntreFirstSingle();

}

void ExemploCRUD()
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
        Exemplo de SELECT aprimorado no banco, filtrando e ordenando.

        É de EXTREMA importância fazer o filtro ANTES de chamar
        o ToList(). Assim evitamos problemas de performance, pois serão
        recuperados apenas os dados já filtrados. Caso contrário, todos os
        registros são retornados e posteriormente filtrados na aplicação.

        Um segundo ponto é adicionar a instrução AsNoTracking()
        antes do ToList(). Dessa forma o EF não retorna metadados, que
        são usados apenas nos casos de alteração e exclusão de
        registros, melhorando ainda mais a performance.
    */
    // var tags = context
    //     .Tags
    //     .Where(x => x.Name.Contains("DOT"))
    //     .AsNoTracking()
    //     .ToList();

    // foreach (var tag in tags)
    // {
    //     Console.WriteLine($"Id: {tag.Id} - Tag: {tag.Name} - Slug: {tag.Slug}");
    // }
}

void ExemploDiferencaEntreFirstSingle()
{
    using (var context = new BlogDataContext())
    {
        /*  
            Todos os métodos tipo de lista executam a consulta no banco.

            FirstOrDefault | Método mais utilizado, retorna apenas
            o primeiro registro encontrado.
            Não lança exceção caso haja mais registros conforme o filtro.

            Se não existir o registro, retorna nulo.
            É necessário informar o null safe para exibir
            o item e evitar exceção.
        */
        // var tag = context
        //     .Tags
        //     .AsNoTracking()
        //     .FirstOrDefault(x => x.Id == 5);
        // Console.WriteLine(tag?.Name);

        /*  
            SingleOrDefault | Retorna um único registro encontrado,
            caso haja duplicidade, lança uma exceção.

            Se não existir o registro, retorna nulo.
            É necessário informar o null safe para exibir
            o item e evitar exceção.
        */
        var tag = context
            .Tags
            .AsNoTracking()
            .SingleOrDefault(x => x.Id == 6);
        Console.WriteLine(tag?.Name);
    }
}