using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MusicStore.Domain.Identity;
using MusicStore.Repository;
using MusicStore.Repository.Implementation;
using MusicStore.Repository.Implementation.PartnerStore;
using MusicStore.Repository.Interface;
using MusicStore.Repository.Interface.PartnerRepository;
using MusicStore.Service.Implementation;
using MusicStore.Service.Implementation.PartnerStore;
using MusicStore.Service.Interface;
using MusicStore.Service.Interface.PartnerStore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<PartnerStoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PartnerConnection")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<EShopApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(IAlbumsRepository), typeof(AlbumsRepository));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(ITracksRepository), typeof(TracksRepository));
builder.Services.AddScoped(typeof(IPartnerTracksRepository), typeof(PartnerTracksRepository));
builder.Services.AddScoped(typeof(IUserPlaylistsRepository), typeof(UserPlaylistsRepository));
builder.Services.AddScoped(typeof(IUserPlaylistTrackRepository), typeof(UserPlaylistTrackRepository));
builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepository));

builder.Services.AddTransient<IAlbumsService, AlbumsService>();
builder.Services.AddTransient<IArtistsService, ArtistsService>();
builder.Services.AddTransient<ITracksService, TracksService>();
builder.Services.AddTransient<IPartnerTracksService, PartnerTracksService>();
builder.Services.AddTransient<IUserPlaylistsService,UserPlaylistsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
