using CharityPost.Presentation.StartupExtensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.ConfigureRepositories();
builder.Services.ConfigureHelpers();
builder.Services.ConfigureServices();
builder.Services.ConfigureApplicationIdentity(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else if (app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
    //app.UseExceptionHandler("/error");
    //app.UseStatusCodePagesWithReExecute("/error/{0}");
    //app.UseExceptionHandlingMiddleware(); not implemented yet
}

app.UseHsts();
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();