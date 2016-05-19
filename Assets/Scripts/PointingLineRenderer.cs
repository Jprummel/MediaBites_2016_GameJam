using UnityEngine;
using System.Collections;

public class PointingLineRenderer : MonoBehaviour {

    [SerializeField]
    private float range = 3f;
    private LineRenderer lineRenderer;
    private Vector3 rangePosition;
    [SerializeField]
    private Transform farestRangePoint;
    private float x;
    private float y;

    [SerializeField]
    private bool active = true;
    [SerializeField]
    private bool origin = false;

    private bool hasHittedAnother = false;
    private GameObject tempHit;
    void Start () {

        DelegateHandeler.OnLazerHit += Activate;
        DelegateHandeler.OnlazerLeave += Deactivate;
        lineRenderer = GetComponent<LineRenderer>();
        if(origin)
        {
            DelegateHandeler.LazerHitEvent(this.gameObject);
        }

    }

    void Update () {

        if (active)
        {
            UpdateLaser();
        }
        else
        {
            Debug.Log("sup");
            lineRenderer.useWorldSpace = false;
            lineRenderer.SetPosition(1, Vector3.zero);
            lineRenderer.SetPosition(0, Vector3.zero);
        }
    }

    void Activate(GameObject hit)
    {
        if (hit == this.gameObject)
        {
            active = true;
        }
    }

    void Deactivate(GameObject hit)
    {
        if(hit == this.gameObject && !origin)
        {
            active = false;
            if(tempHit!= null)
            {
                DelegateHandeler.LazerLeaveEvent(tempHit);
            }
        }
    }

    void UpdateLaser()
    {

        float angle = transform.rotation.eulerAngles.z + 90;
        x = transform.position.x + range * Mathf.Cos(angle * Mathf.Deg2Rad);
        y = transform.position.y + range * Mathf.Sin(angle * Mathf.Deg2Rad);
        farestRangePoint.position = new Vector3(x, y, 0f);


        RaycastHit2D hit = Physics2D.Raycast(transform.position + (farestRangePoint.transform.position - transform.position)/10, farestRangePoint.transform.position - transform.position, range);
        if (hit.collider != null)
        {
            tempHit = hit.collider.gameObject;
            lineRenderer.useWorldSpace = true;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, tempHit.transform.position);
            Debug.Log("hitted "+ hit.collider.name);
            DelegateHandeler.LazerHitEvent(tempHit);
        }
        else
        {
            rangePosition = new Vector3(0f, range, 0f);
            lineRenderer.useWorldSpace = false;
            lineRenderer.SetPosition(0, Vector3.zero);
            lineRenderer.SetPosition(1, rangePosition);
            DelegateHandeler.LazerLeaveEvent(tempHit);
        }
    }
}
