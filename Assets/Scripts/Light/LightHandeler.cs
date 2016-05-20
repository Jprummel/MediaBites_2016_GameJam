using UnityEngine;

public class LightHandeler : MonoBehaviour {
    [SerializeField]
    bool origin;

    Light light;
    int activeLazers, rad;
    [SerializeField]
    int lightGrothAmound = 20;
    [SerializeField]
    int count = 0;
	void Awake () {
        GameObject lightobj = Instantiate(new GameObject(), new Vector3(transform.position.x, transform.position.y, -5), new Quaternion()) as GameObject;
        lightobj.AddComponent<Light>();
        light = lightobj.GetComponent<Light>();
        light.intensity = 1.5f;
        light.type = LightType.Spot;
        light.transform.parent = transform;
        light.spotAngle = 200;
		light.range = 30;
		light.enabled = false;


        if (!origin)
        {
			LineSplitter.OnlazerLeave += LazerLeave;
        }
		LineSplitter.OnLazerHit += LazerHit;
        if (origin) LazerHit(gameObject);
	}

    void OnDestroy()
    {
        DelegateHandeler.OnLazerHit -= LazerHit;
        DelegateHandeler.OnlazerLeave -= LazerLeave;
    }

    void LazerHit(GameObject hit)
    {
        if (hit == gameObject) {
            //if (activeLazers <= 1) ToggleLight(true);
            //activeLazers++;
            //Rad += lightGrothAmound;

            ToggleLight(true);
        }
    }

    void LazerLeave(GameObject hit)
    {
        if (!origin && hit == gameObject) {
            ToggleLight(false);
            /*
        if (activeLazers > 1) {
            
            activeLazers--;
            //Rad -= lightGrothAmound;
        } else {
            ToggleLight(false);
            activeLazers = 0;
            //Rad = 0;
        }
        */
        }
    }

    private int Rad
    {
        get { return rad; }
        set { rad = value;
            light.spotAngle = rad;
        }
    }

    public void ToggleLight(bool toggle)
    {
        count++;
        light.enabled = toggle;
    }
}
