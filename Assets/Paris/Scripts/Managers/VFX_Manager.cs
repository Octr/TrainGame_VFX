using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class VFX_Manager : MonoBehaviour
{
    // Public static instance of the AudioManager for other classes to acccess.
    public static VFX_Manager instance;
    //public static List<GameObject> VFX_OBJ = new List<GameObject>();

    // Public Enum References for VFX Files in VFX_Manager.
    public enum VFX
    {
        Fireflies,
        ManaAura,
        PlayerDust,
        BulletTrail,
        TrainSparks,
        Magic,
        LowHealth,
        MAX_VFX,
    };

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        /*if (VFX_OBJ.Count > 0)
        {
            for (int i = 0; i < VFX_OBJ.Count; i++)
            {
                Destroy(GameObject.Find(VFX_OBJ[i]));
            }
        }*/
    }

    /*void OnTriggerEnter()
    {
        VFX_OBJ.Add(this.gameObject.name);
        Destroy(this.gameObject);
    }*/

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            DisplayVFX(VFX.Fireflies, true);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            DisplayVFX(VFX.Fireflies, false);
        }

    }

    public void DisplayVFX(VFX vfx, bool display)
    {
        int x = (int)vfx;
        Debug.Log(x);
        Debug.Log(vfx);
        Debug.Log(display);

        string tag = vfx.ToString();
        Debug.Log(tag);

        GameObject obj = GameObject.FindGameObjectWithTag(tag);
        Debug.Log(obj);

        if (obj == null)
        {
            // DisplayVFX (VFX, DISPLAY) Failed.
            Debug.LogError("DisplayVFX( "+ vfx + ", " + display + " ) Failed");
            return;
        }
            obj.SetActive(display);
    }
}
