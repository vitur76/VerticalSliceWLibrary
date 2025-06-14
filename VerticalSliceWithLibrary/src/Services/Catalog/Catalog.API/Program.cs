var builder = WebApplication.CreateBuilder(args);

// ======================================== Add services to the DI container ==============================================================

// Configurare Serilog din fișier JSON
builder.Host.UseSerilog((context, config) => config.ReadFrom.Configuration(context.Configuration));


/*
//De obicei, se încarcă fișierele appsettings.json și cele specifice mediului în toate cazurile, iar UserSecrets este adăugat în plus doar în development.
//User Secrets doar adaugă un strat suplimentar pentru development, fără a exclude fișierele JSON.

//appsettings.json: Setări comune tuturor mediilor.
//appsettings.Development.json: Setări specifice mediului de dezvoltare.
//appsettings.Production.json: Setări specifice mediului de producție.

 *Cum Funcționează Combinarea Fișierelor de Configurare
Ordinea de Încărcare:

Fișierul appsettings.json este încărcat primul și stabilește valorile de bază pentru configurație.
Fișierul appsettings.{Environment}.json este încărcat după appsettings.json și poate suprascrie sau completa valorile din acesta.
Suprascrierea Valorilor:

Dacă o cheie este definită în ambele fișiere, valoarea din appsettings.{Environment}.json va suprascrie valoarea din appsettings.json.
Această mecanică permite specificarea unor valori implicite în appsettings.json și ajustarea acestora pentru diferite medii în fișierele appsettings.{Environment}.json.
Combinarea Structurilor:

Structurile JSON sunt combinate, astfel încât secțiunile care nu sunt prezente în appsettings.{Environment}.json vor rămâne neschimbate în configurația finală.
Acest lucru permite adăugarea sau ajustarea doar a setărilor relevante pentru mediul specific, fără a repeta întreaga structură de configurare.
 *
 */

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: false) //in caz ca exista suprascrie cheile din fisierul obligatoriu appsettings.json!
    .AddEnvironmentVariables();

if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}


// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Exemplu de configurare a `allowedOrigins` din configurație
var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowedOriginsPolicy", policyBuilder =>
    {
        if (allowedOrigins is not null && allowedOrigins.Contains("*"))
        {
            policyBuilder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        }
        else
        {
            policyBuilder.WithOrigins(allowedOrigins ?? Array.Empty<string>())
                .AllowAnyMethod()
                .AllowAnyHeader();
        }
    });
});

builder.Services.AddCarter();

var assembly = typeof(Program).Assembly;

// Obține connection string-ul din configurație
var connectionString = builder.Configuration.GetConnectionString("Database");

/*
builder.Services.AddDbContext<AppDbContext>((sp, options) =>
{
    options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
    options.UseNpgsql(connectionString);
});
*/

builder.Services.AddDbContext<AppDbContext>((sp, options) =>
{
    options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database"));
});


builder.Services.AddScoped<IApplicationDbContext, AppDbContext>();
// Add services to the container.
builder.Services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();

builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

builder.Services.AddHealthChecks()
    .AddNpgSql(connectionString!);


var app = builder.Build();

//============================================= Configure the HTTP request pipeline =====================================================
// Enable middleware for Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    // Inițializarea bazei de date
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<AppDbContext>();

        try
        {
            // Creează baza de date dacă nu există
            context.Database.EnsureCreated();
        }
        catch (Exception ex)
        {
            // Loghează eroarea sau gestionează cum vrei
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "A apărut o eroare la crearea bazei de date.");
        }

        // Poți apela metoda Seed dacă ai nevoie să populezi anumite date
        DbInitializer.Seed(services);
    }
}

// Aplică politica CORS
app.UseCors("AllowedOriginsPolicy");
app.UseStatusCodePages(); // Pagină pentru erorile HTTP (ex: 404)
app.UseDefaultFiles(); // Implicit va căuta index.html, default.html
app.UseStaticFiles();  // Servește fișiere statice
app.MapCarter();
app.UseExceptionHandler(options => { });//??



app.Run();

public partial class Program { }