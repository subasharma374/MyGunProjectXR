using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.OpenXR.Input;

public class inter_act : MonoBehaviour
{
    public float amplitude = 0.5f;
    public float durationSec = 0.3f;

    InputAction hapticAction;

    void Start()
    {
        // Create an InputAction for haptic feedback
        hapticAction = new InputAction("Haptic Feedback", binding: "<XRController>/hapticDevice");
        hapticAction.Enable();

        // Optionally, trigger the haptic feedback from an event or condition
        TriggerHapticFeedback();
    }

    public void TriggerHapticFeedback()
    {
        // Check if the action is bound and the device supports haptics
        if (hapticAction.activeControl != null)
        {
            Debug.Log("Sending Haptic Impulse...");
            OpenXRInput.SendHapticImpulse(hapticAction, amplitude, durationSec, hapticAction.activeControl.device);
        }
        else
        {
            Debug.LogError("Haptic device not available or action not active.");
        }
    }

    void OnDestroy()
    {
        hapticAction?.Disable();
    }
}
