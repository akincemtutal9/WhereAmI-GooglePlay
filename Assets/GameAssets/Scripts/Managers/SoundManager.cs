using UnityEngine;

namespace GameAssets.Scripts.Managers
{
    public class SoundManager : MonoBehaviour
    {
        public static SoundManager instance;

        public AudioSource soundEffectSource;
        public AudioSource musicSource;

        private void Awake()
        {
            // Ensure only one instance of the SoundManager exists
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }

            // Make the SoundManager persist across scenes
            DontDestroyOnLoad(gameObject);
        }
        
        public void PlayMusicInLoop(AudioClip clip)
        {
            if (clip != null)
            {
                musicSource.clip = clip;
                musicSource.loop = true;
                musicSource.Play();
            }
            else
            {
                Debug.LogWarning("The provided AudioClip for music is null.");
            }
        }

        public void StopMusicInLoop()
        {
            musicSource.clip = null;
            musicSource.loop = false;
            musicSource.Stop();
        }
        public void PlaySoundEffect(AudioClip clip)
        {
            soundEffectSource.PlayOneShot(clip);
        }

        public void StopSfx()
        {
            soundEffectSource.volume = 0;
        }
        public void StartSfx()
        {
            soundEffectSource.volume = 1;
        }
        public void StartMusic()
        {
            musicSource.volume = 1;
           
        }
        public void StopMusic()
        {
            musicSource.volume = 0;
        }
    }
}