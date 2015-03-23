using System;
using UnityEngine;
using System.Collections;
using Assets.Helpers;
using Random = UnityEngine.Random;

public class CubesEmiter : MonoBehaviour {

    [SerializeField]
    private Vulnerable prefab;

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

    private GameObjectPull<Vulnerable> cubesPull; 


	// Use this for initialization
	void Start ()
	{
        cubesPull = new GameObjectPull<Vulnerable>(gameObject.AddChild("CubesPull"), prefab, 50, 10);
	}
	
	// Update is called once per frame
	void Update () {

        delay += Time.deltaTime;
        if (delay >= emitionDelay)
        {
            delay = 0;
            Vulnerable cube = CreateCube();
        }
	}

    private Vulnerable CreateCube()
    {
        Vulnerable cube = cubesPull.GetObject();

        cube.transform.parent = transform;
        cube.transform.localScale = Vector3.one;
        cube.transform.localPosition = new Vector3(Random.Range(minX, maxX), startY,
            Random.Range(minZ, maxZ));
        cube.OnHit += onHit;

        cube.gameObject.SetActive(true);
        return cube;
    }

    private void onHit(Vulnerable vulnerable)
    {
        cubesPull.ReleaseObject(vulnerable);
        if (vulnerable.OnHit != null)
            vulnerable.OnHit -= onHit;  
    }
}
