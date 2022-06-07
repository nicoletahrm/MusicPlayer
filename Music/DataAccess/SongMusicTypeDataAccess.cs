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
    public class SongMusicTypeDataAccess : ISongMusicTypeDataAccess
    {
        private readonly NpgsqlConnection _connection;

        public SongMusicTypeDataAccess()
        {
            _connection = new("Server=localhost; Database=music_player; Port=5432; User id=postgres; Password=2001");
        }

        public void Create(SongMusicType songMusicType)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText = "INSERT INTO song_music_type (song_id, music_type_id) VALUES (@song_id, @music_type_id)";

            command.Parameters.AddWithValue("song_id", songMusicType.SongId);
            command.Parameters.AddWithValue("music_type_id", songMusicType.MusicTypeId);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public List<SongMusicType> Read()
        {
            List<SongMusicType> result = new List<SongMusicType>();

            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText =
                                    "SELECT song_music_type_id, song.song_id, music_type.music_type_id, song.title, music_type.genre FROM song_music_type " +
                                    "JOIN song ON song.song_id = song_music_type.song_id " +
                                    "JOIN music_type ON music_type.music_type_id = song_music_type.music_type_id";

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                SongMusicType songMusicType = new SongMusicType();

                songMusicType.SongMusicTypeId = reader.GetInt32(0);
                songMusicType.SongId = reader.GetInt32(1);
                songMusicType.MusicTypeId = reader.GetInt32(2);
                songMusicType.SongName = reader.GetString(3);
                songMusicType.MusicTypeName = reader.GetString(4);

                result.Add(songMusicType);
            }

            _connection.Close();

            return result;
        }

        public SongMusicType Read(int song_music_type_id)
        {
            SongMusicType songMusicType = new SongMusicType();

            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText =
                                    "SELECT song_music_type_id, song_id, music_Type_id FROM song_music_type " +
                                    "WHERE song_music_type_id = @song_music_type_id";

            command.Parameters.AddWithValue("song_music_type_id", song_music_type_id);

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                songMusicType.SongMusicTypeId = reader.GetInt32(0);
                songMusicType.SongId = reader.GetInt32(1);
                songMusicType.MusicTypeId = reader.GetInt32(2);
            }

            _connection.Close();

            return songMusicType;
        }

        public void Update(SongMusicType songMusicType)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "UPDATE song_music_type " +
                                  "SET song_id = @song_id, music_type_id = @music_type_id " +
                                  "WHERE song_music_type_id = @song_music_type_id";

            command.Parameters.AddWithValue("song_music_type_id", songMusicType.SongMusicTypeId);
            command.Parameters.AddWithValue("song_id", songMusicType.SongId);
            command.Parameters.AddWithValue("music_type_id", songMusicType.MusicTypeId);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public void Delete(int song_music_type_id)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = "DELETE FROM song_music_type " +
                                    "WHERE song_music_type_id = @song_music_type_id";

            command.Parameters.AddWithValue("song_music_type_id", song_music_type_id);

            command.ExecuteNonQuery();

            _connection.Close();
        }
    }
}
