/* Shellify Copyright (c) 2010-2019 Sebastien Lebreton

Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE. */

using System;
using System.IO;

namespace Shellify.Tool.Commands
{
	public class CreateAbsoluteCommand : Command
	{
		public CreateAbsoluteCommand(string tag, string description)
			: base(tag, description, 2)
		{
		}

		protected static void CheckExists(string target, string filename)
		{
			if (!File.Exists(target) && !Directory.Exists(target))
				Console.WriteLine("WARN: {0} doesn't exist", target);
			else
				Console.WriteLine("{0} => {1}", filename, target);
		}

		public override void Execute()
		{
			Context = ShellLinkFile.CreateAbsolute(Target);
			foreach (var option in Options) option.Execute(Context);
			Context.SaveAs(Filename);
			CheckExists(Target, Filename);
		}
	}
}