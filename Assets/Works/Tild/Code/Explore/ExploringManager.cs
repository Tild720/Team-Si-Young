using System.Collections.Generic;
using Core.Scripts;
using DG.Tweening;
using Tild.Chat;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExploringManager : MonoSingleton<ExploringManager>
{
    [SerializeField] private Image brightFade;
    [SerializeField] private Image blackFade;
    [SerializeField] private GameObject messenger;
    [SerializeField] private List<ChatSO> chats;
    [SerializeField] private RectTransform profile;
    [SerializeField] private Image profileImage;
    [SerializeField] private TMP_Text profileName;
    [SerializeField] private TMP_Text profileDescription;
    [SerializeField] private GameObject explorer;
    private int index = -1;
    private ChatSO currentChatSO;

    public void FailExplore()
    {
        index--;
    }
    public void Exploring()
    {
        index++;
        currentChatSO = chats[index];
        brightFade.DOFade(1f, 0.2f).OnComplete(() =>
        {
            profileImage.sprite = currentChatSO.chatInfo.image;
            profileName.text = currentChatSO.chatInfo.name;
            profileDescription.text = currentChatSO.chatInfo.desc;
            
            brightFade.DOFade(0f, 0.2f);
            blackFade.DOFade(1f, 0.2f).OnComplete(() =>
            {
                
                profile.DOScale(1f, 0.2f).OnComplete(() =>
                {
                    explorer.SetActive(false);
                    messenger.SetActive(true);
                    profile.DOScale(0f, 0.1f).SetDelay(4f);
                    blackFade.DOFade(0f, 0.05f).SetDelay(4f).OnComplete(() =>
                    {
                        ChatManager.Instance.StartChat(currentChatSO.chatInfo);
                    });
                });
                
            });
        });
    }
}
