using UnityEngine;

public class MoveState : IState
{
    private PlayerController _player;

    public MoveState(PlayerController player)
    {
        _player = player;
    }

    public void Enter()
    {
        Debug.Log("Move");
    }

    public void Update()
    {
        _player.Move();
        if (!_player.CheckGround.GetCheckGround())
        {
            _player.StateMachine.Change(_player.StateMachine.Jump);
        }

        if (_player.Rb2D.velocity.magnitude <= 0.1f)
        {
            
            _player.StateMachine.Change(_player.StateMachine.Idle);
        }
    }

    public void Exit()
    {
        Debug.Log("exit");
        _player.Anim.SetBool("IsMove", false);
    }


}
