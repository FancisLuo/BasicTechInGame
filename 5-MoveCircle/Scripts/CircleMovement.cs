using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MoveCircle
{
    public class CircleMovement : MonoBehaviour
    {
        [SerializeField, Tooltip("中心位置")] private Vector2 center;
        [SerializeField, Tooltip("半径")] private float rot;

        private Transform theTarget;
        private float xPos, yPos;

        private float fAngle;

        // Start is called before the first frame update
        void Start()
        {
            theTarget = transform;
            theTarget.position = new Vector3(center.x, 0, 0);
        }

        // Update is called once per frame
        void Update()
        {
            MoveTarget();
        }

        private void MoveTarget()
        {
            xPos = rot * Mathf.Cos(fAngle) + center.x;
            yPos = rot * Mathf.Sin(fAngle) + center.y;
            theTarget.position = new Vector3(xPos, yPos, 0);
            fAngle += 2.0f * Mathf.PI / 120f;
        }
    }
}
