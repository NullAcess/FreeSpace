/*
👤 Создать класс Character.

🩸 Добавить в него приватное поле int _health = 100.

📜 Объявить кастомный делегат HealthChangedHandler, который возвращает void и принимает один параметр int newHealth.

🔔 Внутри класса Character объявить событие OnHealthChanged на основе созданного делегата.
*/

delegate void HealthChangedHandler(int health);

class Character
{
    private int _health;
    public event HealthChangedHandler? HealthChanged;

    public Character(int health)
    {
        _health = health;
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);
    }
}

class Program
{
    static void HealthDisplay(int health)
    {
        Console.WriteLine($"Character new health: {health}");
    }

    static void Main()
    {
        var hero = new Character(100);
        hero.HealthChanged += HealthDisplay;

        hero.TakeDamage(20);
    }
}