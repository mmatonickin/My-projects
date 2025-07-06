using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderDeathState : EnemyState
{
    private EnemySpider enemy;
    public SpiderDeathState(Enemy _enemyBase, EnemyStateMachine _stateMachine, string _animBoolName, EnemySpider _enemy) : base(_enemyBase, _stateMachine, _animBoolName)
    {
        this.enemy = _enemy;
    }

    public override void Enter()
    {
        base.Enter();

        enemy.anim.SetBool(enemy.lastAnimBoolName, true);
        enemy.anim.speed = 0;
        enemy.pc.enabled = false;

        stateTimer = .1f;
    }

    public override void Update()
    {
        base.Update();
        if (stateTimer > 0)
            rb.velocity = new Vector2(0, 5);
    }
}
