using Microsoft.EntityFrameworkCore;
using Telephonebook.Data;
namespace Telephonebook.Models
{
	public class Person
	{
		public int Id { get; set; }	
		public string FullName { get; set; }
		public long Mobile { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }

	}


//public static class PersonEndpoints
//{
//	public static void MapPersonEndpoints (this IEndpointRouteBuilder routes)
//    {
//        routes.MapGet("/api/Person", async (TelephonebookContext db) =>
//        {
//            return await db.Person.ToListAsync();
//        })
//        .WithName("GetAllPersons")
//        .Produces<List<Person>>(StatusCodes.Status200OK);

//        routes.MapGet("/api/Person/{id}", async (int Id, TelephonebookContext db) =>
//        {
//            return await db.Person.FindAsync(Id)
//                is Person model
//                    ? Results.Ok(model)
//                    : Results.NotFound();
//        })
//        .WithName("GetPersonById")
//        .Produces<Person>(StatusCodes.Status200OK)
//        .Produces(StatusCodes.Status404NotFound);

//        routes.MapPut("/api/Person/{id}", async (int Id, Person person, TelephonebookContext db) =>
//        {
//            var foundModel = await db.Person.FindAsync(Id);

//            if (foundModel is null)
//            {
//                return Results.NotFound();
//            }

//            db.Update(person);

//            await db.SaveChangesAsync();

//            return Results.NoContent();
//        })
//        .WithName("UpdatePerson")
//        .Produces(StatusCodes.Status404NotFound)
//        .Produces(StatusCodes.Status204NoContent);

//        routes.MapPost("/api/Person/", async (Person person, TelephonebookContext db) =>
//        {
//            db.Person.Add(person);
//            await db.SaveChangesAsync();
//            return Results.Created($"/Persons/{person.Id}", person);
//        })
//        .WithName("CreatePerson")
//        .Produces<Person>(StatusCodes.Status201Created);


//        routes.MapDelete("/api/Person/{id}", async (int Id, TelephonebookContext db) =>
//        {
//            if (await db.Person.FindAsync(Id) is Person person)
//            {
//                db.Person.Remove(person);
//                await db.SaveChangesAsync();
//                return Results.Ok(person);
//            }

//            return Results.NotFound();
//        })
//        .WithName("DeletePerson")
//        .Produces<Person>(StatusCodes.Status200OK)
//        .Produces(StatusCodes.Status404NotFound);
//    }
//}
}
