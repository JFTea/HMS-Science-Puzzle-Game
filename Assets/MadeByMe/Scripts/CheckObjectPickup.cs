using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CheckObjectPickup : MonoBehaviour
{
    [SerializeField]
    private GameObject pickup;

    public UnityEvent Activate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pickup.GetComponent<PickUpObject>().state == PickUpObject.PickupType.pickUP && pickup.activeInHierarchy)
        {
            Activate.Invoke();
        }
    }
}
