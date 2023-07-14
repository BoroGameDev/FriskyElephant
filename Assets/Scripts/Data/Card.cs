using System.Collections.Generic;
using UnityEngine;

namespace FriskyElephant.Cards {
  [CreateAssetMenu(menuName = "Cards/New Card")]
  public class Card : ScriptableObject {
    [Header("Card Info")]
    [SerializeField]
    private string Name;
    [SerializeField]
    private int Cost;
    [SerializeField]
    private bool IsUpgraded;
    [SerializeField]
    private Card UpgradesTo;

    [Header("Card Sprites")]
    [SerializeField]
    private Sprite Art;

    [SerializeField]
    private List<Effect> Effects;

    public string GetName() => this.Name;
    public int GetCost() => this.Cost;
    public Sprite GetArt() => this.Art;

    public string Description {
      get {
        var output = "";

        foreach(Effect eff in Effects) {
          output += eff;
        }

        return output;
      }
    }
  }
}
