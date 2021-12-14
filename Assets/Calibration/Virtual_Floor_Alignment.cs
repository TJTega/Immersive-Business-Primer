using System.Collections;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.UI;
using TMPro;
public class Virtual_Floor_Alignment : MonoBehaviour
{
    public float height;
    public bool forwardSet = false;
    public Collider virtualTop;
    public Collider virtualBottom;
    public GameObject cube;
    public PointAdjustment pointAdjustment;
    Quaternion handRotation;
    public TextMeshProUGUI debugText;
    public GameObject marker;
    bool TryGetRightHandFeature(out Quaternion rotation)
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        if (device.isValid)
        {
            if (device.TryGetFeatureValue(CommonUsages.deviceRotation, out rotation))
                return true;
        }
        // This is the fail case, where there was no center eye was available.
        rotation = Quaternion.identity;
        return false;
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (marker == null)
        {
            marker = GameObject.FindWithTag("LobbyMarker");
        }
        InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        bool triggerValue;
        TryGetRightHandFeature(out handRotation);
        
        //transform.position = ControllerData.RightControllerData.transform.position;
        //transform.eulerAngles = ControllerData.RightControllerData.transform.eulerAngles;
        if (forwardSet == false)
        {
            marker.SetActive(true);
            transform.position = new Vector3(InputTracking.GetLocalPosition(XRNode.RightHand).x, height, InputTracking.GetLocalPosition(XRNode.RightHand).z);
            transform.eulerAngles = new Vector3(0,handRotation.eulerAngles.y , 0);
            
        }
       
        
    }

    //  public void DoTheThing()
    //   {
    //       forwardSet = true;
    //  }

    //public IEnumerator Calibrate(Collider physicalTop, Collider physicalBottom)
    //{
    //    yield return null;
    //    Debug.Log("Forward: " + transform.forward);
    //    bool aligned = false;
    //    Vector3 virtualMid = new Vector3((virtualTop.transform.position.x + virtualBottom.transform.position.x) / 2, 0, (virtualTop.transform.position.z + virtualBottom.transform.position.z) / 2);
    //    Vector3 physicalMid = new Vector3((physicalTop.transform.position.x + physicalBottom.transform.position.x) / 2, 0, (physicalTop.transform.position.z + physicalBottom.transform.position.z) / 2);
    //    cube.transform.position = physicalMid;
    //    Vector3 difference = physicalMid - virtualMid;

    //    transform.Translate(difference);


    //    //if (physicalTop.bounds.Contains(virtualTop.transform.position) && physicalBottom.bounds.Contains(virtualBottom.transform.position))
    //    //{
    //    //float closest;
    //    //while (/*physicalTop.bounds.Contains(virtualTop.transform.position) && physicalBottom.bounds.Contains(virtualBottom.transform.position) && */aligned == false)
    //    //{
    //    //    transform.Rotate(new Vector3(0,0.01f,0));
    //    //    yield return new WaitForSeconds(Time.deltaTime);
    //    //    if (transform.eulerAngles.y > 60)
    //    //    {
    //    //        aligned = true;
    //    //    }
    //    //}
    //    //}

    //    Debug.Log(virtualMid);
    //    Debug.Log(physicalMid);
    //}

    //public bool between(float value, float min, float max)
    //{
    //    if (value >= min && value <= max)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}
    public void SetForward()
    {
        if (!forwardSet)
        {
            marker.SetActive(false);
            forwardSet = true;
            Debug.Log("Forward set" + forwardSet);
            debugText.text = "Forward Set";
        }
    }
}
