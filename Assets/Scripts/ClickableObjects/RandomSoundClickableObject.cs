using UnityEngine;

namespace TechDesignTestProject
{
    public class RandomSoundClickableObject : MonoBehaviour, IClickableObject
    {
        [SerializeField]
        private AudioSource _audioSource;
        [SerializeField]
        private AudioClip[] _audioClipsOnClick = new AudioClip[0];

        public void HandleClick()
        {
            PlayRandomAudioClip(_audioClipsOnClick);
        }

        public void PlayRandomAudioClip(AudioClip[] clips)
        {
            if (clips.Length == 0) return;
            var id = Random.Range(0, clips.Length);
            _audioSource.clip = clips[id];
            _audioSource.Play();
        }
    }
}
