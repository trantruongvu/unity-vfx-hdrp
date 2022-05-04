using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIce : MonoBehaviour
{
    public GameObject prefabIce;

    void Start() { }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SpawnRandomIce();
    }

    void SpawnRandomIce()
    {
        float x = Random.Range(-5, 5);
        float z = Random.Range(-5, 5);
        GameObject newIce = Instantiate(prefabIce, transform);
        newIce.transform.position = new Vector3(0, 10, 0);
    }
}
