using UnityEngine;

namespace TechDesignTestProject
{
    public class ClickableObjectsInteractor : MonoBehaviour
    {
        [SerializeField]
        private Camera _playerCamera;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Mouse click");
                var cameraRay = _playerCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(cameraRay, out var hitInfo))
                {
                    Debug.Log("Raycast hit");
                    if (hitInfo.collider.TryGetComponent<IClickableObject>(out var clickable))
                    {
                        Debug.Log("Object click");
                        clickable.HandleClick();
                    }
                }
            }
        }
    }
}