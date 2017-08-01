using System;
using System.Collections;
using System.Collections.Generic;
using HoloToolkit.Unity.InputModule;
using UnityEngine;

public class Pokemon : MonoBehaviour, IInputClickHandler
{
    private void OnCollisionEnter(Collision collision)
    {
        var pokeball = collision.gameObject.GetComponent<Pokeball>();
        if (pokeball == null)
        {
            return;
        }

        Physics.IgnoreCollision(this.gameObject.GetComponent<Collider>(), collision.collider);
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        GeneratePokeball();
    }

    private void GeneratePokeball()
    {
        var pokeball = Resources.Load("Pokeball/MasterBallObject") as GameObject;

        var position = Camera.main.transform.position;
        var rotation = Camera.main.transform.rotation;
        var pokeballObject = Instantiate(pokeball, position, rotation) as GameObject;

        var diff = pokeballObject.transform.position - this.gameObject.transform.position;
        pokeballObject.transform.TransformDirection(diff);
    }
}
