using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PhysicsButton : MonoBehaviour
{
    public float threshold = 0.1f;
    public float deadZone = 0.025f;

    private bool isPressed;
    private Vector3 startPos;
    private ConfigurableJoint joint;
    public UnityEvent onPressed, onRelease;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
        joint = GetComponent<ConfigurableJoint>();

    }

    // Update is called once per frame
    void Update()
    {
        if(!isPressed && GetValue() + threshold >= 1) { Pressed(); }
        if(isPressed && GetValue() - threshold >= 1) { Released(); }
    }

    private float GetValue()
    {
        var value = Vector3.Distance(startPos, transform.localPosition) / joint.linearLimit.limit;
        if(Mathf.Abs(value) < deadZone)
        {
            value = 0;
        }
        return Mathf.Clamp(value, -1f, 1);
    }
    private void Pressed()
    {
        isPressed = true;
        onPressed.Invoke();
    }
    private void Released()
    {
        isPressed = false;
        onRelease.Invoke();
    }
}
