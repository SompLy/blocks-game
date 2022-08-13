using UnityEngine;
using UnityEngine.InputSystem;

public class HumanoidLandInput : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; } = Vector2.zero;
    public bool MoveIsPressed = false;
    public Vector2 LookInput { get; private set; } = Vector2.zero;
    public float PlaceBlockInput { get; private set; } = 0f;
    public float RemoveBlockInput { get; private set; } = 0f;
    public float ZoomCameraInput { get; private set; } = 0f;
    public bool InvertMouseY { get; private set; } = true;
    public bool InvertScroll { get; private set; } = true;
    public bool RunIsPressed { get; private set; } = false;
    public bool JumpIsPressed { get; private set; } = false;
    public bool SneakIsPressed { get; private set; } = false;

    InputActions _input = null;

    private void OnEnable()
    {
        _input = new InputActions();
        _input.HumanoidLand.Enable();

        _input.HumanoidLand.Move.performed += SetMove;
        _input.HumanoidLand.Move.canceled += SetMove;

        _input.HumanoidLand.Run.started += SetRun;
        _input.HumanoidLand.Run.canceled += SetRun;

        _input.HumanoidLand.Jump.started += SetJump;
        _input.HumanoidLand.Jump.canceled += SetJump;

        _input.HumanoidLand.Sneak.started += SetSneak;
        _input.HumanoidLand.Sneak.canceled += SetSneak;

        _input.HumanoidLand.RemoveBlock.started += SetRemoveBlock;
        _input.HumanoidLand.RemoveBlock.canceled += SetRemoveBlock;

        _input.HumanoidLand.Look.performed += SetLook;
        _input.HumanoidLand.Look.canceled += SetLook;

        _input.HumanoidLand.ZoomCamera.started += SetCameraZoom;
        _input.HumanoidLand.ZoomCamera.canceled += SetCameraZoom;

        _input.HumanoidLand.PlaceBlock.started += SetPlaceBlock;
        _input.HumanoidLand.PlaceBlock.canceled += SetPlaceBlock;
    }
    private void OnDisable()
    {
        _input.HumanoidLand.Enable();

        _input.HumanoidLand.Move.performed -= SetMove;
        _input.HumanoidLand.Move.canceled -= SetMove;

        _input.HumanoidLand.Run.performed -= SetRun;
        _input.HumanoidLand.Run.canceled -= SetRun;

        _input.HumanoidLand.Jump.started -= SetJump;
        _input.HumanoidLand.Jump.canceled -= SetJump;

        _input.HumanoidLand.Sneak.started -= SetSneak;
        _input.HumanoidLand.Sneak.canceled -= SetSneak;

        _input.HumanoidLand.RemoveBlock.started -= SetRemoveBlock;
        _input.HumanoidLand.RemoveBlock.canceled -= SetRemoveBlock;

        _input.HumanoidLand.Look.performed -= SetLook;
        _input.HumanoidLand.Look.canceled -= SetLook;

        _input.HumanoidLand.ZoomCamera.started -= SetCameraZoom;
        _input.HumanoidLand.ZoomCamera.canceled -= SetCameraZoom;

        _input.HumanoidLand.PlaceBlock.performed -= SetPlaceBlock;
        _input.HumanoidLand.PlaceBlock.canceled -= SetPlaceBlock;

        _input.HumanoidLand.Disable();
    }

    private void SetMove(InputAction.CallbackContext ctx) 
    {
        MoveInput = ctx.ReadValue<Vector2>();
        MoveIsPressed = !(MoveInput == Vector2.zero);
    }
    private void SetRun(InputAction.CallbackContext ctx)
    {
        RunIsPressed = ctx.started;
    }
    private void SetJump(InputAction.CallbackContext ctx)
    {
        JumpIsPressed = ctx.started;
    }
    private void SetSneak(InputAction.CallbackContext ctx)
    {
        SneakIsPressed = ctx.started;    
    }
    private void SetLook(InputAction.CallbackContext ctx)
    {
        LookInput = ctx.ReadValue<Vector2>();
    }
    private void SetCameraZoom(InputAction.CallbackContext ctx) 
    {
        ZoomCameraInput = ctx.ReadValue<float>();
    }
    private void SetPlaceBlock(InputAction.CallbackContext ctx)
    {
        PlaceBlockInput = ctx.ReadValue<float>();
    }
    private void SetRemoveBlock(InputAction.CallbackContext ctx)
    {
        RemoveBlockInput = ctx.ReadValue<float>();
    }
}
