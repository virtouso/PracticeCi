using UnityEngine;

namespace Help.Script.Help.Editor
{
    public class CameraGizmo : MonoBehaviour
    {
        Camera m_camera;

        void OnDrawGizmos()
        {
            if (m_camera == null)
            {
                m_camera = gameObject.GetComponent<Camera>();
            }

            Color tempColor = Gizmos.color;
            Matrix4x4 tempMat = Gizmos.matrix;
            if (this.m_camera.orthographic)
            {
                Camera c = m_camera;
                var size = c.orthographicSize;
                Gizmos.DrawWireCube(Vector3.forward * (c.nearClipPlane + (c.farClipPlane-c.nearClipPlane)/2)
                    , new Vector3(size * 2.0f, size * 2.0f * c.aspect, c.farClipPlane-c.nearClipPlane));
            }
            else
            {
                Camera c = m_camera;
                Gizmos.matrix = Matrix4x4.TRS(this.transform.position, this.transform.rotation, Vector3.one);
                Gizmos.DrawFrustum(Vector3.zero, c.fieldOfView, c.farClipPlane, c.nearClipPlane, c.aspect);
            }
            Gizmos.color = tempColor;
            Gizmos.matrix = tempMat;
        }
    }
}
