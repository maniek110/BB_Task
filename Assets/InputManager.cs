using System;
using UnityEngine;
using Zenject;

public class InputManager : IInitializable, IDisposable, ITickable
{
    private PlayerControlls _playerControlls;

    public Vector2 KeyboardDelta = Vector2.zero;
    public Vector2 MousePos = Vector2.zero;
    private bool _keyboardMoveInput = true;
    private bool _mouseMoveInput = true;

    public Action<Vector2> OnKeyboardInput;
    public Action<Vector2> OnMouseInput;
    public Action OnMouseClick;

    [Inject]
    public InputManager()
    {

        _playerControlls = new PlayerControlls();

        _playerControlls.Movement.MovementVector.performed += _ => _keyboardMoveInput = true;
        _playerControlls.Movement.MovementVector.canceled += _ => _keyboardMoveInput = false;
        _playerControlls.Movement.MousePosition.performed += _ => _mouseMoveInput = true;
        _playerControlls.Movement.MousePosition.canceled += _ => _mouseMoveInput = false;
        _playerControlls.Movement.MouseClick.performed += _ => OnMouseClick?.Invoke();
        Debug.Log("Input manager Initiated");

    }
    void Start()
    {
    }

    // Update is called once per frame
    public void GetKeyboarInput()
    {

    }

    public void Dispose()
    {
        _playerControlls.Disable();
    }

    public void Initialize()
    {
        _playerControlls.Enable();
    }
    private void DisableKeyboardMovement()
    {
        _keyboardMoveInput = false;
        KeyboardDelta = Vector2.zero;
    }

    public void Tick()
    {
        if (_keyboardMoveInput == true)
        {
            KeyboardDelta = _playerControlls.Movement.MovementVector.ReadValue<Vector2>();
            OnKeyboardInput?.Invoke(KeyboardDelta);
        }
        if (_mouseMoveInput == true)
        {
            MousePos = _playerControlls.Movement.MousePosition.ReadValue<Vector2>();
            OnMouseInput?.Invoke(MousePos);
        }
    }
}
