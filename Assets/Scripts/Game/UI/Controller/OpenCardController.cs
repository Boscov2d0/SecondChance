using SecondChanse.Game.Data;
using SecondChanse.Game.UI.View;
using SecondChanse.Tools;
using System;
using UnityEngine;

using static SecondChanse.Game.Tools.States;

namespace SecondChanse.Game.UI.Controller
{
    public class OpenCardController : ObjectsDisposer
    {
        public Action OnReadCard;

        public OpenCardController(GameManager gameManager, UIManager uiManager, CardsSpriteManager cardsSpriteManager, Transform place, int cardIndex) 
        {
            OpenCardView openCard = ResourcesLoader.InstantiateAndGetObject<OpenCardView>(uiManager.UIObjectsPath + uiManager.OpenCardPath, place);
            AddGameObject(openCard.gameObject);
            openCard.Initialize(cardsSpriteManager, ReadCard, cardIndex);
            gameManager.GameState.Value = GameState.ReadStory;
            ReadCard();
        }
        private void ReadCard() 
        {
            OnReadCard?.Invoke();
        }
    }
}