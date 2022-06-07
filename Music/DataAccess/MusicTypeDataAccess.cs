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
    public class MusicTypeDataAccess : IMusicTypeDataAccess
    {
        private readonly NpgsqlConnection _connection;
        public MusicTypeDataAccess()
        {
            _connection = new("Server=localhost; Database=music_player; Port=5432; User id=postgres; Password=2001");
        }

        public void Create(MusicType musicType)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText = "INSERT INTO music_type (genre) VALUES (@genre)";

            command.Parameters.AddWithValue("genre", musicType.Genre);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public List<MusicType> Read()
        {
            List<MusicType> result = new List<MusicType>();

            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText = "SELECT music_type_id, genre FROM music_type";

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                MusicType musicType = new MusicType();

                musicType.MusicTypeId = reader.GetInt32(0);
                musicType.Genre = reader.GetString(1);

                result.Add(musicType);
            }

            _connection.Close();

            return result;
        }

        public MusicType Read(int music_type_id)
        {
            MusicType musicType = new MusicType();

            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText = 
                                    "SELECT music_type_id, genre FROM music_type " +
                                    "WHERE music_type_id=@music_type_id";

            command.Parameters.AddWithValue("music_type_id", music_type_id);

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                musicType.MusicTypeId = reader.GetInt32(0);
                musicType.Genre = reader.GetString(1);
            }

            _connection.Close();

            return musicType;
        }

        public void Update(MusicType musicType)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = 
                                    "UPDATE music_type " +
                                    "SET genre = @genre " +
                                    "WHERE music_type_id = @music_type_id";

            command.Parameters.AddWithValue("music_type_id", musicType.MusicTypeId);
            command.Parameters.AddWithValue("genre", musicType.Genre);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public void Delete(int music_type_id)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText =
                                    "DELETE FROM song_music_type " +
                                    "WHERE music_type_id = @music_type_id; " +

                                    "DELETE FROM music_type " +
                                    "WHERE music_type_id = @music_type_id";

            command.Parameters.AddWithValue("music_type_id", music_type_id);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public List<Song> MostLikedSongs(string genre)
        {
            List<Song> result = new List<Song>();

            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText =
                                    "SELECT song.title, song.likes FROM song_music_type " +
                                    "JOIN music_type ON music_type.music_type_id = song_music_type.music_type_id " +
                                    "JOIN song ON song.song_id = song_music_type.song_id " +
                                    "WHERE music_type.genre = @genre " +
                                    "ORDER BY song.likes DESC " +
                                    "LIMIT 5;";

            command.Parameters.AddWithValue("genre", genre);

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Song songs = new Song();

                songs.Title = reader.GetString(0);
                songs.Likes = reader.GetInt32(1);

                result.Add(songs);
            }

            _connection.Close();

            return result;
        }

        public List<MusicType> TopGenre()
        {
            List<MusicType> result = new List<MusicType>();

            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText =
                                    "SELECT music_type.genre, SUM(song.likes) FROM song_music_type " +
                                    "JOIN music_type ON music_type.music_type_id = song_music_type.music_type_id " +
                                    "JOIN song ON song.song_id = song_music_type.song_id " +
                                    "GROUP BY music_type.genre " +
                                    "ORDER BY SUM(song.likes) DESC " +
                                    "LIMIT 5;";

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                MusicType musicType = new MusicType();

                musicType.Genre = reader.GetString(0);

                result.Add(musicType);
            }

            _connection.Close();

            return result;
        }
    }
}
