using System;
using TMPro;
using UnityEngine;

namespace Works.KWJ._01_Scripts
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] private Player player;
        
        [SerializeField] private TextMeshProUGUI playerMoney;
        [SerializeField] private TextMeshProUGUI playerHunger;

        private void Awake()
        {
            //Cursor.visible = false;
        }

        private void Update()
        {
            playerMoney.text = "$" +player.PlayerMoney.CurrentMoney ;
            playerHunger.text = "허기 " +player.PlayerHunger.CurrentHunger + "%";
        }
    }
}