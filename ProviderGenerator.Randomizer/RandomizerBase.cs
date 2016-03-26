﻿/*
 * Copyright 2016-2016 Mohawk College of Applied Arts and Technology
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"); you 
 * may not use this file except in compliance with the License. You may 
 * obtain a copy of the License at 
 * 
 * http://www.apache.org/licenses/LICENSE-2.0 
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the 
 * License for the specific language governing permissions and limitations under 
 * the License.
 * 
 * User: Nityan
 * Date: 2016-3-26
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace ProviderGenerator.Randomizer
{
	public abstract class RandomizerBase<T> where T : class
	{
		protected virtual T LoadData(string filename)
		{
			string fn = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), filename);
			FileStream fs = null;
			try
			{
				fs = File.OpenRead(fn);
				XmlSerializer xsz = new XmlSerializer(typeof(T));
				return xsz.Deserialize(fs) as T;
			}
			finally
			{
				if (fs != null)
				{
					fs.Close();
					fs.Dispose();
				}
			}
		}
	}
}
