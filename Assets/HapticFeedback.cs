using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticFeedback : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    XRBaseController rightController;
    [SerializeField]
    XRBaseController leftController;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SendHaptics();
        
    }

    public void SendHaptics()
    {
        if (rightController != null)
        {
            rightController.SendHapticImpulse(1.0f, 0.3f);
        }

    }
}
