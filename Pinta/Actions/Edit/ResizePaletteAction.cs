﻿// 
// ResizePaletteAction.cs
//  
// Author:
//       Jonathan Pobst <monkey@jpobst.com>
// 
// Copyright (c) 2010 Jonathan Pobst
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using Gtk;
using Mono.Unix;
using Pinta.Core;

namespace Pinta.Actions
{
	class ResizePaletteAction : IActionHandler
	{
		#region IActionHandler Members
		public void Initialize ()
		{
			PintaCore.Actions.Edit.ResizePalette.Activated += Activated;
		}

		public void Uninitialize ()
		{
			PintaCore.Actions.Edit.ResizePalette.Activated -= Activated;
		}
		#endregion

		private void Activated (object sender, EventArgs e)
		{
			SpinButtonEntryDialog dialog = new SpinButtonEntryDialog (Translations.GetString ("Resize Palette"),
					PintaCore.Chrome.MainWindow, Translations.GetString ("New palette size:"), 1, 96,
					PintaCore.Palette.CurrentPalette.Count);

			if (dialog.Run () == (int)ResponseType.Ok) {
				PintaCore.Palette.CurrentPalette.Resize (dialog.GetValue ());
			}

			dialog.Destroy ();
		}
	}
}
