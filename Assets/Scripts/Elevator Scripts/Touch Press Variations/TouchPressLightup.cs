using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPressLightup : TouchPress
{
    public MeshRenderer meshRenderer;
    public Material activeMat;
    public Material inactiveMat;

    protected override void OnTriggerEnter(Collider other)
    {
        base.OnTriggerEnter(other);
        if (other.CompareTag(base.targetTag))
        {
            ButtonActive();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(targetTag))
        {
            ButtonInactive();
        }
    }

    [ContextMenu("Set Active Material")]
    public void ButtonActive()
    {
        var mats = meshRenderer.materials;
        mats[1] = activeMat;
        meshRenderer.materials = mats;
    }

    [ContextMenu("Set Inactive Material")]
    public void ButtonInactive()
    {
        var mats = meshRenderer.materials;
        mats[1] = inactiveMat;
        meshRenderer.materials = mats;
    }

}
