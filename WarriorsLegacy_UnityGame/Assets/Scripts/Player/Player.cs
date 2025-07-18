using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{

    [Header("Attack details")]
    public Vector2[] attackMovement;
  
    
    public bool isBusy {  get; private set; }
    [Header("Move information")]
    public float moveSpeed = 4f;
    public float jumpForce;

    [Header("Dash information")]
    [SerializeField] private float dashCooldown;
    private float dashUsageTimer;
    public float dashSpeed;
    public float dashDuration;
    public float dashDir {  get; private set; }
    




  

    #region States
    public PlayerStateMachine stateMachine {  get; private set; }
   
    public PlayerIdleState idleState { get; private set; }

    public PlayerMoveState moveState { get; private set; }
    public PlayerJumpState jumpState { get; private set; }
    public PlayerAirState airState { get; private set; }
    public PlayerDashState dashState { get; private set; }

    public PlayerPrimaryAttackState primaryAttack { get; private set; }
    public PlayerDeathState deathState { get; private set; }
    public UI_StatSlot statSlot { get; private set; }
    #endregion


    protected override void Awake()
    {
        base.Awake();
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
        jumpState = new PlayerJumpState(this, stateMachine, "Jump");
        airState = new PlayerAirState(this, stateMachine, "Jump");
        dashState = new PlayerDashState(this, stateMachine, "Dash");

        primaryAttack = new PlayerPrimaryAttackState(this, stateMachine, "Attack");

        deathState = new PlayerDeathState(this, stateMachine, "Die");
    }

    protected override void Start()
    {

        base.Start();
        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
        CheckForDashInput();

        if (Input.GetKeyDown(KeyCode.H))
            Inventory.instance.UseFlask();
            
            
        
    }

    public IEnumerator BusyFor (float _seconds)
    {
        isBusy = true;
        
        yield return new WaitForSeconds(_seconds);

        isBusy = false;
    }

    public void AnimationTrigger() => stateMachine.currentState.AnimationFinsihTrigger();

    private void CheckForDashInput()
    {

        dashUsageTimer -= Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.LeftShift) && dashUsageTimer < 0)
        {
            dashUsageTimer = dashCooldown;
            dashDir = Input.GetAxisRaw("Horizontal");

            if (dashDir == 0)
                dashDir = facingDir;

            stateMachine.ChangeState(dashState);
        }
    }
    public override void Die()
    {
        base.Die();

        stateMachine.ChangeState(deathState);
    }
}
