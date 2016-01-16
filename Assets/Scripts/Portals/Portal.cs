using UnityEngine;

namespace Assets.Scripts.Portals
{
    public class Portal : MonoBehaviour
    {
        public Portal ExitPortal;

        private void OnCollisionEnter(Collision collision)
        {
            Debug.Log("portal");
            Debug.Log("collision.relativeVelocity " + collision.relativeVelocity);
            Debug.Log("transform.forward " + transform.forward);
            var dot = Vector3.Dot(collision.rigidbody.velocity, transform.forward);
            Debug.Log("Vector3.Dot(collision.relativeVelocity, transform.forward) " + dot);
            if (ExitPortal != null && dot < 0 && Mathf.Abs(dot) > 1)
            {
                collision.transform.position = ExitPortal.transform.position;
                collision.transform.forward =
                    Quaternion.FromToRotation(-transform.forward, ExitPortal.transform.forward)
                    * collision.transform.forward;
                Debug.Break();
            }
        }

    }
}