using Azure_HW_VVP.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/ping", () => "pong!");

//CRUD
//1. get all
app.MapGet("/all", async (ApplicationDbContext db) =>
{
    return await db.VVPs.ToListAsync();
});
//2. get by id
app.MapGet("/get/{id}", async (int id, ApplicationDbContext db) =>
{
    return await db.VVPs.FirstOrDefaultAsync((vvp) => vvp.Id == id);
});
//3. add
app.MapPost("/add", async (VVP vvp, ApplicationDbContext db)=>
{
    await db.VVPs.AddAsync(vvp);
    await db.SaveChangesAsync();
    return vvp;
});
//4. delete
app.MapPost("/delete/{id}", async (int id, ApplicationDbContext db) =>
{
    VVP? removable = await db.VVPs.FirstOrDefaultAsync((vvp)=> vvp.Id == id);
    if (removable != null)
    {
        db.VVPs.Remove(removable);
        await db.SaveChangesAsync();
    }
    return removable;
});
//5. update
app.MapPost("/update", async (VVP vvp, ApplicationDbContext db) =>
{
    db.VVPs.Update(vvp);
    await db.SaveChangesAsync();
    return vvp;
});


app.Run();
