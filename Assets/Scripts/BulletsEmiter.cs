using UnityEngine;
using System.Collections;

public class BulletsEmiter : MonoBehaviour {

    [SerializeField]
    private GameObject prefab;

    private Camera camera;

	// Use this for initialization
	void Start () {
        camera = FindObjectOfType<Camera>();
	}
	
	// Update is called once per frame
	void Update () 
    {
          if (Input.GetMouseButtonUp(0))
          {
              Ray ray = camera.ScreenPointToRay( Input.mousePosition);
              GameObject bullet = CreateBullet();
              bullet.rigidbody.AddForce(ray.direction * 100, ForceMode.Impulse);
          }
	}

    private GameObject CreateBullet()
    {
        GameObject cube = Instantiate(prefab,
           camera.transform.localPosition,
           Quaternion.identity) as GameObject;

        cube.transform.parent = transform;
        cube.transform.localScale = Vector3.one;
        return cube;
    }
}
