using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CheckCollisionRect
{
    public class CheckCollisionByRectangle : MonoBehaviour
    {
        [SerializeField] private RectangleTarget rectFirst;
        [SerializeField] private RectangleTarget rectSecond;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            var checkResult = CheckCollision();
            Debug.Log($"check result = {checkResult}");
        }

        private bool CheckCollision()
        {
            var onX = Mathf.Abs(rectFirst.RectCenter.x - rectSecond.RectCenter.x);
            var onY = Mathf.Abs(rectFirst.RectCenter.y - rectSecond.RectCenter.y);
            var totalWidth = (rectFirst.Width + rectSecond.Width) * 0.5f;
            var totalHeight = (rectFirst.Height + rectSecond.Height) * 0.5f;
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
