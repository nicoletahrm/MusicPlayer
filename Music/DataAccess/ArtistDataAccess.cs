using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels;
using System.Data.Common;
using BusinessLogic.Abstract;

namespace DataAccess
{
    public class ArtistDataAccess : IArtistDataAccess
    {
        private readonly NpgsqlConnection _connection;
        public ArtistDataAccess()
        {
            _connection = new("Server=localhost; Database=music_player; Port=5432; User id=postgres; Password=2001");
        }

        public void Create(Artist artist)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText = "INSERT INTO artist (last_name, first_name, sex, birth_date, nationality) VALUES (@last_name, @first_name, @sex, @birth_date, @nationality)";

            command.Parameters.AddWithValue("last_name", artist.LastName);
            command.Parameters.AddWithValue("first_name", artist.FirstName);
            command.Parameters.AddWithValue("sex", artist.Sex);
            command.Parameters.AddWithValue("birth_date", artist.Date);
            command.Parameters.AddWithValue("nationality", artist.Nationality);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public List<Artist> Read()
        {
            List<Artist> result = new List<Artist>();

            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText =
                                    "SELECT artist_id, last_name, first_name, birth_date, sex, nationality FROM artist " +
                                    "ORDER BY last_name";

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Artist artist = new Artist();

                artist.ArtistId = reader.GetInt32(0);
                artist.LastName = reader.GetString(1);
                artist.FirstName = reader.GetString(2);
                artist.Date = reader.GetDateTime(3);
                artist.Sex = reader.GetString(4);
                artist.Nationality = reader.GetString(5);
                artist.Name = reader.GetString(1) + " " + reader.GetString(2);

                result.Add(artist);
            }

            _connection.Close();

            return result;
        }

        public Artist Read(int artist_id)
        {
            Artist artist = new Artist();

            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText = 
                                    "SELECT artist_id, last_name, first_name, birth_date, sex, nationality FROM artist " +
                                    "WHERE artist_id = @artist_id";

            command.Parameters.AddWithValue("artist_id", artist_id);

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                artist.ArtistId = reader.GetInt32(0);
                artist.LastName = reader.GetString(1);
                artist.FirstName = reader.GetString(2);
                artist.Date = reader.GetDateTime(3);
                artist.Sex = reader.GetString(4);
                artist.Nationality = reader.GetString(5);
            }

            _connection.Close();

            return artist;
        }

        public void Update(Artist artist)
        {
            _connection.Open();
            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText = 
                                    "UPDATE artist " +
                                    "SET last_name = @last_name, first_name = @first_name, birth_date = @birth_date, sex = @sex, nationality = @nationality " +
                                    "WHERE artist_id = @artist_id";

            command.Parameters.AddWithValue("artist_id", artist.ArtistId);
            command.Parameters.AddWithValue("last_name", artist.LastName);
            command.Parameters.AddWithValue("first_name", artist.FirstName);
            command.Parameters.AddWithValue("birth_date", artist.Date);
            command.Parameters.AddWithValue("sex", artist.Sex);
            command.Parameters.AddWithValue("nationality", artist.Nationality);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public void Delete(int artist_id)
        {
            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();

            command.CommandText =   "DELETE FROM artist_song " +
                                    "WHERE artist_id = @artist_id; " +

                                    "DELETE FROM album " +
                                    "WHERE artist_id = @artist_id; " +

                                    "DELETE FROM playlist_artist " +
                                    "WHERE artist_id = @artist_id; " +

                                    "DELETE FROM artist " +
                                    "WHERE artist_id = @artist_id";

            command.Parameters.AddWithValue("artist_id", artist_id);

            command.ExecuteNonQuery();

            _connection.Close();
        }

        public List<Artist> TopArtists()
        {
            List<Artist> result = new List<Artist>();

            _connection.Open();

            NpgsqlCommand command = _connection.CreateCommand();
            command.CommandText =
                                    "SELECT artist.first_name, artist.last_name, SUM(song.likes) FROM artist_song " +
                                    "JOIN artist ON artist.artist_id = artist_song.artist_id " +
                                    "JOIN song ON song.song_id = artist_song.song_id " +
                                    "GROUP BY artist.last_name, artist.first_name " +
                                    "ORDER BY SUM(song.likes) DESC " +
                                    "LIMIT 5;";

            DbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Artist artist = new Artist();

                artist.Name = reader.GetString(1) + " " + reader.GetString(0);

                result.Add(artist);
            }

            _connection.Close();

            return result;
        }
    }
}
