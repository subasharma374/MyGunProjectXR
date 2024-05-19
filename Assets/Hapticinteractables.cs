using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticInteractables : MonoBehaviour
{
    [Range(0, 1)]
    public float intensity;
    public float duration;

    [Header("XR Settings")]
    [SerializeField] private XRBaseController rightController;
    [SerializeField] private XRBaseController leftController;

    private XRBaseInteractable interactable;

    void Start()
    {
        interactable = GetComponent<XRBaseInteractable>();
        if (interactable != null)
        {
            // Register the event listener for activation
            interactable.activated.AddListener(OnActivated);
        }
    }

    private void OnDestroy()
    {
        if (interactable != null)
        {
            interactable.activated.RemoveListener(OnActivated);
        }
    }

    private void OnActivated(ActivateEventArgs args)
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

            print("yaaaaaaaaaaaay");    
            controller.SendHapticImpulse(intensity, duration);
                
            
            
        }
    }
}
