using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public float speed;
    public GameObject impactPrefab;
    public List<GameObject> trails;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.position += transform.forward * (speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        speed = 0;
        ContactPoint contact = collision.contacts[0];
        Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
        Vector3 pos = contact.point;

        if (impactPrefab != null)
        {
            var vfxImpact = Instantiate(impactPrefab, pos, rot) as GameObject;
            Destroy(vfxImpact,5);
        }

        // Tách trail ra 
        if (trails.Count > 0)
        {
            foreach(GameObject trail in trails)
            {
                trail.transform.parent = null;
                var ps = trail.GetComponent<ParticleSystem>();
                if (ps != null)
                {
                    ps.Stop();
                    Destroy(ps.gameObject, ps.main.duration * ps.main.startLifetime.constantMax);
                }
            }
        }

        Destroy(gameObject);
    }
}
