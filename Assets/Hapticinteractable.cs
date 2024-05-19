using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticInteractable : MonoBehaviour
{
    [Range(0, 1)]
    public float intensity;
    public float duration;

    private XRBaseInteractable interactable;

    void Start()
    {
        
    }

    private void TriggerHaptic(ActivateEventArgs args)
    {
        if (args.interactorObject is XRBaseControllerInteractor controllerInteractor)
        {
            TriggerHaptic(controllerInteractor.xrController);
        }
    }

    public void TriggerHaptic(XRBaseController controller)
    {
        if (controller != null && intensity > 0)
        {
            controller.SendHapticImpulse(intensity, duration);
        }
    }
}
