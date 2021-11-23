using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

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
        ButtonActive();
        pressed.Invoke();
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
        var mats = meshRenderer.materials;
        mats[1] = activeMat;
        meshRenderer.materials = mats;
    }

    public void ButtonInactive()
    {
        var mats = meshRenderer.materials;
        mats[1] = inactiveMat;
        meshRenderer.materials = mats;
    }
}