using System;
using UnityEngine;

namespace FriskyElephant.Cards {
  public abstract class Effect : ScriptableObject {
    public event EventHandler OnEffectCompleted;

    public string GetDescription() => ToString();

    public virtual void Invoke() {
      OnEffectCompleted?.Invoke(this, EventArgs.Empty);
    }
  }
}
