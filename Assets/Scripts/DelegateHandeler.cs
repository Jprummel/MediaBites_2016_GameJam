using UnityEngine;
using System.Collections;

public class DelegateHandeler  {

    public delegate void LazerHit(GameObject hit);
    public static event LazerHit OnLazerHit;

    public delegate void LazerLeave(GameObject hit);
    public static event LazerLeave OnlazerLeave;

    public static void LazerHitEvent(GameObject hit)
    {
		if (OnLazerHit != null) 
        	OnLazerHit(hit);
    }
    
    public static void LazerLeaveEvent(GameObject hit)
    {
		if (OnlazerLeave != null) 
        	OnlazerLeave(hit);
    }
	public static void Nullify()
	{
		Debug.Log ("Ik laad een nieuwe scene");
		OnLazerHit = null;
		OnlazerLeave = null;
	}
}