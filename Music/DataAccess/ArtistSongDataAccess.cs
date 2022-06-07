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
    public class ArtistSongDataAccess : IArtistSongDataAccess
    {
        private readonly NpgsqlConnection _connection;
        public ArtistSongDataAccess()
        {
            _connection = new("Server=localhost; Database=music_player; Port=5432; User id=postgres; Password=2001");
        }

        public void Create(ArtistSong artistSong)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText = "INSERT INTO artist_song (artist_id, song_id) VALUES (@artist_id, @song_id)";

            command.Parameters.AddWithValue("artist_id", artistSong.ArtistId);
            command.Parameters.AddWithValue("song_id", artistSong.SongId);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public List<ArtistSong> Read()
        {
            List<ArtistSong> result = new List<ArtistSong>();

            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText =
                                    "SELECT artist_song_id, artist.artist_id, song.song_id, artist.first_name, artist.last_name, song.title FROM artist_song " +
                                    "JOIN artist ON artist.artist_id = artist_song.artist_id " +
                                    "JOIN song ON song.song_id = artist_song.song_id";

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ArtistSong artistSong = new ArtistSong();

                artistSong.ArtistSongId = reader.GetInt32(0);
                artistSong.ArtistId = reader.GetInt32(1);
                artistSong.SongId = reader.GetInt32(2);
                artistSong.ArtistName = reader.GetString(4) + " " + reader.GetString(3);
                artistSong.SongName = reader.GetString(5);

                result.Add(artistSong);
            }

            _connection.Close();

            return result;
        }

        public ArtistSong Read(int artist_song_id)
        {
            ArtistSong artistSong = new ArtistSong();

            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText = 
                                    "SELECT artist_song_id, artist_id, song_id FROM artist_song " +
                                    "WHERE artist_song_id=@artist_song_id";

            command.Parameters.AddWithValue("artist_song_id", artist_song_id);

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                artistSong.ArtistSongId = reader.GetInt32(0);
                artistSong.ArtistId = reader.GetInt32(1);
                artistSong.SongId = reader.GetInt32(2);
            }

            _connection.Close();

            return artistSong;
        }

        public void Update(ArtistSong artistSong)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "UPDATE artist_song " +
                                    "SET artist_id = @artist_id, song_id = @song_id " +
                                    "WHERE artist_song_id = @artist_song_id";

            command.Parameters.AddWithValue("artist_song_id", artistSong.ArtistSongId);
            command.Parameters.AddWithValue("artist_id", artistSong.ArtistId);
            command.Parameters.AddWithValue("song_id", artistSong.SongId);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public void Delete(int artist_song_id)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "DELETE FROM artist_song " +
                                    "WHERE artist_song_id = @artist_song_id";

            command.Parameters.AddWithValue("artist_song_id", artist_song_id);

            command.ExecuteNonQuery();

            _connection.Close();
        }
    }
}
