using UnityEngine;

public class BattleController : MonoBehaviour
{
    public void Fight()
    {
        foreach(var entity in GameController.contexts.game.GetEntities())
        {
            if(entity.isFightingEnemy)
            {
                entity.isFight = true;
            }
        }
    }
    public void Bribe()
    {
        int score = int.Parse(GameController.contexts.game.globalVariables.value.ScoreText.text);
        if (score >= 1)
        {
            score--;
            GameController.contexts.game.globalVariables.value.ScoreText.text = score.ToString();
            foreach (var entity in GameController.contexts.game.GetEntities())
            {
                if (entity.isFightingEnemy)
                {
                    entity.isBribe = true;
                }
            }

            GetComponent<Animator>().SetTrigger("FadeOut");
            GameController.contexts.game.globalVariables.value.Player.GetComponent<Animator>().SetTrigger("ShieldAttack");
        }
    }
}
