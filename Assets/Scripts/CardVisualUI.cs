using FriskyElephant.Cards;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardVisualUI : MonoBehaviour {
  // Eventually CardData will come from `Init` function not Editor
  [SerializeField]
  private Card CardData;

  [SerializeField]
  private Image CardArtRenderer;
  [SerializeField]
  private TextMeshProUGUI CardName;
  [SerializeField]
  private TextMeshProUGUI CardDescription;
  [SerializeField]
  private TextMeshProUGUI CardCost;

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
