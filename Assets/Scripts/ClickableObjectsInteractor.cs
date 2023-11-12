using System.Collections.Generic;
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
                var clickableObjects = new List<IClickableObject>();
                var cameraRay = _playerCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(cameraRay, out var hitInfo))
                {
                    clickableObjects.AddRange(hitInfo.collider.GetComponents<IClickableObject>());
                }
                var hitInfo2d = Physics2D.GetRayIntersection(cameraRay);
                if (hitInfo2d.collider)
                {
                    clickableObjects.AddRange(hitInfo2d.collider.GetComponents<IClickableObject>());
                }
                foreach (var clickable in clickableObjects)
                {
                    clickable.HandleClick();
                }
            }
        }
    }
}