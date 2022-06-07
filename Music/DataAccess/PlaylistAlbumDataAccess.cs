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
    public class PlaylistAlbumDataAccess : IPlaylistAlbumDataAccess
    {
        private readonly NpgsqlConnection _connection;

        public PlaylistAlbumDataAccess()
        {
            _connection = new("Server=localhost; Database=music_player; Port=5432; User id=postgres; Password=2001");
        }

        public void Create(PlaylistAlbum playlistAlbum)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText =
                                    "INSERT INTO playlist_album (playlist_id, album_id) " +
                                    "VALUES (@playlist_id, @album_id)";

            command.Parameters.AddWithValue("playlist_id", playlistAlbum.PlaylistId);
            command.Parameters.AddWithValue("album_id", playlistAlbum.AlbumId);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public List<PlaylistAlbum> Read()
        {
            List<PlaylistAlbum> result = new List<PlaylistAlbum>();

            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText = 
                                    "SELECT playlist_album_id, playlist.playlist_id, album.album_id, playlist.title, album.title FROM playlist_album " +
                                    "JOIN playlist ON playlist.playlist_id = playlist_album.playlist_id " +
                                    "JOIN album ON album.album_id = playlist_album.album_id";

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                PlaylistAlbum playlistAlbum = new PlaylistAlbum();

                playlistAlbum.PlaylistAlbumId = reader.GetInt32(0);
                playlistAlbum.PlaylistId = reader.GetInt32(1);
                playlistAlbum.AlbumId = reader.GetInt32(2);
                playlistAlbum.PlaylistName = reader.GetString(3);
                playlistAlbum.AlbumName = reader.GetString(4);

                result.Add(playlistAlbum);
            }

            _connection.Close();

            return result;
        }

        public PlaylistAlbum Read(int playlist_album_id)
        {
            PlaylistAlbum playlistAlbum = new PlaylistAlbum();

            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText =
                                    "SELECT playlist_album_id, playlist_id, album_id FROM playlist_album " +
                                    "WHERE playlist_album_id = @playlist_album_id";

            command.Parameters.AddWithValue("playlist_album_id", playlist_album_id);

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                playlistAlbum.PlaylistAlbumId = reader.GetInt32(0);
                playlistAlbum.PlaylistId = reader.GetInt32(1);
                playlistAlbum.AlbumId = reader.GetInt32(2);
            }

            _connection.Close();

            return playlistAlbum;
        }

        public void Update(PlaylistAlbum playlistAlbum)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText =
                                    "UPDATE playlist_album " +
                                    "SET playlist_id = @playlist_id, album_id = @album_id " +
                                    "WHERE playlist_album_id = @playlist_album_id";

            command.Parameters.AddWithValue("playlist_album_id", playlistAlbum.PlaylistAlbumId);
            command.Parameters.AddWithValue("playlist_id", playlistAlbum.PlaylistId);
            command.Parameters.AddWithValue("album_id", playlistAlbum.AlbumId);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public void Delete(int playlist_album_id)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText =
                                    "DELETE FROM playlist_album " +
                                    "WHERE playlist_album_id = @playlist_album_id";

            command.Parameters.AddWithValue("playlist_album_id", playlist_album_id);

            command.ExecuteNonQuery();

            _connection.Close();
        }
    }
}
