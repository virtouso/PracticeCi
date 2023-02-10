using UnityEngine;

namespace Help.Script.Help.Editor
{
    public class BasicGameObjectGizmo : MonoBehaviour
    {
        private void OnDrawGizmos()
        {
            Gizmos.DrawIcon(transform.position,gameObject.name,true);
        }
    }
}
