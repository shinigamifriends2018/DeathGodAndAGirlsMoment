using System.Collections;
using System.Collections.Generic;

public class Common{

    //リストと番号を合わせる

    /// <summary>
    /// BGM List
    /// </summary>
    public enum BGMList
    {
        Title,
        Scenario1,
        Scenario2,
        Stage1,
        Stage2,
        Clear,
        GameOver,
        Boss,
        Ending,
    }

    /// <summary>
    /// SE List
    /// </summary>
    public enum SEList
    {
       EnemySporn,
       EnemyDamage,
       EnemyDestroy,
       NearEnemyAttack,
       FarEnemyAttack,
       DarkMassDestroy,
       BossDisPlay,
       BossKamaitachi,
       BossDamage,
       BossDown,
       Door,
       Swich,
       Cage,
       Select,
       Decison,
       Kaiwa,
       GetPiceofMemori,
       GetHeart,
       DropHeart,
       Goal,
       ShinigamiAttack,
       ShinigamiMove,
       SyoujoMove,
       HandSheck,
    }
    /// <summary>
    /// Voice List
    /// </summary>
    public enum VoiceList
    {
        ShinigamiVoice,
        Syoujoku,
        SyoujoNeenee,
    }
}
