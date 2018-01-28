<<<<<<< HEAD
﻿using System;
using UnityEngine;
using UnityEngine.UI;

public class TrackInventory : MonoBehaviour {

    public bool[] itemList = { false, false, false, false, false };
    public Text itemCountText;
    private int collectedItemIndex;
	
	// Update is called once per frame
	void Update ()
    {
        collectedItemIndex = Array.IndexOf(itemList, false);
        collectedItemIndex = collectedItemIndex == -1 ? 5 : collectedItemIndex;
        itemCountText.text = $"{collectedItemIndex}/5";
    }

    public void UpdateItemList()
    {
        // Find the first false instance
        itemList[collectedItemIndex] = true;
    }
}
=======
﻿using System;
using UnityEngine;
using UnityEngine.UI;

public class TrackInventory : MonoBehaviour {

    public bool[] itemList = { false, false, false, false, false };
    public Text itemCountText;
    private int collectedItemIndex;
	
	// Update is called once per frame
	void Update ()
    {
        collectedItemIndex = Array.IndexOf(itemList, false);
        collectedItemIndex = collectedItemIndex == -1 ? 5 : collectedItemIndex;
        itemCountText.text = $"{collectedItemIndex}/5";
    }

    public void UpdateItemList()
    {
        // Find the first false instance
        itemList[collectedItemIndex] = true;
    }
}
>>>>>>> 71885fb52ff3319233a602f79583b8511c833091
