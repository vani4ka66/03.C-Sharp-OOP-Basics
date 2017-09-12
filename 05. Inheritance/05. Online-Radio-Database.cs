using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace August2017
{

    public class SongLength
    {
        private long minutes;
        private long seconds;

        public SongLength(long minutes, long seconds)
        {
            this.Minutes = minutes;
            this.Seconds = seconds;
        }

        public long Minutes
        {
            get { return this.minutes; }
            set
            {
                if (value < 0 || value > 14)
                {
                    throw new InvalidSongMinutesException();
                }

                this.minutes = value;
            }
        }

        public long Seconds
        {
            get { return this.seconds; }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new InvalidSongSecondsException();
                }

                this.seconds = value;
            }
        }

        public long FullLength { get; private set; }

        public void CalculateSeconds()
        {
            this.FullLength = this.minutes * 60 + this.seconds;
        }
    }

    public class Song
    {
        private string songName;
        private string artist;
        private SongLength songLenght;


        public Song(string artist, string song, SongLength songLenght)
        {
            this.SongName = song;
            this.Artist = artist;
            this.SongLenht = songLenght;
        }

        public string Artist
        {
            get { return this.artist; }
            set
            {
                if (value.Length < 3 || value.Length > 20 || value == null)
                {
                    throw new InvalidArtistNameException();
                }
                this.artist = value;
            }
        }

        public string SongName
        {
            get { return this.songName; }
            set
            {
                if (value.Length < 3 || value.Length > 20 || value == null)
                {
                    throw new InvalidSongNameException();
                }
                this.songName = value;
            }
        }

        public SongLength SongLenht { get; private set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Song> songsList = new List<Song>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    string singer = input[0];
                    string songName = input[1];
                    string time = input[2];
                    string[] times = time.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                    int minutes = int.Parse(times[0]);
                    int seconds = int.Parse(times[1]);

                    SongLength songLength = new SongLength(minutes, seconds);
                    Song song = new Song(singer, songName, songLength);

                    songsList.Add(song);
                    Console.WriteLine("Song added.");


                }
                catch (InvalidSonsException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            Console.WriteLine("Songs added: {0}", songsList.Count);
            long playListLength = 0;
            foreach (var item in songsList)
            {
                item.SongLenht.CalculateSeconds();
                playListLength += item.SongLenht.FullLength;

            }
            Console.WriteLine("Playlist length: {0}h {1}m {2}s",
               playListLength / 3600,
               (playListLength / 60) % 60,
               playListLength % 60);
        }
    }
    public class InvalidSonsException : Exception
    {
        private new const string Message = "Invalid song.";

        public InvalidSonsException() : base(Message)
        {
        }

        public InvalidSonsException(string message) : base(message)
        {
        }
    }

    internal class InvalidSongSecondsException : Exception
    {
        private new const string Message = "Song seconds should be between 0 and 59.";

        public InvalidSongSecondsException() : base(Message)
        {
        }
        public InvalidSongSecondsException(string message) : base(message)
        {
        }
        public InvalidSongSecondsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
    internal class InvalidSongNameException : Exception
    {
        private new const string Message = "Invalid song.";
        public InvalidSongNameException() : base(Message)
        {
        }
        public InvalidSongNameException(string message) : base(message)
        {
        }
        public InvalidSongNameException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
    internal class InvalidSongMinutesException : Exception
    {
        private new const string Message = "Song minutes should be between 0 and 14.";

        public InvalidSongMinutesException() : base(Message)
        {
        }
        public InvalidSongMinutesException(string message) : base(message)
        {
        }
        public InvalidSongMinutesException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }

    internal class InvalidArtistNameException : Exception
    {
        private new const string Message = "Artist name should be between 3 and 20 symbols.";

        public InvalidArtistNameException() : base(Message)
        {
        }
        public InvalidArtistNameException(string message) : base(message)
        {
        }
        public InvalidArtistNameException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}

