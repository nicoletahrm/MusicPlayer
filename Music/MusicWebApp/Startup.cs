using BusinessLogic;
using BusinessLogic.Abstract;
using DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddSingleton<IArtistBL, ArtistBL>();
            services.AddSingleton<IArtistDataAccess, ArtistDataAccess>();

            services.AddSingleton<IAlbumBL, AlbumBL>();
            services.AddSingleton<IAlbumDataAccess, AlbumDataAccess>();

            services.AddSingleton<ISongBL, SongBL>();
            services.AddSingleton<ISongDataAccess, SongDataAccess>();

            services.AddSingleton<IMusicTypeBL, MusicTypeBL>();
            services.AddSingleton<IMusicTypeDataAccess, MusicTypeDataAccess>();

            services.AddSingleton<IArtistSongBL, ArtistSongBL>();
            services.AddSingleton<IArtistSongDataAccess, ArtistSongDataAccess>();

            services.AddSingleton<ISongMusicTypeBL, SongMusicTypeBL>();
            services.AddSingleton<ISongMusicTypeDataAccess, SongMusicTypeDataAccess>();

            services.AddSingleton<IPlaylistBL, PlaylistBL>();
            services.AddSingleton<IPlaylistDataAccess, PlaylistDataAccess>();

            services.AddSingleton<IAlbumSongBL, AlbumSongBL>();
            services.AddSingleton<IAlbumSongDataAccess, AlbumSongDataAccess>();

            services.AddSingleton<IPlaylistArtistBL, PlaylistArtistBL>();
            services.AddSingleton<IPlaylistArtistDataAccess, PlaylistArtistDataAccess>();

            services.AddSingleton<IPlaylistAlbumBL, PlaylistAlbumBL>();
            services.AddSingleton<IPlaylistAlbumDataAccess, PlaylistAlbumDataAccess>();

            services.AddSingleton<IPlaylistSongBL, PlaylistSongBL>();
            services.AddSingleton<IPlaylistSongDataAccess, PlaylistSongDataAccess>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
