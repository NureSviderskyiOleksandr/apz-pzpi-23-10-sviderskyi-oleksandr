namespace ResearchAbstractFactory
{
    // --- Інтерфейси продуктів ---
    public interface IWarrior { string GetInfo(); }
    public interface IArcher { string GetInfo(); }
    public interface IMage { string GetInfo(); }

    // --- Конкретні продукти: Орки ---
    public class OrcWarrior : IWarrior 
    {
        public string GetInfo() => "Орк-воїн: Сокира, 150 HP, 25 шкоди.";
    }

    public class OrcArcher : IArcher 
    {
        public string GetInfo() => "Орк-стрілець: Арбалет із грубими болтами, 100 HP, 15 шкоди.";
    }

    public class OrcMage : IMage 
    {
        public string GetInfo() => "Орк-шаман: Магія крові та тотемів, 80 HP, 30 шкоди.";
    }

    // --- Конкретні продукти: Ельфи ---
    public class ElfWarrior : IWarrior 
    {
        public string GetInfo() => "Ельф-страж: Рапіра, 100 HP, 20 шкоди.";
    }

    public class ElfArcher : IArcher 
    {
        public string GetInfo() => "Ельф-стрілець: Довгий лук, 80 HP, 25 шкоди.";
    }

    public class ElfMage : IMage 
    {
        public string GetInfo() => "Ельф-чарівник: Заклинання світла та стихій, 70 HP, 40 шкоди.";
    }

    // --- Абстрактна фабрика ---
    public interface IAbstractFactory
    {
        IWarrior CreateWarrior();
        IArcher CreateArcher();
        IMage CreateMage();
    }

    // --- Конкретні фабрики ---
    public class OrcFactory : IAbstractFactory
    {
        public IWarrior CreateWarrior() => new OrcWarrior();
        public IArcher CreateArcher() => new OrcArcher();
        public IMage CreateMage() => new OrcMage();
    }

    public class ElfFactory : IAbstractFactory
    {
        public IWarrior CreateWarrior() => new ElfWarrior();
        public IArcher CreateArcher() => new ElfArcher();
        public IMage CreateMage() => new ElfMage();
    }
    
    class Program
    {
        static void CreateArmy(IAbstractFactory factory)
        {
            IWarrior warrior = factory.CreateWarrior();
            IArcher archer = factory.CreateArcher();
            IMage mage = factory.CreateMage();

            Console.WriteLine("--- Склад нової армії ---");
            Console.WriteLine(warrior.GetInfo());
            Console.WriteLine(archer.GetInfo());
            Console.WriteLine(mage.GetInfo());
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Сбор орды:");
            CreateArmy(new OrcFactory());

            Console.WriteLine("Сбор эльфийского союза:");
            CreateArmy(new ElfFactory());
        }
    }
}
