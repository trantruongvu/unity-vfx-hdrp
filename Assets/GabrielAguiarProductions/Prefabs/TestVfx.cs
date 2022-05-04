using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestVfx : MonoBehaviour
{
    public GameObject[] VFXs;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            TurnOnVfx(0);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            TurnOnVfx(1);
        if (Input.GetKeyDown(KeyCode.Alpha3))
            TurnOnVfx(2);
        if (Input.GetKeyDown(KeyCode.Alpha4))
            TurnOnVfx(3);
        if (Input.GetKeyDown(KeyCode.Alpha5))
            TurnOnVfx(4);
        if (Input.GetKeyDown(KeyCode.Alpha6))
            TurnOnVfx(5);
        if (Input.GetKeyDown(KeyCode.Alpha7))
            TurnOnVfx(6);
        if (Input.GetKeyDown(KeyCode.Alpha8))
            TurnOnVfx(7);
    }

    private void TurnOnVfx(int index)
    {
        foreach (GameObject vfx in VFXs)
            vfx.SetActive(false);
        VFXs[index].SetActive(true);
    }
}
