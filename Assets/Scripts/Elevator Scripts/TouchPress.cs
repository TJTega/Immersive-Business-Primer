using UnityEngine;
using UnityEngine.Events;

public class TouchPress : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public Material activeMat;
    public Material inactiveMat;

    public UnityEvent pressed;
    public string targetTag;

    [ContextMenu("Press")]
    void ButtonPress()
    {
        pressed.Invoke();
        ButtonActive();
    }

    protected void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            ButtonPress();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            ButtonInactive();
        }
    }

    public void ButtonActive()
    {
        meshRenderer.materials[1] = activeMat;
    }

    public void ButtonInactive()
    {
        meshRenderer.materials[1] = inactiveMat;
    }

}