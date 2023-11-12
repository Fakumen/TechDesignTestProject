using System.Linq;
using UnityEngine;

namespace TechDesignTestProject
{
    public class RandomAnimationClickableObject : MonoBehaviour, IClickableObject
    {
        [SerializeField]
        private Animator _animator;
        [SerializeField]
        private string[] _animationsOnClick = new string[0];

        private int[] _animationsOnClickIds;

        private void Awake()
        {
            _animationsOnClickIds = _animationsOnClick
                .Select(n => Animator.StringToHash(n))
                .ToArray();
        }

        public void HandleClick()
        {
            PlayRandomAnimation();
        }

        public void PlayRandomAnimation()
        {
            if (_animationsOnClickIds.Length == 0) return;
            var id = Random.Range(0, _animationsOnClickIds.Length);
            var animationId = _animationsOnClickIds[id];
            _animator.Play(animationId);
        }
    }
}