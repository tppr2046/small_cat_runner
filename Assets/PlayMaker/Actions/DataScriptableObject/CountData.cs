using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{

	[ActionCategory("DataScriptableObject")]
	public class CountData : FsmStateAction
	{

		[ObjectType(typeof(DataScriptableObject))]
		public FsmObject ItemReference;

		[UIHint(UIHint.Variable)]
		[Tooltip("Data Count")]
		public FsmInt dataCount;

		public override void OnEnter()
		{
			var Item = ItemReference.Value;
			DataScriptableObject ourItem = Item as DataScriptableObject;
			dataCount.Value = ourItem.countingdata.Count;

			Finish();
		}


	}

}
