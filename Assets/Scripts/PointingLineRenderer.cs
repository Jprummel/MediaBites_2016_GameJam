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
    public bool active = true;
    [SerializeField]
    private bool origin = false;
    private GameObject tempHit;
    private RaycastHit2D hit;

    bool canceled = false;

    void Start () {

        DelegateHandeler.OnLazerHit += Activate;
        DelegateHandeler.OnlazerLeave += Deactivate;
        lineRenderer = GetComponent<LineRenderer>();
        StartCoroutine(LacerDoesntHit());
    }

    void Update () {

        if (active)
        {
            UpdateLaser();
            canceled = false;
        }
        else
        {
            if (!canceled)
            {
                lineRenderer.useWorldSpace = false;
                lineRenderer.SetPosition(1, Vector3.zero);
                lineRenderer.SetPosition(0, Vector3.zero);
                canceled = true;
            }
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
                DelegateHandeler.LazerLeaveEvent(tempHit);
                transform.Rotate(0f, 0f, 10f);
        }
    }

    void UpdateLaser()
    {

        float angle = transform.rotation.eulerAngles.z + 90;
        x = transform.position.x + range * Mathf.Cos(angle * Mathf.Deg2Rad);
        y = transform.position.y + range * Mathf.Sin(angle * Mathf.Deg2Rad);
        farestRangePoint.position = new Vector3(x, y, 0f);

        hit = Physics2D.Raycast(transform.position + 
            (farestRangePoint.transform.position - transform.position)/10, 
            farestRangePoint.transform.position - transform.position, range);
    }
    IEnumerator LacerDoesHit()
    {
        Debug.Log("hitted " + hit.collider.name);
        tempHit = hit.collider.gameObject;
        lineRenderer.useWorldSpace = true;
        lineRenderer.SetPosition(0, transform.position);

        while (hit.collider != null)
        {
            lineRenderer.SetPosition(1, tempHit.transform.position);
            yield return new WaitForFixedUpdate();
        }
            DelegateHandeler.LazerLeaveEvent(tempHit);
            StartCoroutine(LacerDoesntHit());
    }
    IEnumerator LacerDoesntHit()
    {
        lineRenderer.useWorldSpace = false;
        lineRenderer.SetPosition(0, Vector3.zero);
        while (hit.collider == null)
        {
            rangePosition = new Vector3(0f, range, 0f);
            lineRenderer.SetPosition(1, rangePosition);
            yield return new WaitForFixedUpdate();
        }
            DelegateHandeler.LazerHitEvent(tempHit);
            StartCoroutine(LacerDoesHit());

    }
}
