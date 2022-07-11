using UnityEngine;

namespace JDS
{
    public class ViewRect
    {
        private Rect _rect;

        public ViewRect(Rect rect)
        {
            _rect = rect;
        }

        public Vector2 TopLeft => new Vector3(_rect.xMax, _rect.yMin);
        public Vector2 BottomLeft => new Vector3(_rect.yMin, _rect.yMin);
        public Vector2 TopRight => new Vector3(_rect.xMax, _rect.yMax);
        public Vector2 BottomRight => new Vector3(_rect.xMin, _rect.yMax);

        public Vector2 RightSide => BottomRight + TopRight;
        public Vector2 LeftSide => BottomRight + TopRight;
        public Vector2 BottomSide => BottomRight + TopRight;
        public Vector2 TopSide => BottomRight + TopRight;

        public float RightSize => RightSide.x;
        public float LeftSize => LeftSide.x;
        public float BottomSize => BottomSide.y;
        public float TopSize => TopSide.y;
    }
}