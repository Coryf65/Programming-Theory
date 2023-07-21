namespace Interfaces
{
    public interface IDamageable
    {
        public int CurrentHealth { get; set; }
        public int MaxHealth { get; set; }
        public bool IsAlive { get; set; }

        public void Damage(int damageAmount);
        public void Heal(int healAmount);
        public int GetCurrentHealth();
        public bool Alive();
    }
}