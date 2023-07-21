using UnityEngine;

namespace FriskyElephant.Cards {

  [CreateAssetMenu(menuName = "Cards/New Damage Effect")]
  public class DamageEffect : Effect {
    [SerializeField]
    private int DamageAmount;

    public override string ToString() {
      return $"Deal {DamageAmount} Damage";
    }
  }
}
