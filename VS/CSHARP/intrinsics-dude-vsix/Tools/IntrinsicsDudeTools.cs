// The MIT License (MIT)
//
// Copyright (c) 2016 Henk-Jan Lebbink
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using System.Diagnostics;
using System.Xml;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Collections.Generic;

using AsmTools;
using Microsoft.VisualStudio.Shell;
// The MIT License (MIT)
//
// Copyright (c) 2016 Henk-Jan Lebbink
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using Amib.Threading;
using static IntrinsicsDude.Tools.IntrinsicTools;

namespace IntrinsicsDude.Tools
{
    public sealed class IntrinsicsDudeTools : IDisposable
    {
        private readonly ErrorListProvider _errorListProvider;
        private readonly IntrinsicStore _intrinsicStore;
        private readonly SmartThreadPool _smartThreadPool;

        #region Singleton Stuff
        private static readonly Lazy<IntrinsicsDudeTools> lazy = new Lazy<IntrinsicsDudeTools>(() => new IntrinsicsDudeTools());
        public static IntrinsicsDudeTools Instance { get { return lazy.Value; } }
        #endregion Singleton Stuff


        /// <summary>
        /// Singleton pattern: use IntrinsicsDudeTools.Instance for the instance of this class
        /// </summary>
        private IntrinsicsDudeTools()
        {
            //IntrinsicsDudeToolsStatic.Output(string.Format("INFO: IntrinsicsDudeTools constructor"));

            #region Initialize ErrorListProvider
            IServiceProvider serviceProvider = new ServiceProvider(Package.GetGlobalService(typeof(Microsoft.VisualStudio.OLE.Interop.IServiceProvider)) as Microsoft.VisualStudio.OLE.Interop.IServiceProvider);
            this._errorListProvider = new ErrorListProvider(serviceProvider);
            this._errorListProvider.ProviderName = "Intrinsics Errors";
            this._errorListProvider.ProviderGuid = new Guid(EnvDTE.Constants.vsViewKindCode);
            #endregion

            this._smartThreadPool = new SmartThreadPool();

            try
            {
                #region load intrinsic store
                string path = IntrinsicsDudeToolsStatic.getInstallPath() + "Resources" + Path.DirectorySeparatorChar;
                string filename_intrinsics = path + "Intel-Intrinsics-Guide.html";
                IntrinsicsDudeToolsStatic.Output("INFO: IntrinsicsDudeTools: constructor: filename " + filename_intrinsics);
                this._intrinsicStore = new IntrinsicStore(filename_intrinsics);
                #endregion
            }
            catch (Exception e)
            {
                IntrinsicsDudeToolsStatic.Output("ERROR: IntrinsicsDudeTools constructor: exception " + e);
            }
        }

        #region Public Methods

        public ErrorListProvider errorListProvider { get { return this._errorListProvider; } }

        public IntrinsicStore intrinsicStore { get { return this._intrinsicStore; } }

        public SmartThreadPool threadPool { get { return this._smartThreadPool; } }

        /// <summary>
        /// get url for the provided keyword. Returns empty string if the keyword does not exist or the keyword does not have an url.
        /// </summary>
        public string getUrl(string keyword)
        {
            // no need to pre-process this information.
            try
            {
                Intrinsic mnemonic = IntrinsicTools.parseIntrinsic(keyword);
                if (mnemonic != Intrinsic.NONE)
                {
                    string url = "https://software.intel.com/sites/landingpage/IntrinsicsGuide/#expand=" + this._intrinsicStore.get(mnemonic).id;
                    //IntrinsicsDudeToolsStatic.Output(string.Format("INFO: {0}:getUrl: keyword {1}; url {2}.", this.ToString(), keyword, url));
                    return url;
                }
                return "";
            }
            catch (Exception e)
            {
                IntrinsicsDudeToolsStatic.Output(string.Format("ERROR: {0}:getUrl: exception {1}.", this.ToString(), e.ToString()));
                return "";
            }
        }

        #endregion Public Methods

        #region Private Methods

        public void Dispose()
        {
            this._errorListProvider.Dispose();
            this._smartThreadPool.Dispose();
        }

        #endregion
    }
}