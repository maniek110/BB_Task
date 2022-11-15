using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController
{
    private InputManager _inputManager;
    private GameObject _playerGameObject;
    
    private Rigidbody2D _playerRigidbody;
    


    [Inject]
    public PlayerController(InputManager p_inputManager, GameObject p_playerObject)
    {
        _inputManager = p_inputManager;
        _playerGameObject = GameObject.Instantiate(p_playerObject);
        _playerGameObject.transform.position = Vector2.zero;
        _playerRigidbody = _playerGameObject.GetComponent<Rigidbody2D>();
        _inputManager.OnKeyboardInput += Movement;
    }

    private void Movement(Vector2 value)
    {
        Debug.Log(value);
        _playerRigidbody.AddForceAtPosition(_playerGameObject.transform.up*value.y,_playerGameObject.transform.position);
        _playerRigidbody.AddTorque(-value.x);

    }
}
