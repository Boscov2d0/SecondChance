using System;

namespace SecondChanse.Menu.Tools
{
    [Serializable]
    public struct SettingsData
    {
        public string Language;
        public int WidthScreen;
        public int HeightScreen;
        public int RefreshRate;
        public bool Fullscreen;
        public float SoundsVolume;
        public float MusicVolume;
    }
}