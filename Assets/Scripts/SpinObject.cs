using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinObject : MonoBehaviour
{
    public GameObject model;
    public int up_Down_Left_Right;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        switch (up_Down_Left_Right)
        {
            case 1:
                model.transform.Rotate(Time.deltaTime * 10, 0, 0, Space.World);

                break;
            case 2:
                model.transform.Rotate(Time.deltaTime * -10, 0, 0, Space.World);
                break;
            case 3:
                
                model.transform.Rotate(Time.deltaTime * 0, 1, 0, Space.World);
                break;
            case 4:
                model.transform.Rotate(Time.deltaTime * 0, -1, 0, Space.World);
                break;
        }
    }
}
