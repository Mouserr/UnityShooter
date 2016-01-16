using UnityEngine;
using System.Collections;
using Assets.Helpers;

public class BulletsEmiter : MonoBehaviour {

    [SerializeField]
    private Bullet prefab;
    [SerializeField]
    private float speed;

    [SerializeField]
    private ParticleSystem explosionPrefab;

    private Camera camera;

    private GameObjectPull<Bullet> bulletsPull; 
    private GameObjectPull<ParticleSystem> effectsPull; 

	// Use this for initialization
	void Start () {
        bulletsPull = new GameObjectPull<Bullet>(gameObject.AddChild("bulletsPull"), prefab, 30);
        effectsPull = new GameObjectPull<ParticleSystem>(gameObject.AddChild("effectsPull"), explosionPrefab, 30);
        camera = FindObjectOfType<Camera>();
	}
	
	// Update is called once per frame
	void Update () 
    {
          if (Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))
          {
              Vector3 dir = camera.transform.TransformDirection(Vector3.forward);
              Bullet bullet = CreateBullet();
              bullet.transform.localPosition = camera.transform.localPosition + Vector3.forward*camera.nearClipPlane;
              bullet.GetComponent<Rigidbody>().AddForce(dir * speed, ForceMode.Impulse);
          }
	}

    private Bullet CreateBullet()
    {
        Bullet bullet = bulletsPull.GetObject();

        bullet.transform.parent = transform;
        bullet.transform.localScale = prefab.transform.localScale;
        bullet.OnHit += onHit;
        bullet.gameObject.SetActive(true);
        return bullet;
    }

    private void onHit(Vector3 position, Bullet bullet)
    {
        StartCoroutine(effectCoroutine(effectsPull.GetObject(), position));
        bullet.OnHit -= onHit;
        bullet.GetComponent<Rigidbody>().velocity = Vector3.zero;
        bulletsPull.ReleaseObject(bullet);
    }

    private IEnumerator effectCoroutine(ParticleSystem effect, Vector3 position)
    {
        effect.gameObject.SetActive(true);
        effect.transform.parent = transform;
        effect.transform.localScale = Vector3.one;
        effect.transform.localPosition = position;
        effect.Play();
        while (effect.isPlaying)
        {
            yield return null;
        }

        effectsPull.ReleaseObject(effect);
    }
}
