using System;
using MonoDevelop.Core;

namespace SpecialCopy
{
	public static class PropertyList
	{
		public static bool UsePascalCase {
			get{ return PropertyService.Get<bool> ("SpecialCopy.UsePascalCase"); }
			set{ PropertyService.Set ("SpecialCopy.UsePascalCase", value); }
		}

		public static bool UseProperties {
			get{ return PropertyService.Get<bool> ("SpecialCopy.UseProperties"); }
			set{ PropertyService.Set ("SpecialCopy.UseProperties", value); }
		}

		public static bool InternalClass {
			get{ return PropertyService.Get<bool> ("SpecialCopy.InternalClass"); }
			set{ PropertyService.Set ("SpecialCopy.InternalClass", value); }
		}
	}
}

