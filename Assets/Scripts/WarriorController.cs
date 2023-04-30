

public class WarriorController : PlayerController
{
    public override void Attack()
    {
        base.Attack();
        if (IsAlive && _currentCollDawn <= 0)
        {

        }
    }
}
