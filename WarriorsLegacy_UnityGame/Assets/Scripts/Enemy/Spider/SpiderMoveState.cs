using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMoveState : SpiderGroundedState
{
    public SpiderMoveState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, EnemySpider enemy) : base(_enemyBase, _stateMachine, _animBoolName, enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        enemy.SetVelocity(enemy.moveSpeed * enemy.facingDir, rb.velocity.y);

        if (enemy.isWallDetected() || !enemy.isGroundDetected())
        {
            enemy.Flip();
            stateMachine.ChangeState(enemy.idleState);
        }

    }
}
