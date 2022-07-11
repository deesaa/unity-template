namespace _Main.Scripts.Audio
{
    public interface IAudioService
    {
        public void PlayInstant(string name, int range, float volume = 1f, float pitch = 1f);
        public void PlayLoop(string name, float volume = 1f, float pitch = 1f);

        public void PlayEnable(string name, bool enable, int sourceId, int maxSources, float volume = 1,
            float pitch = 1);
    }
}