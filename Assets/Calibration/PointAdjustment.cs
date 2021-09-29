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
        if (floorAlignment.forwardSet)
        {
            switch (pointCounter)
            {
                case 0:
                    Debug.Log("Point Adjustment Activated");
                    pointCounter += 1;
                    break;
                //Sets point 1
                case 1:
                    physicalTop.gameObject.transform.position = handPosition;
                    pointCounter += 1;
                    Debug.Log("Point A Set" + pointCounter);
                    debugText.text= "Point A Set";
                    break;
                    //Sets point 2
                case 2:
                    physicalBottom.gameObject.transform.position = handPosition;
                    pointCounter += 1;
                    Debug.Log("Point B Set" + pointCounter);
                    debugText.text = "Point B Set";
                    break;
                    //Calibrates based on points
                case 3:
                    StartCoroutine(floorAlignment.Calibrate(physicalTop, physicalBottom));
                    pointCounter += 1;
                    Debug.Log("Calibrating" + pointCounter);
                    debugText.text = "Calibrating...";
                    break;
                    //reset
                default:
                    pointCounter = 0;
                    break;
            }
        }
    }

}
