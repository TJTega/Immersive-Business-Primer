using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;

public class HideToggle : MonoBehaviour
{
    public void Hide()
    {
        this.gameObject.SetActive(!this.gameObject.activeInHierarchy);
    }
}
