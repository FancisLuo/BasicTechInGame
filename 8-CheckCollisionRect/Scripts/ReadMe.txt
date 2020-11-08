矩形间碰撞检测因矩形的表达方式的不同，算法有所不同
1. 中心+长宽的表示
    public class Rectangle
    {
        public Vector2 Center;
        public float Width;
        public float Height;
    }
    那么可以分别查看在x轴和y轴上是否碰撞，有一个方向上碰撞，则结果为碰撞，比如x轴上
    distanceX <= (rect1.Width + rect2.Width) * 0.5f，则为碰撞

2. 顶点表示法
    public class Rectangle{
        public Vector2 LeftBottom;
        public Vector2 RightUp;
    }
    这样就需要判断各个顶点处，是否存在相交，有一处相交，则检测结果为碰撞。