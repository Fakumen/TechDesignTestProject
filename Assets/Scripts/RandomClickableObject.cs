using System.Linq;
using UnityEngine;

namespace TechDesignTestProject
{
    public class RandomClickableObject : MonoBehaviour, IClickableObject
    {
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private string[] _animationsOnClick = new string[0];
        [SerializeField]
        private AudioClip[] _audioClipsOnClick = new AudioClip[0];

        private int[] _animationsOnClickIds;

        private void Awake()
        {
            _animationsOnClickIds = _animationsOnClick
                .Select(n => Animator.StringToHash(n))
                .ToArray();
        }

        public void HandleClick()
        {
            if (_animator != null)
                PlayRandomAnimation();
            if (_audioSource != null)
                PlayRandomAudioClip(_audioClipsOnClick);
        }

        private void PlayRandomAudioClip(AudioClip[] clips)
        {
            if (clips.Length== 0) return;
            var id = Random.Range(0, clips.Length);
            _audioSource.clip = clips[id];
            _audioSource.Play();
        }

        private void PlayRandomAnimation()
        {
            if (_animationsOnClickIds.Length == 0) return;
            var id = Random.Range(0, _animationsOnClickIds.Length);
            var animationId = _animationsOnClickIds[id];
            _animator.Play(animationId);
        }
    }
}