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
    public class PlaylistArtistDataAccess : IPlaylistArtistDataAccess
    {
        private readonly NpgsqlConnection _connection;

        public PlaylistArtistDataAccess()
        {
            _connection = new("Server=localhost; Database=music_player; Port=5432; User id=postgres; Password=2001");
        }

        public void Create(PlaylistArtist playlistArtist)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText =
                                    "INSERT INTO playlist_artist (playlist_id, artist_id) " +
                                    "VALUES (@playlist_id, @artist_id)";

            command.Parameters.AddWithValue("playlist_id", playlistArtist.PlaylistId);
            command.Parameters.AddWithValue("artist_id", playlistArtist.ArtistId);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public List<PlaylistArtist> Read()
        {
            List<PlaylistArtist> result = new List<PlaylistArtist>();

            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText =
                                    "SELECT playlist_artist_id, playlist.playlist_id, artist.artist_id, playlist.title, artist.first_name, artist.last_name FROM playlist_artist " +
                                    "JOIN playlist ON playlist.playlist_id = playlist_artist.playlist_id " +
                                    "JOIN artist ON artist.artist_id = playlist_artist.artist_id";

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                PlaylistArtist playlistArtist = new PlaylistArtist();

                playlistArtist.PlaylistArtistId = reader.GetInt32(0);
                playlistArtist.PlaylistId = reader.GetInt32(1);
                playlistArtist.ArtistId = reader.GetInt32(2);
                playlistArtist.PlaylistName = reader.GetString(3);
                playlistArtist.ArtistName = reader.GetString(5) + " " + reader.GetString(4);

                result.Add(playlistArtist);
            }

            _connection.Close();

            return result;
        }

        public PlaylistArtist Read(int playlist_artist_id)
        {
            PlaylistArtist playlistArtist = new PlaylistArtist();

            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText =
                                    "SELECT playlist_artist_id, playlist_id, artist_id FROM playlist_artist " +
                                    "WHERE playlist_artist_id = @playlist_artist_id";

            command.Parameters.AddWithValue("playlist_artist_id", playlist_artist_id);

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                playlistArtist.PlaylistArtistId = reader.GetInt32(0);
                playlistArtist.PlaylistId = reader.GetInt32(1);
                playlistArtist.ArtistId = reader.GetInt32(2);
            }

            _connection.Close();

            return playlistArtist;
        }

        public void Update(PlaylistArtist playlistArtist)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText =
                                    "UPDATE playlist_artist " +
                                    "SET playlist_id = @playlist_id, artist_id = @artist_id " +
                                    "WHERE playlist_artist_id = @playlist_artist_id";

            command.Parameters.AddWithValue("playlist_artist_id", playlistArtist.PlaylistArtistId);
            command.Parameters.AddWithValue("playlist_id", playlistArtist.PlaylistId);
            command.Parameters.AddWithValue("artist_id", playlistArtist.ArtistId);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public void Delete(int playlist_artist_id)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText =
                                    "DELETE FROM playlist_artist " +
                                    "WHERE playlist_artist_id = @playlist_artist_id";

            command.Parameters.AddWithValue("playlist_artist_id", playlist_artist_id);

            command.ExecuteNonQuery();

            _connection.Close();
        }
    }
}
