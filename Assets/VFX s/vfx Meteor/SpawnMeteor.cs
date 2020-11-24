using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeteor : MonoBehaviour
{
    public GameObject vfxMeteorPrefab;
    public Transform startPoint;
    public float startDelta;
    public Transform endPoint;
    public float endDelta;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Spawn();
    }

    void Spawn()
    {
        //var startPosition = startPoint.position;
        //var endPosition = endPoint.position;
        Vector3 startVector = new Vector3(Random.Range(-1 * startDelta, startDelta), startPoint.position.y, Random.Range(-1 * startDelta, startDelta));
        Vector3 endVector = new Vector3(Random.Range(-1 * endDelta, endDelta), endPoint.position.y, Random.Range(-1 * endDelta, endDelta));

        GameObject go_vfxMeteor = Instantiate(vfxMeteorPrefab, startVector, Quaternion.identity) as GameObject;

        RotateTo(go_vfxMeteor, endVector);
    }

    void RotateTo (GameObject go, Vector3 destination)
    {
        var direction = destination - go.transform.position;
        var rotation = Quaternion.LookRotation(direction);
        go.transform.localRotation = Quaternion.Lerp(go.transform.localRotation, rotation, 1f);
    }
}
