using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private IPlayerStrategy strategy;

    public void SetStrategy(IPlayerStrategy newStrategy)
    {
        strategy = newStrategy;
    }

    public void MakeMove()
    {
        strategy?.MakeMove();
    }
}
