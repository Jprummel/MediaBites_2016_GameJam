﻿ using UnityEngine;
using System.Collections;

public class LineRendererScript : MonoBehaviour {

    private ManageCrystals _manageCrystals;
    LineRenderer lineRenderer;
	[SerializeField]
    bool active, hitSomething, stopedHitSomething;
    int hitCount;

    [SerializeField]
    bool origin = false;
    [SerializeField]
    float range = 3;
    [SerializeField]
    Transform farestRangePoint;

    public RaycastHit2D hit;
    GameObject oldHit = null;

    void Start()
    {
        _manageCrystals = GetComponent<ManageCrystals>();
        lineRenderer = GetComponent<LineRenderer>();
		LineSplitter.OnLazerHit += LazerHit;
		LineSplitter.OnlazerLeave += LazerLeave;

        if (origin) active = true;
    }

    void Update()
    {
        if (active)
        {
            UpdateLine();

            if (hit) {
                if (!hitSomething) {
                    stopedHitSomething = false;
                    hitSomething = true;
                    hitCount++;
                    //exicute once
                    lineRenderer.useWorldSpace = true;
                    lineRenderer.SetPosition(0, transform.position);
                    oldHit = hit.collider.gameObject;
                    
                    if (!CheckIfSelf())
                    {
                        DelegateHandeler.LazerHitEvent(hit.collider.gameObject);
                    }
                }

                DrawLineHit();
                //stuck
            } else {
                if (!stopedHitSomething) {
                    hitSomething = false;
                    stopedHitSomething = true;
                    hitCount--;
                    //exicute once
                    lineRenderer.useWorldSpace = false;
                    lineRenderer.SetPosition(0, Vector3.zero);

                    if (!CheckIfSelf())
                    {
                        if (oldHit)
                        {
                            DelegateHandeler.LazerLeaveEvent(oldHit);
                        }
                    }
                }

                DrawLineFree();
                //loos
            }
        }
    }

    bool CheckIfSelf()
    {
        try {
            if (oldHit.GetComponent<LineRendererScript>().oldHit == gameObject) return true;
            return false;
        } catch { return false; }
    }

    void DrawLineHit()
    {
        lineRenderer.SetPosition(1, hit.point);
    }

    void DrawLineFree()
    {
        Vector3 rangePosition = new Vector3(0f, range, 0f);
        lineRenderer.SetPosition(1, rangePosition);
    }

    void UpdateLine()
    {
        float angle = transform.rotation.eulerAngles.z + 90;

        farestRangePoint.position = new Vector3(
            transform.position.x + range * Mathf.Cos(angle * Mathf.Deg2Rad),
            transform.position.y + range * Mathf.Sin(angle * Mathf.Deg2Rad),
            0f);

        hit = Physics2D.Raycast(transform.position +
        (farestRangePoint.transform.position - transform.position) / 10,
        farestRangePoint.transform.position - transform.position, range);
    }

    void OnDestroy()
    {
		print ("destroy");
		LineSplitter.OnLazerHit -= LazerHit;
		LineSplitter.OnlazerLeave -= LazerLeave;
    }

    void LazerHit(GameObject hit)
    {
		if (hit == gameObject && !origin) {
			active = true;
            _manageCrystals.RemoveCrystal();
		}
    }

    void LazerLeave(GameObject delHit)
    {
        if (delHit == gameObject && !origin && active)
        {
            _manageCrystals.AddCrystal();
            if (hit && active) {
                print(gameObject.name);
				DelegateHandeler.LazerLeaveEvent(oldHit);
            }

            lineRenderer.useWorldSpace = false;
            lineRenderer.SetPosition(1, Vector3.zero);
            lineRenderer.SetPosition(0, Vector3.zero);
            active = false;
        }
    }
}
