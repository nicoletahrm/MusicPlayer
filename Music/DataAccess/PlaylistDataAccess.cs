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
    public class PlaylistDataAccess : IPlaylistDataAccess
    {
        private readonly NpgsqlConnection _connection;

        public PlaylistDataAccess()
        {
            _connection = new("Server=localhost; Database=music_player; Port=5432; User id=postgres; Password=2001");
        }

        public void Create(Playlist playlist)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText =
                                    "INSERT INTO playlist (title) " +
                                    "VALUES (@title)";

            command.Parameters.AddWithValue("title", playlist.Title);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public List<Playlist> Read()
        {
            List<Playlist> result = new List<Playlist>();

            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT playlist_id, title FROM playlist " + 
                                  "ORDER BY title";

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Playlist playlist = new Playlist();

                playlist.PlaylistId = reader.GetInt32(0);
                playlist.Title = reader.GetString(1);

                result.Add(playlist);
            }

            _connection.Close();

            return result;
        }

        public Playlist Read(int playlist_id)
        {
            Playlist playlist = new Playlist();

            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = 
                                    "SELECT playlist_id, title FROM playlist " +
                                    "WHERE playlist_id = @playlist_id";

            command.Parameters.AddWithValue("playlist_id", playlist_id);

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                playlist.PlaylistId = reader.GetInt32(0);
                playlist.Title = reader.GetString(1);
            }

            _connection.Close();

            return playlist;
        }

        public void Update(Playlist playlist)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText =
                                    "UPDATE playlist " +
                                    "SET title = @title " +
                                    "WHERE playlist_id = @playlist_id";

            command.Parameters.AddWithValue("playlist_id", playlist.PlaylistId);
            command.Parameters.AddWithValue("title", playlist.Title);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public void Delete(int playlist_id)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText =
                                    "DELETE FROM playlist_artist " +
                                    "WHERE playlist_id = @playlist_id; " +

                                    "DELETE FROM playlist_album " +
                                    "WHERE playlist_id = @playlist_id; " +

                                    "DELETE FROM playlist_song " +
                                    "WHERE playlist_id = @playlist_id; " +

                                    "DELETE FROM playlist " +
                                    "WHERE playlist_id = @playlist_id;";

            command.Parameters.AddWithValue("playlist_id", playlist_id);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public List<Song> PlaylistSongs(int playlist_id)
        {
            List<Song> result = new List<Song>();

            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText =
                                    "SELECT song.song_id, song.title, song.release_date, song.length, song.likes FROM playlist_song " +
                                    "JOIN song ON playlist_song.song_id = song.song_id " +
                                    "WHERE playlist_id = @playlist_id";

            command.Parameters.AddWithValue("playlist_id", playlist_id);

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
    }
}
