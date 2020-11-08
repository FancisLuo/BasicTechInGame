using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CheckCollisionCircle
{
    public class CircleTarget : MonoBehaviour
    {
        public Vector2 Center;  // 圆中心
        public float Radius;    // 半径

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;

            Gizmos.DrawSphere(Center, Radius);
        }
    }
}
