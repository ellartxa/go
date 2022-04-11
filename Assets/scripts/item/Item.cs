using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "item")]
public class Item : ScriptableObject
{
    public string objectname;//商店用，在游戏中显示给玩家
    public Sprite sprite;//存储对精灵的引用，便于显示
    public int quantity; //数量
    public int addquanity;//增加量
    public bool stackable;//判断是否可堆叠
    public enum ItemType//（物品类型）枚举，不会显示给玩家
    { 
      COIN,
      HEALTHY,
      MP,
      flame,
      water
    }

    public ItemType itemType;//创建
}
