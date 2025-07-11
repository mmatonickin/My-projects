using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderGroundedState : EnemyState
{
    protected EnemySpider enemy;
    protected Transform player; 
    public SpiderGroundedState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, EnemySpider _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();
        player = GameObject.Find("Player").transform;
    }


    public override void Exit()
    {
        base.Exit();
    }
    public override void Update()
    {
        base.Update();

        if(enemy.IsPlayerDetected() ||Vector2.Distance(enemy.transform.position, player.position) < 2) 
            stateMachine.ChangeState(enemy.battleState);
    }

}
