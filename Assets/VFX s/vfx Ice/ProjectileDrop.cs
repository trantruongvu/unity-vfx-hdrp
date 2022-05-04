using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDrop : MonoBehaviour
{
    public GameObject ice;
    public GameObject impactPrefab;
    public List<GameObject> trails;

    Rigidbody rb;
    Sequence seq;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();

        seq = DOTween.Sequence();
        seq.Append(transform.DORotate(new Vector3(0, 480, 0), 2.5f, RotateMode.FastBeyond360));
        seq.Join(ice.transform.DOScale(new Vector3(1, 1, 1), 2.5f).From(Vector3.zero));
        seq.OnComplete(() =>
        {
            rb.useGravity = true;
        });


        #region OnComplete
        //seq.Append(transform.DOMoveY(0f, 0.5f).SetEase(Ease.OutBack));
        //seq.OnComplete(() =>
        //{
        //    if (impactPrefab != null)
        //    {
        //        GameObject vfxImpact = Instantiate(impactPrefab);
        //        vfxImpact.transform.position = transform.position;
        //        Destroy(vfxImpact, 5);
        //    }

        //    // Tách trail ra 
        //    if (trails.Count > 0)
        //    {
        //        foreach (GameObject trail in trails)
        //        {
        //            trail.transform.parent = null;
        //            var ps = trail.GetComponent<ParticleSystem>();
        //            if (ps != null)
        //            {
        //                ps.Stop();
        //                Destroy(ps.gameObject, ps.main.duration * ps.main.startLifetime.constantMax);
        //            }
        //        }
        //    }

        //    Destroy(gameObject);
        //});
        #endregion
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (seq.IsPlaying())
            seq.Kill();

        if (impactPrefab != null)
        {
            GameObject vfxImpact = Instantiate(impactPrefab);
            vfxImpact.transform.position = transform.position;
            Destroy(vfxImpact, 5);
        }

        // Tách trail ra 
        if (trails.Count > 0)
        {
            foreach (GameObject trail in trails)
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