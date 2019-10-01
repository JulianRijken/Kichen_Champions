using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerTest : MonoBehaviour
{

    //private Controls controles;

    //private void Awake()
    //{
    //    controles = new Controls();

    //}

    //private void OnEnable()
    //{
    //    controles.Enable();
    //}

    //private void OnDisable()
    //{
    //    controles.Disable();
    //}

    public void OnMove(InputAction.CallbackContext context)
    {

        transform.position += (Vector3)context.ReadValue<Vector2>() * Time.deltaTime * 40;
    }

    //public void OnDissconect()
    //{
    //    gameObject.SetActive(false);
    //}

    //public void OnConnected()
    //{
    //    gameObject.SetActive(true);
    //}

    void Update()
    {
        //Vector2 movement = controles.Player.Move.ReadValue<Vector2>();     
        //transform.position += (Vector3)movement * Time.deltaTime;
        //Debug.Log(controles.Player.Run.ReadValue<int>());
    }
}
