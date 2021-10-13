using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinobject : MonoBehaviour
{
    Vector3 rotateVector = new Vector3(0, 100f, 0);
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotateVector * Time.deltaTime);
    }
}
