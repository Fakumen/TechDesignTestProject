using UnityEngine;
using UnityEngine.UI;

namespace TechDesignTestProject
{
    public class ButtonActivatorClickableObject : MonoBehaviour, IClickableObject
    {
        [SerializeField]
        private Button _button;

        public void HandleClick()
        {
            _button.interactable = true;
        }
    }
}