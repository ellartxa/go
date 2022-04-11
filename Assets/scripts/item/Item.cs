using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "item")]
public class Item : ScriptableObject
{
    public string objectname;//�̵��ã�����Ϸ����ʾ�����
    public Sprite sprite;//�洢�Ծ�������ã�������ʾ
    public int quantity; //����
    public int addquanity;//������
    public bool stackable;//�ж��Ƿ�ɶѵ�
    public enum ItemType//����Ʒ���ͣ�ö�٣�������ʾ�����
    { 
      COIN,
      HEALTHY,
      MP,
      flame,
      water
    }

    public ItemType itemType;//����
}
