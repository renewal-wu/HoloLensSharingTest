using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using Newtonsoft.Json;
using UnityEngine;

public class TapToExplosion : MonoBehaviour, IInputClickHandler
{
    public GameObject Effect;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        Instantiate(Effect, this.gameObject.transform.position, this.gameObject.transform.rotation);

        var s = JsonConvert.SerializeObject(new
        {
            test = ""
        });
    }
}
