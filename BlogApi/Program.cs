using Autofac;
using Autofac.Extensions.DependencyInjection;
using BlogApi.Context;
using BlogApi.Common;
using BlogApi.Exceptions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(autofacBuilder =>
{
    var assembly = typeof(Program).Assembly;

    autofacBuilder.RegisterAssemblyOpenGenericTypes(assembly)
        .Where(t => typeof(IScopedDependency).IsAssignableFrom(t) && !t.IsInterface && t.IsGenericType)
        .As(type => type.GetInterfaces()
            .Where(interf => interf.Name == $"I{type.Name}")
            .Select(interf => interf.GetGenericTypeDefinition()))
        .InstancePerLifetimeScope();

    autofacBuilder.RegisterAssemblyTypes(assembly)
        .Where(t => typeof(IScopedDependency).IsAssignableFrom(t) && !t.IsInterface && !t.IsGenericType)
        .As(type => type.GetInterfaces()
            .Where(interf => interf.Name == $"I{type.Name}"))
        .InstancePerLifetimeScope();
});

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<BlogContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseExceptionHandler();
app.UseHttpsRedirection();
app.MapControllers();
app.Run();