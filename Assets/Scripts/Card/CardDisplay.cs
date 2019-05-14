using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour {

    public Card card;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;

    public Image fgArt;
    public Image bgArt;

    public TextMeshProUGUI range;
    public TextMeshProUGUI damage;

	// Use this for initialization
	void OnEnable () {
        nameText.text = card.cardName;
        descriptionText.text = card.description;

        fgArt.sprite = card.fgArtwork;
        bgArt.sprite = card.bgArtwork;

        range.text = card.range.ToString(); 
        damage.text = card.damage.ToString();
	}
	
	public void ChangeCard(Card _card)
    {
        card = _card;
        OnEnable();
    }
}
