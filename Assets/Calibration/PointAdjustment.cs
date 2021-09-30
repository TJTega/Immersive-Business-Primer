using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
public class PointAdjustment : MonoBehaviour
{
    private int pointCounter = 0;
    public Collider physicalTop;
    public Collider physicalBottom;
    public Virtual_Floor_Alignment floorAlignment;
    public Text debugText;
    private bool pointsAdjusted= false;
    bool TryGetControllerPosition(out Vector3 position)
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        if (device.isValid)
        {
            if (device.TryGetFeatureValue(CommonUsages.devicePosition, out position))
                return true;
        }
        // This is the fail case, where there was no center eye was available.
        position = transform.position;
        return false;
    }
   
    public void SetPoint()
    {
        TryGetControllerPosition(out Vector3 handPosition);
        if (floorAlignment.forwardSet && !pointsAdjusted)
        {
            switch (pointCounter)
            {
                case 0:
                    Debug.Log("Point Adjustment Activated");
                    //increment();
                    break;
                //Sets point 1
                case 1:
                    physicalTop.gameObject.transform.position = handPosition;
                    //increment();
                    Debug.Log("Point A Set" + pointCounter);
                    debugText.text= "Point A Set";
                    break;
                    //Sets point 2
                case 2:
                    physicalBottom.gameObject.transform.position = handPosition;
                    //increment();
                    Debug.Log("Point B Set" + pointCounter);
                    debugText.text = "Point B Set";
                    break;
                    //Calibrates based on points
                case 3:
                    StartCoroutine(floorAlignment.Calibrate(physicalTop, physicalBottom));
                    //increment();
                    Debug.Log("Calibrating" + pointCounter);
                    debugText.text = "Calibrating...";
                    pointsAdjusted = true;
                    break;
                    //reset
                default:
                    debugText.text = null;
                    
                    break;
            }
        }
    }

    public void increment()
    {
        pointCounter++;
        if(pointCounter == 4) { pointCounter = 0; }
    }

    public void resestCalibration()
    {
        pointsAdjusted = false;
        pointCounter = 0;
        floorAlignment.forwardSet = false;
        debugText.text = "Calibration Reset...";
      
    }

}
