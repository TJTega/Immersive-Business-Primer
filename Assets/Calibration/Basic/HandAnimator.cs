using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class HandAnimator : MonoBehaviour
{
    public float speed = 5.0f;
    public XRController controllerL = null;
    public XRController controllerR = null;
    private Animator animator = null;
    

    private readonly List<Finger> gripFingersL = new List<Finger>()
    {
        new Finger(FingerType.MiddleL),
        new Finger(FingerType.RingL),
        new Finger(FingerType.PinkyL)
    };

    private readonly List<Finger> gripFingersR = new List<Finger>()
    {
        
        new Finger(FingerType.MiddleR),
        new Finger(FingerType.RingR),
        new Finger(FingerType.PinkyR)
    };

    private readonly List<Finger> pointFingersL = new List<Finger>()
    {
        new Finger(FingerType.IndexL),
        new Finger(FingerType.ThumbL),
    };

    private readonly List<Finger> pointFingersR = new List<Finger>()
    {
        
        new Finger(FingerType.IndexR),
        new Finger(FingerType.ThumbR)
    };
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        //Store input
        CheckPointer();
        CheckGrip();

        //Smooth input
        SmoothFinger(pointFingersL);
        SmoothFinger(gripFingersL);
        SmoothFinger(pointFingersR);
        SmoothFinger(gripFingersR);

        //Apply smoothed values
        AnimateFinger(pointFingersL);
        AnimateFinger(gripFingersL);
        AnimateFinger(pointFingersR);
        AnimateFinger(gripFingersR);
    }

    private void CheckGrip()
    {
        if (controllerL.inputDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValueL) )
        {
            SetFingerTargets(gripFingersL, gripValueL);
         
        }
        if (controllerR.inputDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValueR) )
        {
            SetFingerTargets(gripFingersR, gripValueR);
         
        }
    }

    private void CheckPointer()
    {
        if (controllerL.inputDevice.TryGetFeatureValue(CommonUsages.trigger, out float pointerValueL) )
        {
            SetFingerTargets(pointFingersL, pointerValueL);
            
            
        }
        if (controllerR.inputDevice.TryGetFeatureValue(CommonUsages.trigger, out float pointerValueR ) )
        {
            SetFingerTargets(pointFingersR, pointerValueR);

        }

    }

    private void SetFingerTargets(List<Finger> fingers, float value)
    {
        foreach(Finger finger in fingers)
        {
            finger.target = value;
            
        }
    }

    private void SmoothFinger(List<Finger> fingers)
    {
        foreach(Finger finger in fingers)
        {
            float time = speed * Time.unscaledTime;
            finger.current = Mathf.MoveTowards(finger.current, finger.target, time);
        }
    }

    private void AnimateFinger(List<Finger> fingers)
    {
        foreach(Finger finger in fingers)
        {
            AnimateFinger(finger.type.ToString(), finger.current);
        }
    }

    private void AnimateFinger(string finger, float blend)
    {
        animator.SetFloat(finger, blend);
    }
}