using BusinessLogic.Abstract;
using DoamainModels;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PlaylistSongDataAccess : IPlaylistSongDataAccess
    {
        private readonly NpgsqlConnection _connection;

        public PlaylistSongDataAccess()
        {
            _connection = new("Server=localhost; Database=music_player; Port=5432; User id=postgres; Password=2001");
        }

        public void Create(PlaylistSong playlistSong)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText =
                                    "INSERT INTO playlist_song (playlist_id, song_id) " +
                                    "VALUES (@playlist_id, @song_id)";

            command.Parameters.AddWithValue("playlist_id", playlistSong.PlaylistId);
            command.Parameters.AddWithValue("song_id", playlistSong.SongId);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public List<PlaylistSong> Read()
        {
            List<PlaylistSong> result = new List<PlaylistSong>();

            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText =
                                    "SELECT playlist_song_id, playlist.playlist_id, song.song_id, playlist.title, song.title FROM playlist_song " +
                                    "JOIN playlist ON playlist.playlist_id = playlist_song.playlist_id " +
                                    "JOIN song ON song.song_id = playlist_song.song_id";

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                PlaylistSong playlistSong = new PlaylistSong();

                playlistSong.PlaylistSongId = reader.GetInt32(0);
                playlistSong.PlaylistId = reader.GetInt32(1);
                playlistSong.SongId = reader.GetInt32(2);
                playlistSong.PlaylistName = reader.GetString(3);
                playlistSong.SongName = reader.GetString(4);

                result.Add(playlistSong);
            }

            _connection.Close();

            return result;
        }

        public PlaylistSong Read(int playlist_song_id)
        {
            PlaylistSong playlistSong = new PlaylistSong();

            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText =
                                    "SELECT playlist_song_id, playlist_id, song_id FROM playlist_song " +
                                    "WHERE playlist_song_id = @playlist_song_id";

            command.Parameters.AddWithValue("playlist_song_id", playlist_song_id);

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                playlistSong.PlaylistSongId = reader.GetInt32(0);
                playlistSong.PlaylistId = reader.GetInt32(1);
                playlistSong.SongId = reader.GetInt32(2);
            }

            _connection.Close();

            return playlistSong;
        }

        public void Update(PlaylistSong playlistSong)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText =
                                    "UPDATE playlist_song " +
                                    "SET playlist_id = @playlist_id, song_id = @song_id " +
                                    "WHERE playlist_song_id = @playlist_song_id";

            command.Parameters.AddWithValue("playlist_song_id", playlistSong.PlaylistSongId);
            command.Parameters.AddWithValue("playlist_id", playlistSong.PlaylistId);
            command.Parameters.AddWithValue("song_id", playlistSong.SongId);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public void Delete(int playlist_song_id)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText =
                                    "DELETE FROM playlist_song " +
                                    "WHERE playlist_song_id = @playlist_song_id";

            command.Parameters.AddWithValue("playlist_song_id", playlist_song_id);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public void AddArtistSongs(int artist_id, int playlist_id)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText =
                                    "INSERT INTO playlist_song (playlist_id, song_id) " +
                                    "SELECT @playlist_id, song_id FROM artist_song " +
                                    "WHERE artist_id = @artist_id ";

            command.Parameters.AddWithValue("playlist_id", playlist_id);
            command.Parameters.AddWithValue("artist_id", artist_id);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public void AddAlbumSongs(int album_id, int playlist_id)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText =
                                    "INSERT INTO playlist_song (playlist_id, song_id) " +
                                    "SELECT @playlist_id, song_id FROM album_song " +
                                    "WHERE album_id = @album_id ";

            command.Parameters.AddWithValue("playlist_id", playlist_id);
            command.Parameters.AddWithValue("album_id", album_id);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public void DeleteSongFromPlaylist(int song_id)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText =
                                    "DELETE FROM playlist_song " +
                                    "WHERE song_id = @song_id";

            command.Parameters.AddWithValue("song_id", song_id);

            command.ExecuteNonQuery();

            _connection.Close();
        }
    }
}
