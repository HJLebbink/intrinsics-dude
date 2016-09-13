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
using System.IO;
using System.Collections.Generic;
using Microsoft.VisualStudio.Shell;
using Amib.Threading;

namespace IntrinsicsDude.Tools
{
    public sealed class IntrinsicsDudeTools : IDisposable
    {
        private readonly ErrorListProvider _errorListProvider;
        private readonly IntrinsicStore _intrinsicStore;
        private readonly SmartThreadPool _smartThreadPool;
        private readonly StatementCompletionStore _statement_Completion_Store;

        #region Singleton Stuff
        private static readonly Lazy<IntrinsicsDudeTools> lazy = new Lazy<IntrinsicsDudeTools>(() => new IntrinsicsDudeTools());
        public static IntrinsicsDudeTools Instance {
            get {
                IntrinsicsDudeTools intrinsicsDudeTools = lazy.Value;
                intrinsicsDudeTools.init();
                return intrinsicsDudeTools;
            }
        }
        #endregion Singleton Stuff


        /// <summary>
        /// Singleton pattern: use IntrinsicsDudeTools.Instance for the instance of this class
        /// </summary>
        private IntrinsicsDudeTools()
        {
            //IntrinsicsDudeToolsStatic.Output(string.Format("INFO: IntrinsicsDudeTools constructor"));

            #region Initialize ErrorListProvider
            if (false)
            {
                IServiceProvider serviceProvider = new ServiceProvider(Package.GetGlobalService(typeof(Microsoft.VisualStudio.OLE.Interop.IServiceProvider)) as Microsoft.VisualStudio.OLE.Interop.IServiceProvider);
                this._errorListProvider = new ErrorListProvider(serviceProvider);
                this._errorListProvider.ProviderName = "Intrinsics Errors";
                this._errorListProvider.ProviderGuid = new Guid(EnvDTE.Constants.vsViewKindCode);
            }
            #endregion

            #region Start thread pool
            this._smartThreadPool = new SmartThreadPool();
            this._smartThreadPool.MaxThreads = 4;
            this._smartThreadPool.Start();
            #endregion

            #region load intrinsic store
            string path = IntrinsicsDudeToolsStatic.getInstallPath() + "Resources" + Path.DirectorySeparatorChar;
            string filename_intrinsics = path + "Intrinsics-Data.xml";
            this._intrinsicStore = new IntrinsicStore(filename_intrinsics);
            #endregion

            this._statement_Completion_Store = new StatementCompletionStore(this._intrinsicStore);
        }

        private void init()
        {
            //TODO move initialization stuff from constructor to here
        }


        #region Public Methods

        public ErrorListProvider errorListProvider { get { return this._errorListProvider; } }

        public IntrinsicStore intrinsicStore { get { return this._intrinsicStore; } }

        public StatementCompletionStore statementCompletionStore {  get { return this._statement_Completion_Store; } }

        public SmartThreadPool threadPool { get { return this._smartThreadPool; } }

        /// <summary>
        /// get url for the provided keyword. Returns empty string if the keyword does not exist or the keyword does not have an url.
        /// </summary>
        public string getUrl(string keyword)
        {
            try
            {
                Intrinsic mnemonic = IntrinsicTools.parseIntrinsic(keyword, false);
                if (mnemonic != Intrinsic.NONE)
                {
                    IList<IntrinsicDataElement> dataElements = this._intrinsicStore.get(mnemonic);
                    if (dataElements.Count > 0)
                    {
                        string url = "https://software.intel.com/sites/landingpage/IntrinsicsGuide/#expand=" + dataElements[0].id;
                        IntrinsicsDudeToolsStatic.Output(string.Format("INFO: {0}:getUrl: keyword {1}; url {2}.", this.ToString(), keyword, url));
                        return url;
                    }
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