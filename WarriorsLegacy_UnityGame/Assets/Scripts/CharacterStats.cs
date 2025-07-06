using System.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;


public enum StatType
{
    strength,
    agility,
    intelligence,
    vitality,
    maxHealth,
    armor,
    evasion,
    damage
}
public class CharacterStats : MonoBehaviour
{

    [Header("Major stats")]
    public Stat strength;
    public Stat agility;
    public Stat intelligence;
    public Stat vitality;

    [Header("Defensive stats")]
    public Stat maxHealth;
    public Stat armor;
    public Stat evasion;


    public Stat damage;
    

    public int currentHealth;
    public System.Action onHealthChanged;

    public bool isDead {  get; private set; }


    protected virtual void Start()
    {
        currentHealth = GetMaxHealthValue();
        
    }
    public virtual void IncreaseStatBy(int _modifier, float _duration, Stat _statToModify)
    {
        StartCoroutine(StatModCoroutine(_modifier, _duration, _statToModify));  
    }

    private IEnumerator StatModCoroutine(int _modifier, float _duration, Stat _statToModify)
    {
        _statToModify.AddModifier(_modifier);
        yield return new WaitForSeconds(_duration);
        _statToModify.RemoveModifier(_modifier);
    }
    public virtual void DoDamage(CharacterStats _targetStats)
    {
        if (TargetCanAvoidAttack(_targetStats))
            return;

        int totalDamage = damage.GetValue() + strength.GetValue();



        totalDamage = CheckTargetArmor(_targetStats, totalDamage);
        _targetStats.TakeDamage(totalDamage);
    }

    public virtual void TakeDamage(int _damage)
    {
        DecreaseHealthBy(_damage);
        Debug.Log(_damage);
        if (currentHealth <= 0)
            Die();
    }
    public virtual void IncreaseHealthBy(int _amount)
    {
        currentHealth += _amount;

        if (currentHealth > GetMaxHealthValue())
            currentHealth = GetMaxHealthValue();

        if (onHealthChanged != null)
            onHealthChanged();
    }
    protected virtual void DecreaseHealthBy(int _damage)
    {
        currentHealth -= _damage;

        if(onHealthChanged != null)
            onHealthChanged();
    }
    protected virtual void Die()
    {
        isDead = true;
    }
    private int CheckTargetArmor(CharacterStats _targetStats, int totalDamage)
    {
        totalDamage -= _targetStats.armor.GetValue();
        totalDamage = Mathf.Clamp(totalDamage, 0, int.MaxValue);
        return totalDamage;
    }
    private  bool TargetCanAvoidAttack(CharacterStats _targetStats)
    {
        int _totalEvasion = _targetStats.evasion.GetValue() + _targetStats.agility.GetValue();

        if (Random.Range(0, 100) < _totalEvasion)
        {
            return true;
        }
        return false;
    }
    public int GetMaxHealthValue()
    {
        return maxHealth.GetValue() + vitality.GetValue() * 5;
    }
    public Stat GetStat(StatType _statType)
    {
        if (_statType == StatType.strength)
            return strength;
        else if (_statType == StatType.agility)
            return agility;
        else if (_statType == StatType.intelligence)
            return intelligence;
        else if (_statType == StatType.vitality)
            return vitality;
        else if (_statType == StatType.maxHealth)
            return maxHealth;
        else if (_statType == StatType.armor)
            return armor;
        else if (_statType == StatType.evasion)
            return evasion;
        else if (_statType == StatType.damage)
            return damage;

        return null;
    }
}
