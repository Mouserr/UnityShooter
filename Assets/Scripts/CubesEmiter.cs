using UnityEngine;
using System.Collections;

public class CubesEmiter : MonoBehaviour {

    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private float startY;

    [SerializeField]
    private float minX;
    [SerializeField]
    private float maxX;
    [SerializeField]
    private float minZ;
    [SerializeField]
    private float maxZ;


    [SerializeField]
    private float emitionDelay;

    private float delay;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        delay += Time.deltaTime;
        if (delay >= emitionDelay)
        {
            delay = 0;
            GameObject cube = CreateCube();
        }
	}

    private GameObject CreateCube()
    {
        GameObject cube = Instantiate(prefab,
           new Vector3(Random.RandomRange(minX, maxX), startY, Random.RandomRange(minZ, maxZ)),
           Quaternion.identity) as GameObject;

        cube.transform.parent = transform;
        cube.transform.localScale = Vector3.one;
        return cube;
    }
}
