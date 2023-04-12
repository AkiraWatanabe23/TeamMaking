using UnityEngine;

public class IdleState : IState
{
    private PlayerController _player;

    /// <summary>
    /// �R���X�g���N�^
    /// </summary>
    public IdleState(PlayerController player)
    {
        _player = player;
    }

    public void Enter()
    {
        //�F��ς���
        //_player.Renderer.color = Color.white;
        Debug.Log("Idel");
    }

    public void Update()
    {
        if (!_player.CheckGround.GetCheckGround())
        {
            _player.StateMachine.Change(_player.StateMachine.Jump);
        }

        if (_player.Rb2D.velocity.magnitude >= 0.1f)
        {
            
            _player.StateMachine.Change(_player.StateMachine.Move);
        }
    }

    public void Exit()
    {

    }


}
