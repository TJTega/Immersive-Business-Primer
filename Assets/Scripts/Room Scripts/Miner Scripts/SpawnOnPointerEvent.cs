using Microsoft.MixedReality.Toolkit.Input;
using UnityEngine;

namespace Microsoft.MixedReality.Toolkit.Examples.Demos
{

    // Example script that spawns a prefab at the pointer hit location.
    [AddComponentMenu("Scripts/MRTK/Examples/SpawnOnPointerEvent")]
    public class SpawnOnPointerEvent : MonoBehaviour
    {
        private bool active = false;
        public GameObject PrefabToSpawn;

        public void Spawn(MixedRealityPointerEventData eventData)
        {
            if (PrefabToSpawn != null && !active)
            {
                Debug.Log("Works");
                var result = eventData.Pointer.Result;

                PrefabToSpawn.transform.position = result.Details.Point;
                PrefabToSpawn.transform.rotation = Quaternion.Euler(result.Details.Normal);
                PrefabToSpawn.SetActive(true);
                active = true;
            }
        }
    }
}