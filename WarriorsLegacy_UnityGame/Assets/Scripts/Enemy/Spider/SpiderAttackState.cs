using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAttackState : EnemyState
{

    private EnemySpider enemy;
    public SpiderAttackState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, EnemySpider _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();

        enemy.lastTimeAttacked = Time.time;
    }

    public override void Update()
    {
        base.Update();

        enemy.SetZeroVelocity();

        if(triggerCalled)
            stateMachine.ChangeState(enemy.battleState);
    }
}
