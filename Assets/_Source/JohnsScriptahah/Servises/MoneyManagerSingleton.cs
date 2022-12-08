
public class MoneyManagerSingleton
{
    private static MoneyManagerSingleton _instance;
    public static MoneyManagerSingleton Instance
    {
        get
        {
            if (_instance == null)
                _instance = new MoneyManagerSingleton();

            return _instance;
        }
    }

    private int _coinCount;

    public void AddCoins(int count)
    {
        _coinCount += count;
    }

    public bool TrySpendCoins(int count)
    {
        if (count < _coinCount)
            _coinCount -= count;
        return (count < _coinCount);
    }
}