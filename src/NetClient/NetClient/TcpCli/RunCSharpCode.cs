using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Reflection;
using Microsoft.CSharp;

namespace NetServer.TcpServer {
	class RunCSharpCode {

		public static string RunCode(string path) {

			CSharpCodeProvider provider = new CSharpCodeProvider();
			CompilerParameters parameters = new CompilerParameters();

			string code = string.Empty;
			StreamReader sr = new StreamReader(path);
			code = sr.ReadToEnd();
			sr.Close();

			parameters.GenerateExecutable = false;
			parameters.GenerateInMemory = true;
			try {
				
				CompilerResults result = provider.CompileAssemblyFromSource(parameters, code);
				if (result.Errors.Count > 0) {
					return "Compile Fail";
				}
				
				Assembly assembly = result.CompiledAssembly;
				object obj = assembly.CreateInstance("ns.RunClass");
				Type type = assembly.GetType("ns.RunClass");
				
				MethodInfo method = type.GetMethod("Run");
				string iResult = Convert.ToString(method.Invoke(obj, null));
				return iResult;
			}
			catch (System.NotImplementedException ex) {
				return ex.Message;
			}
			catch (System.ArgumentException ex) {
				return ex.Message;
			}
			catch (Exception ex) {
				return ex.Message;
			}
		}
	}
}
