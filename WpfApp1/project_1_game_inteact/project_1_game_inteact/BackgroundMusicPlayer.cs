using System;
using System.Windows.Media;

namespace UItest
{
    public class BackgroundMusicPlayer
    {
        private static BackgroundMusicPlayer _instance;
        private MediaPlayer mediaPlayer;

        private BackgroundMusicPlayer()
        {
            mediaPlayer = new MediaPlayer();
            mediaPlayer.Open(new Uri(System.IO.Path.Combine(Environment.CurrentDirectory, "resources", "BackMusic.mp3")));
            mediaPlayer.Volume = 1.0;
            mediaPlayer.MediaEnded += MediaPlayer_MediaEnded;
            mediaPlayer.Play();
        }

        public static BackgroundMusicPlayer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BackgroundMusicPlayer();
                }
                return _instance;
            }
        }

        private void MediaPlayer_MediaEnded(object sender, EventArgs e)
        {
            mediaPlayer.Position = TimeSpan.Zero;
            mediaPlayer.Play();
        }

        public void Play()
        {
            mediaPlayer.Play();
        }

        public void Stop()
        {
            mediaPlayer.Stop();
        }
    }
}
