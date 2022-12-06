using UnityEngine;

namespace CameraBehaviour.Extensions
{
    public static class CameraExtensions
    {
        public static Bounds GetCameraBounds(this Camera camera, Matrix4x4 matrix)
        {
            Vector3[] points = getCameraBoundsPoints(camera);
            for (int i = 0; i < points.Length; i++)
            {
                points[i].z = 0;
            }

            Bounds bounds = GeometryUtility.CalculateBounds(points, matrix);
            bounds.center = new Vector3(bounds.center.x, bounds.center.y, 0);
            return bounds;
        }
        private static Vector3[] getCameraBoundsPoints(Camera camera)
        {
            return new Vector3[]
            {
                camera.ViewportToWorldPoint(new Vector2(0, 0)),
                camera.ViewportToWorldPoint(new Vector2(1, 0)),
                camera.ViewportToWorldPoint(new Vector2(0, 1)),
                camera.ViewportToWorldPoint(new Vector2(1, 1))
            };
        }
    }
}