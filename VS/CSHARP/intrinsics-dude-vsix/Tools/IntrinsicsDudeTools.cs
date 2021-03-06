// The MIT License (MIT)
//
// Copyright (c) 2021 Henk-Jan Lebbink
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

namespace IntrinsicsDude.Tools
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Amib.Threading;
    using Microsoft.VisualStudio.Shell;

    public sealed class IntrinsicsDudeTools : IDisposable
    {
        private ErrorListProvider _errorListProvider;
        private IntrinsicStore _intrinsicStore;
        private StatementCompletionStore _statement_Completion_Store;

        #region Singleton Stuff
        private static IntrinsicsDudeTools instance = null;
        private static readonly object padlock = new object();

        public static IntrinsicsDudeTools Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        DateTime startTime = DateTime.Now;
                        IntrinsicsDudeToolsStatic.Output_INFO("IntrinsicsDudeTools.Instance: going to create singleton IntrinsicsDudeTools");
                        instance = new IntrinsicsDudeTools();
                        instance.InitAsync().ConfigureAwait(true);

                        double elapsedSec = (double)(DateTime.Now.Ticks - startTime.Ticks) / 10000000;
                        IntrinsicsDudeToolsStatic.OutputAsync(string.Format("INFO: Done creating singleton IntrinsicsDudeTools. Took {0:F3} seconds to load {1} intrinsic definitions.", elapsedSec, instance.IntrinsicStore.Data.Count)).ConfigureAwait(true);
                    }

                    return instance;
                }
            }
        }
        #endregion Singleton Stuff

        /// <summary>
        /// Singleton pattern: use IntrinsicsDudeTools.Instance for the instance of this class
        /// </summary>
        private IntrinsicsDudeTools()
        {
            IntrinsicsDudeToolsStatic.Output_INFO(string.Format("{0}:constructor", this.ToString()));
        }

        private async System.Threading.Tasks.Task InitAsync()
        {
            IntrinsicsDudeToolsStatic.Output_INFO(string.Format("{0}:InitAsync", this.ToString()));

            if (!ThreadHelper.CheckAccess())
            {
                await ThreadHelper.JoinableTaskFactory.SwitchToMainThreadAsync();
            }

            #region Initialize ErrorListProvider
            if (false) // not used
            {
                IServiceProvider serviceProvider = new ServiceProvider(Package.GetGlobalService(typeof(Microsoft.VisualStudio.OLE.Interop.IServiceProvider)) as Microsoft.VisualStudio.OLE.Interop.IServiceProvider);
                this._errorListProvider = new ErrorListProvider(serviceProvider)
                {
                    ProviderName = "Intrinsics Errors",
                    ProviderGuid = new Guid(EnvDTE.Constants.vsViewKindCode),
                };
            }
            #endregion

            #region Start thread pool
            this.ThreadPool = new SmartThreadPool()
            {
                MaxThreads = 4,
            };
            this.ThreadPool.Start();
            #endregion

            #region load intrinsic store
            string path = IntrinsicsDudeToolsStatic.GetInstallPath() + "Resources" + Path.DirectorySeparatorChar;
            {
                string filename_intrinsics = path + "Intrinsics-Data.xml";
                this._intrinsicStore = new IntrinsicStore(filename_intrinsics);
            }
            #endregion

            this._statement_Completion_Store = new StatementCompletionStore(this._intrinsicStore);
        }

        #region Public Methods

        public ErrorListProvider ErrorListProvider { get { return this._errorListProvider; } }

        public IntrinsicStore IntrinsicStore { get { return this._intrinsicStore; } }

        public StatementCompletionStore StatementCompletionStore { get { return this._statement_Completion_Store; } }

        public SmartThreadPool ThreadPool { get; private set; }

        /// <summary>
        /// get url for the provided keyword. Returns empty string if the keyword does not exist or the keyword does not have an url.
        /// </summary>
        public string GetUrl(string keyword)
        {
            try
            {
                bool is_capitals = false;
                bool warn = false;
                Intrinsic mnemonic = IntrinsicTools.ParseIntrinsic(keyword, is_capitals, warn);
                if (mnemonic != Intrinsic.NONE)
                {
                    IList<IntrinsicDataElement> dataElements = this._intrinsicStore.Get(mnemonic);
                    if (dataElements.Count > 0)
                    {
                        string url = "https://software.intel.com/sites/landingpage/IntrinsicsGuide/#expand=" + dataElements[0]._id;
                        IntrinsicsDudeToolsStatic.Output_INFO(string.Format("{0}:getUrl: keyword {1}; url {2}.", this.ToString(), keyword, url));
                        return url;
                    }
                }
                return string.Empty;
            }
            catch (Exception e)
            {
                IntrinsicsDudeToolsStatic.Output_ERROR(string.Format("{0}:GetUrl; e={1}", this.ToString(), e.ToString()));
                return string.Empty;
            }
        }

        #endregion Public Methods

        #region Private Methods

        public void Dispose()
        {
            this._errorListProvider.Dispose();
            this.ThreadPool.Dispose();
        }

        #endregion
    }
}