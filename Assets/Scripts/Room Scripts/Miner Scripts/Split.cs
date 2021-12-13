using DG.Tweening;
using Microsoft.MixedReality.Toolkit.UI.BoundsControl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
public class Split : MonoBehaviour
{
    //This contains the objects that are to do an animation upon toggle for Mine Model 1
    [Header("Mine Model 1")]
    public DOTweenAnimation mine1;
    public DOTweenAnimation mine2;
    public DOTweenAnimation mine3;
    public DOTweenAnimation mine4;

    //This contains the objects that are to do an animation upon toggle for Mine Model 2
    [Header("Mine Model 2")]
    public DOTweenAnimation Decline;
    public DOTweenAnimation Shell;
    public DOTweenAnimation LevelAccess;
    public DOTweenAnimation OreDrives;
    public DOTweenAnimation Stocks;
    public DOTweenAnimation Stump;
    public DOTweenAnimation VentDrives;
    public DOTweenAnimation VentRaise;

    //This contains game objects to be toggled for Mine Model 1
    [Header("Mine 1 Bound Toggles")]
    public GameObject layer1;
    public GameObject layer2;
    public GameObject layer3;
    public GameObject layer4;
    public GameObject mineMain;

    //This contains game objects to be toggled for Mine Model 2
    [Header("Mine 2 Bound Toggles")]
    public GameObject decline;
    public GameObject shell;
    public GameObject levelAccess;
    public GameObject oreDrives;
    public GameObject stocks;
    public GameObject stump;
    public GameObject ventDrives;
    public GameObject ventRaise;
    public GameObject mine2Main;

    private bool splitToggle = true;

    private bool isTriggered = false;

    private bool triggerValue;

    void Start()
    {
        Debug.Log("Loaded Scene A");

        layer1.gameObject.GetComponent<BoundsControl>().Active = false;
        layer1.gameObject.GetComponent<BoxCollider>().enabled = false;

        layer2.gameObject.GetComponent<BoundsControl>().Active = false;
        layer2.gameObject.GetComponent<BoxCollider>().enabled = false;

        layer3.gameObject.GetComponent<BoundsControl>().Active = false;
        layer3.gameObject.GetComponent<BoxCollider>().enabled = false;

        layer4.gameObject.GetComponent<BoundsControl>().Active = false;
        layer4.gameObject.GetComponent<BoxCollider>().enabled = false;

        mineMain.GetComponent<BoundsControl>().enabled = true;


        decline.gameObject.GetComponent<BoundsControl>().Active = false;
        decline.gameObject.GetComponent<BoxCollider>().enabled = false;

        shell.gameObject.GetComponent<BoundsControl>().Active = false;
        shell.gameObject.GetComponent<BoxCollider>().enabled = false;

        levelAccess.gameObject.GetComponent<BoundsControl>().Active = false;
        levelAccess.gameObject.GetComponent<BoxCollider>().enabled = false;

        oreDrives.gameObject.GetComponent<BoundsControl>().Active = false;
        oreDrives.gameObject.GetComponent<BoxCollider>().enabled = false;

        stocks.gameObject.GetComponent<BoundsControl>().Active = false;
        stocks.gameObject.GetComponent<BoxCollider>().enabled = false;

        stump.gameObject.GetComponent<BoundsControl>().Active = false;
        stump.gameObject.GetComponent<BoxCollider>().enabled = false;

        ventDrives.gameObject.GetComponent<BoundsControl>().Active = false;
        ventDrives.gameObject.GetComponent<BoxCollider>().enabled = false;

        ventRaise.gameObject.GetComponent<BoundsControl>().Active = false;
        ventRaise.gameObject.GetComponent<BoxCollider>().enabled = false;

        mine2Main.gameObject.GetComponent<BoundsControl>().Active = true;
    }

    // Update is called once per frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);

        if (device.isValid)
        {
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out triggerValue) && triggerValue)
            {
                SplitToggle();
            }
        }
    }

    /// <summary>
    ///     This function is responsible for toggling the layers of the mine models and theirs interactables as well as animation
    /// </summary>
    [ContextMenu("use")]
    public void SplitToggle()

    {
        splitToggle = !splitToggle;
        if (splitToggle == false)
        {


            //These will play the animation forwards upon toggle for Mine 1
            Debug.Log("Toggle False");
            mine1.DOPlayForward();
            mine2.DOPlayForward();
            mine3.DOPlayForward();
            mine4.DOPlayForward();


            //These will play the animation forwards upon toggle for Mine 2
            Debug.Log("Toggles False 2");
            Decline.DOPlayForward();
            Shell.DOPlayForward();
            LevelAccess.DOPlayForward();
            OreDrives.DOPlayForward();
            Stocks.DOPlayForward();
            Stump.DOPlayForward();
            VentDrives.DOPlayForward();
            VentRaise.DOPlayForward();


            //These will set the box colliders and bounds control to true for Mine 1 when model is split
            layer1.gameObject.GetComponent<BoundsControl>().Active = true;
            layer1.gameObject.GetComponent<BoxCollider>().enabled = true;
            // layer1.gameObject.GetComponent<NearInteractionGrabbable>().enabled = true;

            layer2.gameObject.GetComponent<BoundsControl>().Active = true;
            layer2.gameObject.GetComponent<BoxCollider>().enabled = true;
            // layer2.gameObject.GetComponent<NearInteractionGrabbable>().enabled = true;

            layer3.gameObject.GetComponent<BoundsControl>().Active = true;
            layer3.gameObject.GetComponent<BoxCollider>().enabled = true;
            // layer3.gameObject.GetComponent<NearInteractionGrabbable>().enabled = true;

            layer4.gameObject.GetComponent<BoundsControl>().Active = true;
            layer4.gameObject.GetComponent<BoxCollider>().enabled = true;
            // layer4.gameObject.GetComponent<NearInteractionGrabbable>().enabled = true;

            mineMain.GetComponent<BoundsControl>().Active = false;
            // mineMain.gameObject.transform.localScale = Vector3.one;



            //These will set the box colliders and bounds control to true for Mine 2 when model is split
            decline.gameObject.GetComponent<BoundsControl>().Active = true;
            decline.gameObject.GetComponent<BoxCollider>().enabled = true;

            shell.gameObject.GetComponent<BoundsControl>().Active = true;
            shell.gameObject.GetComponent<BoxCollider>().enabled = true;

            levelAccess.gameObject.GetComponent<BoundsControl>().Active = true;
            levelAccess.gameObject.GetComponent<BoxCollider>().enabled = true;

            oreDrives.gameObject.GetComponent<BoundsControl>().Active = true;
            oreDrives.gameObject.GetComponent<BoxCollider>().enabled = true;

            stocks.gameObject.GetComponent<BoundsControl>().Active = true;
            stocks.gameObject.GetComponent<BoxCollider>().enabled = true;

            stump.gameObject.GetComponent<BoundsControl>().Active = true;
            stump.gameObject.GetComponent<BoxCollider>().enabled = true;

            ventDrives.gameObject.GetComponent<BoundsControl>().Active = true;
            ventDrives.gameObject.GetComponent<BoxCollider>().enabled = true;

            ventRaise.gameObject.GetComponent<BoundsControl>().Active = true;
            ventRaise.gameObject.GetComponent<BoxCollider>().enabled = true;

            mine2Main.gameObject.GetComponent<BoundsControl>().Active = false;
        }
        if (splitToggle == true)
        {
            isTriggered = false;

            //These will play the animation backwards upon toggle again for Mine 1
            Debug.Log("Toggle True");
            mine1.DOPlayBackwards();
            mine2.DOPlayBackwards();
            mine3.DOPlayBackwards();
            mine4.DOPlayBackwards();


            //These will play the animation backwards upon toggle again for Mine 2
            Debug.Log("Toggle True 2");
            Decline.DOPlayBackwards();
            Shell.DOPlayBackwards();
            LevelAccess.DOPlayBackwards();
            OreDrives.DOPlayBackwards();
            Stocks.DOPlayBackwards();
            Stump.DOPlayBackwards();
            VentDrives.DOPlayBackwards();
            VentRaise.DOPlayBackwards();


            //Rests the transform of Mine 1 layers by getting the parents transform
            layer1.gameObject.transform.rotation = transform.parent.rotation;
            layer2.gameObject.transform.rotation = transform.parent.rotation;
            layer3.gameObject.transform.rotation = transform.parent.rotation;
            layer4.gameObject.transform.rotation = transform.parent.rotation;


            //Rests the transform of Mine 2 layers by getting the parents transform
            decline.gameObject.transform.rotation = transform.parent.rotation;
            shell.gameObject.transform.rotation = transform.parent.rotation;
            levelAccess.gameObject.transform.rotation = transform.parent.rotation;
            oreDrives.gameObject.transform.rotation = transform.parent.rotation;
            stocks.gameObject.transform.rotation = transform.parent.rotation;
            stump.gameObject.transform.rotation = transform.parent.rotation;
            ventDrives.gameObject.transform.rotation = transform.parent.rotation;
            ventRaise.gameObject.transform.rotation = transform.parent.rotation;


            //These will set the box colliders and bounds control to false for Mine 1 when model is not split
            layer1.gameObject.GetComponent<BoundsControl>().Active = false;
            layer1.gameObject.GetComponent<BoxCollider>().enabled = false;
            //  layer1.gameObject.GetComponent<NearInteractionGrabbable>().enabled = false;

            layer2.gameObject.GetComponent<BoundsControl>().Active = false;
            layer2.gameObject.GetComponent<BoxCollider>().enabled = false;
            // layer2.gameObject.GetComponent<NearInteractionGrabbable>().enabled = false;

            layer3.gameObject.GetComponent<BoundsControl>().Active = false;
            layer3.gameObject.GetComponent<BoxCollider>().enabled = false;
            // layer3.gameObject.GetComponent<NearInteractionGrabbable>().enabled = false;

            layer4.gameObject.GetComponent<BoundsControl>().Active = false;
            layer4.gameObject.GetComponent<BoxCollider>().enabled = false;
            // layer4.gameObject.GetComponent<NearInteractionGrabbable>().enabled = false;

            mineMain.GetComponent<BoundsControl>().Active = true;


            //These will set the box colliders and bounds control to false for Mine 2 when model is not split
            decline.gameObject.GetComponent<BoundsControl>().Active = false;
            decline.gameObject.GetComponent<BoxCollider>().enabled = false;

            shell.gameObject.GetComponent<BoundsControl>().Active = false;
            shell.gameObject.GetComponent<BoxCollider>().enabled = false;

            levelAccess.gameObject.GetComponent<BoundsControl>().Active = false;
            levelAccess.gameObject.GetComponent<BoxCollider>().enabled = false;

            oreDrives.gameObject.GetComponent<BoundsControl>().Active = false;
            oreDrives.gameObject.GetComponent<BoxCollider>().enabled = false;

            stocks.gameObject.GetComponent<BoundsControl>().Active = false;
            stocks.gameObject.GetComponent<BoxCollider>().enabled = false;

            stump.gameObject.GetComponent<BoundsControl>().Active = false;
            stump.gameObject.GetComponent<BoxCollider>().enabled = false;

            ventDrives.gameObject.GetComponent<BoundsControl>().Active = false;
            ventDrives.gameObject.GetComponent<BoxCollider>().enabled = false;

            ventRaise.gameObject.GetComponent<BoundsControl>().Active = false;
            ventRaise.gameObject.GetComponent<BoxCollider>().enabled = false;

            mine2Main.gameObject.GetComponent<BoundsControl>().Active = true;

            layer1.gameObject.transform.localScale = Vector3.one;
            layer2.gameObject.transform.localScale = Vector3.one;
            layer3.gameObject.transform.localScale = Vector3.one;
            layer4.gameObject.transform.localScale = Vector3.one;

            decline.gameObject.transform.localScale = Vector3.one;
            shell.gameObject.transform.localScale = Vector3.one;
            levelAccess.gameObject.transform.localScale = Vector3.one;
            oreDrives.gameObject.transform.localScale = Vector3.one;
            stocks.gameObject.transform.localScale = Vector3.one;
            stump.gameObject.transform.localScale = Vector3.one;
            ventDrives.gameObject.transform.localScale = Vector3.one;
            ventRaise.gameObject.transform.localScale = Vector3.one;
        }
    }

    public void SceneToMiner2()
    {
        Debug.Log("Loaded Scene B");
        //SceneManager.LoadScene()
        SceneManager.LoadScene("Miner2");
    }

    public void SceneToMain()
    {
        SceneManager.LoadScene("Main");
    }

    public void DebugPles()
    {
        Debug.Log(this.gameObject.name);
    }
}
