using System;
using MonoDevelop.Ide.Gui.Dialogs;
using Gtk;
using MonoDevelop.Core;

namespace SpecialCopy
{
	public class SpecialCopyPanel :OptionsPanel
	{
		SpecialCopyWidget widget;


		public override MonoDevelop.Components.Control CreatePanelWidget ()
		{
			widget = new SpecialCopyWidget ();
			widget.UsePascalCasing = PropertyList.UsePascalCase;
			widget.UseProperties = PropertyList.UseProperties;
			widget.InternalClass = PropertyList.InternalClass;

			return widget;
		}

		public override void ApplyChanges ()
		{
			PropertyList.UsePascalCase = widget.UsePascalCasing;
			PropertyList.UseProperties = widget.UseProperties;
			PropertyList.InternalClass = widget.InternalClass;

			Console.WriteLine ("Apply Changes: {0}", widget);
		}
	}

	class SpecialCopyWidget:VBox
	{
		VBox vbox5;
		Label _memberGeneration;
		RadioButton _properties;
		RadioButton _fields;
		VBox vbox7;
		Label _visibility;
		RadioButton _internal;
		RadioButton _public;
		CheckButton _casing;

		public bool UsePascalCasing {
			get {
				return _casing.Active;
			}set {
				_casing.Active = value;
			}
		}

		public bool UseProperties {
			get { 
				return _properties.Active;
			}
			set { 
				if (value) {
					_properties.Active = true;
					_fields.Active = false;

				} else {
					_properties.Active = false;
					_fields.Active = true;
				}
			}
		}

		public bool InternalClass {
			get { 
				return _internal.Active;
			}
			set { 
				if (value) {
					_internal.Active = true;
					_public.Active = false;
				} else {

					_internal.Active = false;
					_public.Active = true;
				}
			}
		}

		public SpecialCopyWidget () : base (false, 6)
		{
			this.vbox5 = new global::Gtk.VBox ();
			this.vbox5.Name = "vbox5";
			this.vbox5.Spacing = 6;
			// Container child vbox5.Gtk.Box+BoxChild
			this._memberGeneration = new global::Gtk.Label ();
			this._memberGeneration.Name = "_memberGeneration";
			this._memberGeneration.Ypad = 2;
			this._memberGeneration.Xalign = 0F;
			this._memberGeneration.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Members generation:</b>");
			this._memberGeneration.UseMarkup = true;
			this.vbox5.Add (this._memberGeneration);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this._memberGeneration]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this._properties = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Properties"));
			this._properties.CanFocus = true;
			this._properties.Name = "_properties";
			this._properties.DrawIndicator = true;
			this._properties.UseUnderline = true;
			this._properties.Group = new global::GLib.SList (global::System.IntPtr.Zero);
			this.vbox5.Add (this._properties);
			global::Gtk.Box.BoxChild w2 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this._properties]));
			w2.Position = 1;
			w2.Expand = false;
			w2.Fill = false;
			// Container child vbox5.Gtk.Box+BoxChild
			this._fields = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Fields"));
			this._fields.CanFocus = true;
			this._fields.Name = "_fields";
			this._fields.DrawIndicator = true;
			this._fields.UseUnderline = true;
			this._fields.Group = this._properties.Group;
			this.vbox5.Add (this._fields);
			global::Gtk.Box.BoxChild w3 = ((global::Gtk.Box.BoxChild)(this.vbox5 [this._fields]));
			w3.Position = 2;
			w3.Expand = false;
			w3.Fill = false;
			this.Add (this.vbox5);
			global::Gtk.Box.BoxChild w4 = ((global::Gtk.Box.BoxChild)(this [this.vbox5]));
			w4.Position = 0;
			w4.Expand = false;
			w4.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this.vbox7 = new global::Gtk.VBox ();
			this.vbox7.Name = "vbox7";
			this.vbox7.Spacing = 6;
			// Container child vbox7.Gtk.Box+BoxChild
			this._visibility = new global::Gtk.Label ();
			this._visibility.Name = "_visibility";
			this._visibility.Ypad = 2;
			this._visibility.Xalign = 0F;
			this._visibility.LabelProp = global::Mono.Unix.Catalog.GetString ("<b>Visibility:</b>");
			this._visibility.UseMarkup = true;
			this.vbox7.Add (this._visibility);
			global::Gtk.Box.BoxChild w5 = ((global::Gtk.Box.BoxChild)(this.vbox7 [this._visibility]));
			w5.Position = 0;
			w5.Expand = false;
			w5.Fill = false;
			// Container child vbox7.Gtk.Box+BoxChild
			this._internal = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Internal"));
			this._internal.CanFocus = true;
			this._internal.Name = "_internal";
			this._internal.DrawIndicator = true;
			this._internal.UseUnderline = true;
			this._internal.Group = new global::GLib.SList (global::System.IntPtr.Zero);
			this.vbox7.Add (this._internal);
			global::Gtk.Box.BoxChild w6 = ((global::Gtk.Box.BoxChild)(this.vbox7 [this._internal]));
			w6.Position = 1;
			w6.Expand = false;
			w6.Fill = false;
			// Container child vbox7.Gtk.Box+BoxChild
			this._public = new global::Gtk.RadioButton (global::Mono.Unix.Catalog.GetString ("Public"));
			this._public.CanFocus = true;
			this._public.Name = "_public";
			this._public.DrawIndicator = true;
			this._public.UseUnderline = true;
			this._public.Group = this._internal.Group;
			this.vbox7.Add (this._public);
			global::Gtk.Box.BoxChild w7 = ((global::Gtk.Box.BoxChild)(this.vbox7 [this._public]));
			w7.Position = 2;
			w7.Expand = false;
			w7.Fill = false;
			this.Add (this.vbox7);
			global::Gtk.Box.BoxChild w8 = ((global::Gtk.Box.BoxChild)(this [this.vbox7]));
			w8.Position = 1;
			w8.Expand = false;
			w8.Fill = false;
			// Container child vbox3.Gtk.Box+BoxChild
			this._casing = new global::Gtk.CheckButton ();
			this._casing.CanFocus = true;
			this._casing.Name = "_casing";
			this._casing.Label = global::Mono.Unix.Catalog.GetString ("Convert to PascalCase");
			this._casing.DrawIndicator = true;
			this._casing.UseUnderline = true;
			this.Add (this._casing);
			global::Gtk.Box.BoxChild w9 = ((global::Gtk.Box.BoxChild)(this [this._casing]));
			w9.Position = 2;
			w9.Expand = false;
			w9.Fill = false;

			ShowAll ();
		}
		
	}
}

