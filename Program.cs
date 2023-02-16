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
    var tag = context.Tags.FirstOrDefault(x => x.Id == 1);
    context.Remove(tag);
    context.SaveChanges();

}

