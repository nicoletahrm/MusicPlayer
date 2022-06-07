using BusinessLogic;
using BusinessLogic.Abstract;
using DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompositionRoot
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
            services.AddSingleton<IArtistBL, ArtistBL>();
            services.AddSingleton<IArtistDataAccess, ArtistDataAccess>();

            services.AddSingleton<IAlbumBL, AlbumBL>();
            services.AddSingleton<IAlbumDataAccess, AlbumDataAccess>();

            services.AddSingleton<ISongBL, SongBL>();
            services.AddSingleton<ISongDataAccess, SongDataAccess>();

            services.AddSingleton<IAlbumBL, AlbumBL>();
            services.AddSingleton<IAlbumDataAccess, AlbumDataAccess>();

            services.AddSingleton<ISongBL, SongBL>();
            services.AddSingleton<ISongDataAccess, SongDataAccess>();

            services.AddSingleton<IAlbumSongBL, AlbumSongBL>();
            services.AddSingleton<IAlbumSongDataAccess, AlbumSongDataAccess>();

            services.AddSingleton<IMusicTypeBL, MusicTypeBL>();
            services.AddSingleton<IMusicTypeDataAccess, MusicTypeDataAccess>();

            services.AddSingleton<IArtistSongBL, ArtistSongBL>();
            services.AddSingleton<IArtistSongDataAccess, ArtistSongDataAccess>();

            services.AddSingleton<ISongMusicTypeBL, SongMusicTypeBL>();
            services.AddSingleton<ISongMusicTypeDataAccess, SongMusicTypeDataAccess>();

            services.AddSingleton<IPlaylistBL, PlaylistBL>();
            services.AddSingleton<IPlaylistDataAccess, PlaylistDataAccess>();

            services.AddSingleton<IPlaylistSongBL, PlaylistSongBL>();
            services.AddSingleton<IPlaylistSongDataAccess, PlaylistSongDataAccess>();

            services.AddSingleton<IPlaylistArtistBL, PlaylistArtistBL>();
            services.AddSingleton<IPlaylistArtistDataAccess, PlaylistArtistDataAccess>();

            services.AddSingleton<IPlaylistAlbumBL, PlaylistAlbumBL>();
            services.AddSingleton<IPlaylistAlbumDataAccess, PlaylistAlbumDataAccess>();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CompositionRoot", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CompositionRoot v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
