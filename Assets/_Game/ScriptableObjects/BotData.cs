using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "BotData", menuName = "ScriptableObjects/BotData", order = 1)]
public class BotData : ScriptableObject
{
    [SerializeField] private List<BotType> botTypes;

    public List<BotType> BotTypes => botTypes;

    // Định nghĩa một lớp để lưu thông tin về loại bot
    [System.Serializable]
    public class BotType
    {
        public string name;
        public GameObject botPrefab; // Đối tượng GameObject đại diện cho bot
        public int health;
        public int damage;
        // Các thuộc tính khác của bot (ví dụ: speed, armor, ...)
    }
}
