using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Events;


public class Character : AbCharacter, IHit
{
    [SerializeField] private float _maxHealth = 3;
    [SerializeField] protected Skin currentSkin;
    [SerializeField] protected GameObject mask;
    [SerializeField] protected HealthBar healthBar;
    private float _currentHealth;

    public const float TIME_DELAY_THROW = 0.4f;
    [SerializeField] public float ATT_RANGE = 7f;

    private string animName;

    public const float MAX_SIZE = 1.2f;
    public const float MIN_SIZE = 1f;

    protected List<Character> targets = new List<Character>();
    protected Character target;

    private Vector3 targetPoint;

    protected float size = 1;
    public float Size => size;

    public bool IsDead { get; protected set; }
    public bool IsDie => _currentHealth <= 0;

    public bool IsCanAttack => currentSkin.Weapon.IsCanAttack;
    public bool IsCanCBAttack => currentSkin.CBWeapon.IsCanCBAttack;


    private void Awake()
    {
        healthBar = GetComponentInChildren<HealthBar>();
    }

    public override void OnInit()
    {
        _currentHealth = _maxHealth;
        healthBar.UpdateHealthBar(_currentHealth, _maxHealth);
        IsDead = false;
        WearClothes();
        ClearTarget();
    }
    public virtual void WearClothes()
    {
        
    }

    public virtual void TakeOffClothes()
    {
        currentSkin?.OnDespawn();
        SimplePool.Despawn(currentSkin);
    }

    public void SetMask(bool active)
    {
        mask.SetActive(active);
    }

    protected virtual void SetSize(float size)
    {
        size = Mathf.Clamp(size, MIN_SIZE, MAX_SIZE);
        this.size = size;
        TF.localScale = size * Vector3.one;
    }

    public override void OnAttack()
    {
        target = GetTargetInRange();

        if (IsCanAttack && target != null && !target.IsDead)
        {
            targetPoint = target.TF.position;
            TF.LookAt(targetPoint + (TF.position.y - targetPoint.y) * Vector3.up);
            ChangeAnim(Constant.ANIM_ATTACK);
        }  
    }

    public override void OnCBAttack()
    {
        target = GetTargetInRange();

        if (IsCanCBAttack && target != null && !target.IsDead)
        {
            targetPoint = target.TF.position;
            TF.LookAt(targetPoint + (TF.position.y - targetPoint.y) * Vector3.up);
            ChangeAnim(Constant.ANIM_ATTACK);
        }
    }

    public void Throw()
    {
        currentSkin.Weapon.Throw(this, targetPoint, size);
    }

    public override void OnDeath()
    {
        ChangeAnim(Constant.ANIM_DIE);
        LevelManager.Ins.CharecterDeath(this);
    }

    public override void OnDespawn()
    {
        TakeOffClothes();
    }


    public override void OnMoveStop()
    {
        
    }

    public virtual void AddTarget(Character target)
    {
        targets.Add(target);
    }

    //xoas muc tieu
    public virtual void RemoveTarget(Character target)
    {
        targets.Remove(target);
        this.target = null;
    }

    public Character GetTargetInRange()
    {
        Character target = null;
        float distance = float.PositiveInfinity;

        for (int i = 0; i < targets.Count; i++)
        {
            if (targets[i] != null && targets[i] != this && !targets[i].IsDead && Vector3.Distance(TF.position, targets[i].TF.position) <= ATT_RANGE * size + targets[i].size)
            {
                float dis = Vector3.Distance(TF.position, targets[i].TF.position);

                if (dis < distance)
                {
                    distance = dis;
                    target = targets[i];
                }
            }
        }

        return target;
    }

    public void ChangeAnim(string animName)
    {
        if (this.animName != animName)
        {
            currentSkin.Anim.ResetTrigger(this.animName);
            this.animName = animName;
            currentSkin.Anim.SetTrigger(this.animName);
        }
    }

    public void ResetAnim()
    {
        animName = "";
    }

    public void OnHit(UnityAction hitAction)
    {
        if (!IsDead)
        {        
            hitAction.Invoke();      
        } else
        {
            hitAction.Invoke();
        }

    }

    public void TakeDamage(float damage)
    {
        if (!IsDie)
        {
            _currentHealth -= damage;
            healthBar.UpdateHealthBar(_currentHealth, _maxHealth);
            if (IsDie)
            {
                IsDead = true;
                OnDeath();
            }
        }
    }

    protected void ClearTarget()
    {
        targets.Clear();
    }

    public void ChangeSkin(SkinType skinType)
    {
        currentSkin = SimplePool.Spawn<Skin>((PoolType)skinType, TF);
    }

    public void ChangeWeaponP(WeaponTypeP weaponTypeP)
    {
        currentSkin.ChangeWeaponP(weaponTypeP);
    }
    public void ChangeWeaponB(WeaponTypeB weaponTypeB)
    {
        currentSkin.ChangeWeaponB(weaponTypeB);
    }

    public void ChangeWeaponCB(WeaponTypeCB weaponTypeCB)
    {
        currentSkin.ChangeWeaponCB(weaponTypeCB);
    }

    public void ChangeHat(HatType hatType)
    {
        currentSkin.ChangeHat(hatType);
    }

    public void ChangePant(PantType pantType)
    {
        currentSkin.ChangePant(pantType);
    }
}
