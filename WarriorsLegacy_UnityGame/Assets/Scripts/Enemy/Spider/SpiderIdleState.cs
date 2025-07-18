using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderIdleState : SpiderGroundedState
{
    public SpiderIdleState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, EnemySpider enemy) : base(_enemyBase, _stateMachine, _animBoolName, enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateTimer = enemy.idleTime;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if(stateTimer < 0) 
            stateMachine.ChangeState(enemy.moveState);
    }
}
