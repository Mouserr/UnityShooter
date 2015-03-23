using UnityEngine;
using System.Collections;

public class Vulnerable : MonoBehaviour
{
    public delegate void HitDelegate(Vulnerable vulnerable);

    public HitDelegate OnHit = (v) => {};


    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("bullet"))
        {
            Destroy(gameObject);
        }
    }
}
