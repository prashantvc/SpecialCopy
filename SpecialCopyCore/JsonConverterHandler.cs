using MonoDevelop.Components.Commands;
using System;
using MonoDevelop.Ide;
using Mono.TextEditor;
using MonoDevelop.Ide.Gui;
using Gtk;
using Xamasoft.JsonClassGenerator;
using Xamasoft.JsonClassGenerator.CodeWriters;
using System.IO;

namespace SpecialCopy.JsonConverter
{
	class JsonConverterHandler : CommandHandler
	{
		void PasteJson (Clipboard c, string text)
		{
			if (string.IsNullOrEmpty (text)) {
				InsertCSharp (string.Empty);

				#if DEBUG
				MessageService.ShowWarning ("Clipboard is empty!");
				#endif

				return;
			}

			var gen = new JsonClassGenerator { 
				Example = text, 
				MainClass = "RootObject",
				CodeWriter = new CSharpCodeWriter () 
			};

			try {
				using (var sw = new StringWriter ()) {
					gen.UsePascalCase = PropertyList.UsePascalCase;
					gen.InternalVisibility = PropertyList.InternalClass;
					gen.UseProperties = PropertyList.UseProperties;

					gen.OutputStream = sw;
					gen.GenerateClasses ();
					sw.Flush ();
					var generatedString = sw.ToString ();
					InsertCSharp (generatedString);
				}
			} catch (Exception ex) {
				Console.WriteLine (ex.Message);
				MessageService.ShowWarning (string.Format ("Invalid JSON: {0}", ex.Message));
			}

			gen = null;
		}

		void InsertCSharp (string text)
		{
			var doc = IdeApp.Workbench.ActiveDocument;
			var textEditorData = doc.GetContent<ITextEditorDataProvider> ().GetTextEditorData ();

			textEditorData.InsertAtCaret (text);
		}

		protected override void Run ()
		{
			var clipboard = Clipboard.Get (Gdk.Selection.Clipboard);
			clipboard.RequestText (PasteJson);
		}

		protected override void Update (CommandInfo info)
		{
			var doc = IdeApp.Workbench.ActiveDocument;
			info.Enabled = doc != null && doc.GetContent<ITextEditorDataProvider> () != null;
		}
	}

	public enum JsonConverterCommand
	{
		PasteJson
	}
}