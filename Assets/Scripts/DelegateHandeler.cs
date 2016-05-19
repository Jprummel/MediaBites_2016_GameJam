using UnityEngine;
using System.Collections;

public class DelegateHandeler : MonoBehaviour {

    public delegate void LazerHit(GameObject hit);
    public static event LazerHit OnLazerHit;

    public delegate void LazerLeave(GameObject hit);
    public static event LazerHit OnlazerLeave;

    public static void LazerHitEvent(GameObject hit)
    {
        OnLazerHit(hit);
    }

    public static void LazerLeaveEvent(GameObject hit)
    {
        OnlazerLeave(hit);
    }
}
