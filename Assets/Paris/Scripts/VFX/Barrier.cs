using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    [SerializeField] private Dissolve dissolve;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Barrier Collided With: " + other.name);
        if(other.tag == "Train")
        {
            dissolve.Active = true;
            AudioManager.Instance.Play(Audio.SFX_DISSOLVE);
            Debug.Log("Dissolve Activated");
        }       
    }
}
