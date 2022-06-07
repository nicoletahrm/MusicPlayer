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
    public class AlbumSongDataAccess : IAlbumSongDataAccess
    {
        private readonly NpgsqlConnection _connection;
        public AlbumSongDataAccess()
        {
            _connection = new("Server=localhost; Database=music_player; Port=5432; User id=postgres; Password=2001");
        }

        public void Create(AlbumSong albumSong)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText = "INSERT INTO album_song (album_id, song_id) VALUES (@album_id, @song_id)";

            command.Parameters.AddWithValue("album_id", albumSong.AlbumId);
            command.Parameters.AddWithValue("song_id", albumSong.SongId);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public List<AlbumSong> Read()
        {
            List<AlbumSong> result = new List<AlbumSong>();

            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText = 
                                    "SELECT album_song_id, album.album_id, song.song_id, album.title, song.title FROM album_song " +
                                    "JOIN song ON song.song_id = album_song.song_id " +
                                    "JOIN album ON album.album_id = album_song.album_id";

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                AlbumSong albumSong = new AlbumSong();

                albumSong.AlbumSongId = reader.GetInt32(0);
                albumSong.AlbumId = reader.GetInt32(1);
                albumSong.SongId = reader.GetInt32(2);
                albumSong.AlbumName = reader.GetString(3);
                albumSong.SongName = reader.GetString(4);

                result.Add(albumSong);
            }

            _connection.Close();

            return result;
        }

        public AlbumSong Read(int album_song_id)
        {
            AlbumSong albumSong = new AlbumSong();

            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT album_song_id, album_id, song_id FROM album_song " +
                                    "WHERE album_song_id=@album_song_id";

            command.Parameters.AddWithValue("album_song_id", album_song_id);

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                albumSong.AlbumSongId = reader.GetInt32(0);
                albumSong.AlbumId = reader.GetInt32(1);
                albumSong.SongId = reader.GetInt32(2);
            }

            _connection.Close();

            return albumSong;
        }

        public void Update(AlbumSong albumSong)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "UPDATE album_song " +
                                    "SET album_id = @album_id, song_id = @song_id " +
                                    "WHERE album_song_id = @album_song_id";

            command.Parameters.AddWithValue("album_song_id", albumSong.AlbumSongId);
            command.Parameters.AddWithValue("album_id", albumSong. AlbumId);
            command.Parameters.AddWithValue("song_id", albumSong.SongId);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public void Delete(int album_song_id)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "DELETE FROM album_song " +
                                    "WHERE album_song_id = @album_song_id";

            command.Parameters.AddWithValue("album_song_id", album_song_id);

            command.ExecuteNonQuery();

            _connection.Close();
        }
    }
}
