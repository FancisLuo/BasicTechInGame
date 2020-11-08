using CheckCollisionRect;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CheckCollisionCircle
{
    public class CheckCircleRect : MonoBehaviour
    {
        [SerializeField] private RectangleTarget rectangleTarget;
        [SerializeField] private CircleTarget circleTarget;
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            var checkResult = CheckCollision();
            Debug.Log($"result = {checkResult}");
        }

        private bool CheckCollision()
        {
            var onX = Mathf.Abs(circleTarget.Center.x - rectangleTarget.RectCenter.x);
            var onY = Mathf.Abs(circleTarget.Center.y - rectangleTarget.RectCenter.y);

            var totalWidth = rectangleTarget.Width * 0.5f + circleTarget.Radius;
            var totalHeight = rectangleTarget.Height * 0.5f + circleTarget.Radius;

            if(onX > totalWidth || onY > totalHeight)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
