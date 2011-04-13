﻿using System;
using EsriDE.Trials.CastleWindsor.ComplexUI.Forms;

namespace EsriDE.Trials.CastleWindsor.ComplexUI.AA
{
	public interface IToggleFormVisibilityModel
	{
		VisibilityState VisibilityState { get; }

		void ToggleVisibility();
		event Action<VisibilityState> VisibilityChanged;
	}
}