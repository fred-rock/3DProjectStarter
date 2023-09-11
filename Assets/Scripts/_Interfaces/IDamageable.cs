public interface IDamageable
{
    public bool IsDamageable { get; }

    public void AttemptDamage(int damage);

    public void Damage(int damage);

}