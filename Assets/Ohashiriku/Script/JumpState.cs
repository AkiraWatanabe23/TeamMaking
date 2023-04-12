using UnityEngine;

public class JumpState : IState
{

    private PlayerController _player;

    public JumpState(PlayerController player)
    {
        _player = player;
    }

    public void Enter()
    {
        Debug.Log("jump");
    }

    public void Update()
    {
        _player.Jump();
        if (_player.CheckGround.GetCheckGround())
        {
            if (_player.Rb2D.velocity.magnitude <= 0.1f)
            {
                _player.StateMachine.Change(_player.StateMachine.Idle);
            }
            else
            {
                Debug.Log("ww");
                _player.StateMachine.Change(_player.StateMachine.Move);
            }

        }
    }

    public void Exit()
    {
        
    }


}
