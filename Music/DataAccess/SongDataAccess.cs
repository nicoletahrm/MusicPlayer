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
    public class SongDataAccess : ISongDataAccess
    {
        private readonly NpgsqlConnection _connection;

        public SongDataAccess()
        {
            _connection = new("Server=localhost; Database=music_player; Port=5432; User id=postgres; Password=2001");
        }

        public void Create(Song song)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = 
                                    "INSERT INTO song (title, release_date, length) " +
                                    "VALUES (@title, @release_date, @length)";

            command.Parameters.AddWithValue("title", song.Title);
            command.Parameters.AddWithValue("release_date", song.ReleaseDate);
            command.Parameters.AddWithValue("length", song.Length);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public List<Song> Read()
        {
            List<Song> result = new List<Song>();

            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT song_id, title, release_date, length, likes FROM song";

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Song song = new Song();

                song.SongId = reader.GetInt32(0);
                song.Title = reader.GetString(1);
                song.ReleaseDate = reader.GetDateTime(2);
                song.Length = reader.GetInt32(3);
                song.Likes = reader.GetInt32(4);

                result.Add(song);
            }

            _connection.Close();

            return result;
        }

        public Song Read(int song_id)
        {
            Song song = new Song();

            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText = 
                                    "SELECT song_id, title, release_date, length, likes FROM song " +
                                    "WHERE song_id=@song_id";

            command.Parameters.AddWithValue("song_id", song_id);

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                song.SongId = reader.GetInt32(0);
                song.Title = reader.GetString(1);
                song.ReleaseDate = reader.GetDateTime(2);
                song.Length = reader.GetInt32(3);
            }

            _connection.Close();

            return song;
        }

        public void Update(Song song)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = 
                                    "UPDATE song " +
                                    "SET title = @title, release_date = @release_date, length = @length " +
                                    "WHERE song_id = @song_id";

            command.Parameters.AddWithValue("song_id", song.SongId);
            command.Parameters.AddWithValue("title", song.Title);
            command.Parameters.AddWithValue("release_date", song.ReleaseDate);
            command.Parameters.AddWithValue("length", song.Length);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public void Delete(int song_id)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText =
                                    "DELETE FROM song_music_type " +
                                    "WHERE song_id = @song_id; " +

                                    "DELETE FROM album_song " +
                                    "WHERE song_id = @song_id; " +

                                    "DELETE FROM artist_song " +
                                    "WHERE song_id = @song_id; " +

                                    "DELETE FROM playlist_song " +
                                    "WHERE song_id = @song_id; " +

                                    "DELETE FROM song " +
                                    "WHERE song_id = @song_id";

            command.Parameters.AddWithValue("song_id", song_id);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public void AddLike(int song_id)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText =
                                    "UPDATE song " +
                                    "SET likes = likes + 1 " +
                                    "WHERE song_id = @song_id";

            command.Parameters.AddWithValue("song_id", song_id);

            command.ExecuteNonQuery();

            _connection.Close();
        }
    }
}
