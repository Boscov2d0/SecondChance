using UnityEngine;

namespace SecondChanse.Game.Data
{
    [CreateAssetMenu(fileName = nameof(CardsSpriteManager), menuName = "Managers/Game/CardsImageManager")]
    public class CardsSpriteManager : ScriptableObject
    {
        [field: SerializeField] public Sprite CloseCardSpirte { get; private set; }
        [field: SerializeField] public Sprite OpenCardSpirte { get; private set; }
        [field: SerializeField] public Sprite StoryCardSpirte { get; private set; }
        [field: SerializeField] public Sprite CloseStoryCardButtonSpirte { get; private set; }
        [field: SerializeField] public Sprite VeryBadEndSprite { get; private set; }
        [field: SerializeField] public Sprite BadEndSprite { get; private set; }
        [field: SerializeField] public Sprite NoChangeEndSprite { get; private set; }
        [field: SerializeField] public Sprite NormalEndSprite { get; private set; }
        [field: SerializeField] public Sprite GoodEndSprite { get; private set; }
        [field: SerializeField] public Sprite VeryGoodEndSprite { get; private set; }
        [field: SerializeField] public Sprite FullStorySprite { get; private set; }
        [field: SerializeField] public Sprite ImportantDecisionsSprite { get; private set; }

        [field: SerializeField] public Color VeryBadEndColor { get; private set; }
        [field: SerializeField] public Color BadEndColor { get; private set; }
        [field: SerializeField] public Color NoChangeEndColor { get; private set; }
        [field: SerializeField] public Color NormalEndColor { get; private set; }
        [field: SerializeField] public Color GoodEndColor { get; private set; }
        [field: SerializeField] public Color VeryGoodEndColor { get; private set; }
    }
}