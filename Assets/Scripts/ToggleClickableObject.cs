using UnityEngine;

namespace TechDesignTestProject
{
    public class ToggleClickableObject : MonoBehaviour, IClickableObject
    {
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private string _toggleAnimatorParameterName;
        [SerializeField]
        private AudioClip[] _audioClipsOnToggleOn = new AudioClip[0];
        [SerializeField]
        private AudioClip[] _audioClipsOnToggleOff = new AudioClip[0];

        private int _toggleAnimatorParameterId;

        private void Awake()
        {
            _toggleAnimatorParameterId = Animator.StringToHash(_toggleAnimatorParameterName);
        }

        public void HandleClick()
        {
            ToggleParameter();
        }

        private void ToggleParameter()
        {
            var prevValue = _animator.GetBool(_toggleAnimatorParameterId);
            var newValue = !prevValue;
            _animator.SetBool(_toggleAnimatorParameterId, newValue);
            if (_audioSource != null)
            {
                if (newValue)
                    PlayRandomAudioClip(_audioClipsOnToggleOn);
                else
                    PlayRandomAudioClip(_audioClipsOnToggleOff);
            }
        }

        private void PlayRandomAudioClip(AudioClip[] clips)
        {
            if (clips.Length == 0) return;
            var id = Random.Range(0, clips.Length);
            _audioSource.clip = clips[id];
            _audioSource.Play();
        }
    }
}
