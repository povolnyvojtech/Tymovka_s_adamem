public class Job
{
    public string JobType;
    public int JobTime;
    public int JobMoney;
    public int JobXp;

    // KONSTRUKTOR - volá se při vytváření nového Jobu (new Job(...))
    public Job(string type, int time, int money, int xp)
    {
        JobType = type;
        JobTime = time;
        JobMoney = money;
        JobXp = xp;
    }
}