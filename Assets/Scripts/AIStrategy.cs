using UnityEngine;

public class AIStrategy : IPlayerStrategy
{
    public void MakeMove()
    {
        for (int i = 0; i < 9; i++)
        {
            int randomIndex = Random.Range(0, 9);
            if (GameManager.Instance.IsCellEmpty(randomIndex))
            {
                GameManager.Instance.OnGridClick(randomIndex);
                break;
            }
        }
    }
}
