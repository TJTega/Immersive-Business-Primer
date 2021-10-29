using UnityEngine;
using UnityEngine.Events;

public class TouchPress: MonoBehaviour
{

    public UnityEvent pressed;
    public string targetTag;

    [ContextMenu("Press")]
    void ButtonPress()
    {
        pressed.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            ButtonPress();
        }
    }
}