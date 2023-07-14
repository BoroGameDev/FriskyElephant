using FriskyElephant.Cards;
using UnityEngine;
using TMPro;

public class CardVisual : MonoBehaviour {
  // Eventually CardData will come from `Init` function not Editor
  [SerializeField]
  private Card CardData;

  [SerializeField]
  private SpriteRenderer CardArtRenderer;
  [SerializeField]
  private TextMeshPro CardName;
  [SerializeField]
  private TextMeshPro CardDescription;
  [SerializeField]
  private TextMeshPro CardCost;

  void Start() {
    // Eventually this is called from whatever script handles creating card visuals
    // This is here for testing right now
    Init(CardData); 
  }

  public void Init(Card data) {
    this.SetCard(data);

    CardArtRenderer.sprite = data.GetArt();
    CardName.text = GetCardName();
    CardDescription.text = GetCardDescription();
    CardCost.text = GetCardCostText();
  }

  public void SetCard(Card data) => this.CardData = data;

  public string GetCardName() => this.CardData.GetName();
  public string GetCardDescription() => this.CardData.Description;
  public int GetCardCost() => this.CardData.GetCost();
  public string GetCardCostText() => $"{GetCardCost()}";
}
