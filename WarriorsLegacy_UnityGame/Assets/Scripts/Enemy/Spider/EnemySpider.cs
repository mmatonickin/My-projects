using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpider : Enemy
{
    #region States
    public SpiderIdleState idleState {  get; private set; }
    public SpiderMoveState moveState { get; private set; }
    public SpiderBattleState battleState { get; private set; }
    public SpiderAttackState attackState { get; private set; }
    public SpiderDeathState deathState { get; private set; }
    
    #endregion
    protected override void Awake()
    {
        base.Awake();

        idleState = new SpiderIdleState(this, stateMachine, "Idle", this);
        moveState = new SpiderMoveState(this, stateMachine, "Move", this);
        battleState = new SpiderBattleState(this, stateMachine, "Move", this);
        attackState = new SpiderAttackState(this, stateMachine, "Attack", this);
        deathState = new SpiderDeathState(this, stateMachine, "Die", this);
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();

    }
    public override void Die()
    {
        base.Die();
        stateMachine.ChangeState(deathState);
        if (gameObject.name == "SpiderEnemy (9)")
        {
            SceneManager.LoadScene("MainMenu");
        }

        Destroy(gameObject); 
    }
}

