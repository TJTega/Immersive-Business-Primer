using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButtonPress : TouchPress
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
