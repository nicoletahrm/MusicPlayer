using BusinessLogic.Abstract;
using DomainModels;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class AlbumDataAccess : IAlbumDataAccess
    {
        private readonly NpgsqlConnection _connection;

        public AlbumDataAccess()
        {
            _connection = new("Server=localhost; Database=music_player; Port=5432; User id=postgres; Password=2001");
        }

        public void Create(Album album)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText = "INSERT INTO album (artist_id, title, release_date, record_label_name) VALUES (@artist_id, @title, @release_date, @record_label_name)";

            command.Parameters.AddWithValue("artist_id", album.ArtistId);
            command.Parameters.AddWithValue("title", album.Title);
            command.Parameters.AddWithValue("release_date", album.ReleaseDate);
            command.Parameters.AddWithValue("record_label_name", album.RecordLabelName);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public List<Album> Read()
        {
            List<Album> result = new List<Album>();

            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText =
                                    "SELECT album_id, artist.artist_id, title, release_date, record_label_name, artist.first_name, artist.last_name FROM album " +
                                    "JOIN artist ON artist.artist_id = album.artist_id " +
                                    "ORDER BY title";

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Album album = new Album();

                album.AlbumId = reader.GetInt32(0);
                album.ArtistId = reader.GetInt32(1);
                album.Title = reader.GetString(2);
                album.ReleaseDate = reader.GetDateTime(3);
                album.RecordLabelName = reader.GetString(4);
                album.ArtistName = reader.GetString(6) + " " + reader.GetString(5);
                
                result.Add(album);
            }

            _connection.Close();

            return result;
        }

        public Album Read(int album_id)
        {
            Album album = new Album();

            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT album_id, artist_id, title, release_date, record_label_name FROM album " +
                                    "WHERE album_id=@album_id";

            command.Parameters.AddWithValue("album_id", album_id);

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                album.AlbumId = reader.GetInt32(0);
                album.ArtistId = reader.GetInt32(1);
                album.Title = reader.GetString(2);
                album.ReleaseDate = reader.GetDateTime(3);
                album.RecordLabelName = reader.GetString(4);
            }

            _connection.Close();

            return album;
        }

        public void Update(Album album)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "UPDATE album " +
                                    "SET artist_id = @artist_id, title = @title, release_date = @release_date, record_label_name = @record_label_name " +
                                    "WHERE album_id = @album_id";

            command.Parameters.AddWithValue("album_id", album.AlbumId);
            command.Parameters.AddWithValue("artist_id", album.ArtistId);
            command.Parameters.AddWithValue("title", album.Title);
            command.Parameters.AddWithValue("release_date", album.ReleaseDate);
            command.Parameters.AddWithValue("record_label_name", album.RecordLabelName);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public void Delete(int album_id)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText =
                                    "DELETE FROM playlist_album " +
                                    "WHERE album_id = @album_id; " +

                                    "DELETE FROM album_song " +
                                    "WHERE album_id = @album_id; " +

                                    "DELETE FROM album " +
                                    "WHERE album_id = @album_id";

            command.Parameters.AddWithValue("album_id", album_id);

            command.ExecuteNonQuery();

            _connection.Close();
        }
    }
}
