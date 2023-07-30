using StarterAssets;
using UnityEngine;

public class UICanvasControllerInput : MonoBehaviour
{

    [Header("Output")]
    public StarterAssetsInputs inputs;

    public void VirtualMoveInput(Vector2 virtualMoveDirection)
    {
        inputs.move = virtualMoveDirection;
    }

    public void VirtualLookInput(Vector2 virtualLookDirection)
    {
        inputs.look = virtualLookDirection;
    }

    public void VirtualJumpInput(bool virtualJumpState)
    {
        inputs.jump = virtualJumpState;
    }

    public void VirtualSprintInput(bool virtualSprintState)
    {
        inputs.sprint = virtualSprintState;
    }

    public void VirtualAimInput(bool virtualAimState)
    {
        inputs.aim = virtualAimState;
    }

    public void VirtualReloadInput(bool virtualReloadState)
    {
        inputs.reload = virtualReloadState;
    }

    public void VirtualShootInput(bool virtualShootState)
    {
        inputs.shoot = virtualShootState;
    }

    //public void VirtualSwitchInput(bool virtualSwitchState)
    //{
    //    inputs.switchMode = virtualSwitchState;
    //}
}