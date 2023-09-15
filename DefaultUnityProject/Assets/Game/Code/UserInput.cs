using System;
using UnityEngine;

namespace Game.Code
{
    public class UserInput : MonoBehaviour
    {
        public Action<Vector3> onClick;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var clickedPosition = GetClickedWorldPosition(out var isGround);
                if (isGround)
                {
                    onClick?.Invoke(clickedPosition);
                }
            }
        }

        private Vector3 GetClickedWorldPosition(out bool isGround)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out RaycastHit hit))
            {
                isGround = true;
                return hit.point;
            }
            isGround = false;
            return Vector3.zero;
        }
    }
}