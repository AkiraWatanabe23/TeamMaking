using System;
using UnityEngine;

public class StateMachine
{
    private IState _state;

    private JumpState _jump;

    public JumpState Jump => _jump;

    private MoveState _move;

    public MoveState Move => _move;

    private IdleState _idle;

    public IdleState Idle => _idle;

    public StateMachine(PlayerController player)
    {
        _jump = new JumpState(player);
        _move = new MoveState(player);
        _idle = new IdleState(player);
    }

    /// <summary>
    /// ������
    /// </summary>
    public void Init(IState state)
    {
        _state = state;
        state.Enter();
    }

    /// <summary>
    /// �X�e�[�g���ς�鎞�Ɏ��s����
    /// </summary>
    public void Change(IState nextState)
    {
        _state.Exit();
        _state = nextState;
        nextState.Enter();
    }

    public void Update()
    {
        _state.Update();
    }
}