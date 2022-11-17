using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController 
{
    private InputManager _inputManager;
    private GameObject _playerGameObject;
    private PlayerConfig _playerConfig;

    private Rigidbody2D _playerRigidbody;
    private PlayerShipReferences _playerShipReferences;

    Vector2 newPosition = Vector2.zero;

    [Inject]
    public PlayerController(InputManager p_inputManager, PlayerConfig p_playerConfig, Transform p_startingPos)
    {
        _inputManager = p_inputManager;
        _playerConfig = p_playerConfig;
        _playerGameObject = GameObject.Instantiate(_playerConfig.Player);
        _playerGameObject.transform.position = p_startingPos.position;
        _playerRigidbody = _playerGameObject.GetComponent<Rigidbody2D>();
        _playerShipReferences = _playerGameObject.GetComponent<PlayerShipReferences>();
        _inputManager.OnKeyboardInput += Movement;
        _inputManager.OnMouseClick += Shoot;
        _inputManager.OnMouseInput += Rotate;
        _playerShipReferences.MoveToSafeSpotOnHit.OnHit+=MoveToSafeSpot;
    }

    private void Rotate(Vector2 obj)
    {
        float AngleRad = Mathf.Atan2(Camera.main.ScreenToWorldPoint(obj).y - _playerGameObject.transform.position.y, Camera.main.ScreenToWorldPoint(obj).x - _playerGameObject.transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        _playerRigidbody.rotation= AngleDeg-90;
    }

    private void Shoot()
    {
        GameObject bullet = GameObject.Instantiate(_playerConfig.Bullet);
        bullet.transform.rotation = _playerGameObject.transform.rotation;
        bullet.transform.position = _playerShipReferences.ShootPos.position;
        bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * _playerConfig.ShootForce);
    }

    private void Movement(Vector2 value)
    {
        _playerRigidbody.AddForceAtPosition(_playerGameObject.transform.up * value.y, _playerGameObject.transform.position);
        _playerRigidbody.AddForceAtPosition(_playerGameObject.transform.right * value.x, _playerGameObject.transform.position);

    }
    private void MoveToSafeSpot() {
        float spawnY = UnityEngine.Random.Range
                    (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
        float spawnX = UnityEngine.Random.Range
            (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
        _playerGameObject.transform.position = new Vector2(spawnX, spawnY);
    }

}
