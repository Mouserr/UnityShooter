using UnityEngine;
using System.Collections;

public class Vulnerable : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("bullet"))
        {
            Destroy(gameObject);
        }
    }
}
