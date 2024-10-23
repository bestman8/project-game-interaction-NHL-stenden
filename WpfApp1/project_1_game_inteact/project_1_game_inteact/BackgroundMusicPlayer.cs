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
            mediaPlayer.Volume = 0.1;  // Standaard volume is 10%
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

        // Methode om het volume in te stellen
        public void SetVolume(double volume)
        {
            mediaPlayer.Volume = volume;
        }

        // Methode om het huidige volume op te halen
        public double GetVolume()
        {
            return mediaPlayer.Volume;
        }
    }
}
