/*
Released as open source by NCC Group Plc - http://www.nccgroup.com/

Developed by Ollie Whitehouse, ollie dot whitehouse at nccgroup dot com

http://www.github.com/nccgroup/grepify

Released under AGPL see LICENSE for more information
*/

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Win.Grepify
{

    class ScanParams
    {
        public string strPath = null;
        public string[] strExts = null;

        public ScanParams(string strPath, string[] strExts)
        {
            this.strPath = strPath;
            this.strExts = strExts;
        }
    }

    class FileToScan
    {
        private string strFile = null;
        private frmMain frmMaster = null;
        private string[] strAPIs = null;
        private bool bCase = Properties.Settings.Default.CaseSensitive;
        Scanner engineLocal = null;
        private bool bComments = Properties.Settings.Default.Comments;
        private StringCollection strCommentsRegex = Properties.Settings.Default.CommentsRegex;

        /// <summary>
        /// Checks if a file is binary
        /// </summary>
        /// <returns></returns>
        bool IsBinary(byte[] bytesFile)
        {
            for (int intCount = 0; intCount < bytesFile.Length; intCount++) if (bytesFile[intCount] > 127) return true;

            return false;
        }

        /// <summary>
        /// Scan a particular file
        /// </summary>
        /// <param name="strFile">the file we wish to scan</param>
        /// <param name="strAPIs">an array of regular expressions we've loaded</param>
        /// <returns></returns>
        private bool ScanFile(string strFile)
        {
            if (engineLocal.bStopped == true)
            {
                engineLocal.LowerQueueCount();
                return false;
            }

            try
            {
                frmMaster.UpdateProgess();
                byte[] fileBytes = File.ReadAllBytes(strFile);
                if(IsBinary(fileBytes)){
                    //Console.WriteLine("Skipped " + strFile + " due to being binary");
                    return false;
                }

                string[] strLines = File.ReadAllLines(strFile);
                FileInfo fInfo = new FileInfo(strFile);

                int intCount = 0;

                foreach (string strLine in strLines)
                {
                    intCount++;
                    
                    Match commentregexMatch = null;
                    if (bComments == true)
                    {
                        try
                        {
                            foreach (string strComRegex in strCommentsRegex)
                            {
                                commentregexMatch = Regex.Match(strLine, strComRegex);
                                if (commentregexMatch.Success == true)
                                {
                                    //Console.WriteLine("1!! " + strLine + " - " + strComRegex);
                                    break;
                                }
                            }
                        }
                        catch (Exception)
                        {

                        }
                    }

                    if (bComments != true || commentregexMatch == null || (commentregexMatch != null && commentregexMatch.Success == false))
                    {
                        foreach (string strRegex in strAPIs)
                        {

                            if (engineLocal.bStopped == true)
                            {
                                engineLocal.LowerQueueCount();
                                return false;
                            }

                            try
                            {


                                //Console.WriteLine("[!] " + strLine);                      

                                Match regexMatch = null;
                                if (bCase == true)
                                {
                                    regexMatch = Regex.Match(strLine, strRegex, RegexOptions.IgnoreCase);
                                }
                                else
                                {
                                    regexMatch = Regex.Match(strLine, strRegex);
                                }


                                if (regexMatch != null && regexMatch.Success)
                                {
                                    // Update the GUI   
                                    frmMaster.UpdateList(fInfo.DirectoryName, fInfo.Name, fInfo.Extension, strRegex, intCount, strLine);
                                }
                            }
                            catch (Exception)
                            {
                                //Console.WriteLine(rExp.Message);
                            }
                        }
                    }
                    else
                    {
                        //Console.WriteLine(strLine + " is a comment " + commentregexMatch.Success);
                    }
                }

                fInfo = null;
                strLines = null;
            }
            catch (Exception)
            {

            }
            finally
            {
                //Console.WriteLine("Finally..");
                engineLocal.LowerQueueCount();
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFile"></param>
        public FileToScan(string strFile, Scanner scanEngine)
        {
            this.strAPIs = scanEngine.strAPIs;
            this.strFile = strFile;
            this.frmMaster = scanEngine.frmMaster;
            this.engineLocal = scanEngine;
        }

        // Wrapper method for use with thread pool.
        public void ThreadPoolCallback(Object threadContext)
        {
            if (this.engineLocal.bStopped == true)
            {
                engineLocal.LowerQueueCount();
                return;
            }
            ScanFile(this.strFile);
        }
    }
    class Scanner
    {
        private int intMaxThreads = 10;
        private int intTotalHits = 0;
        private string[] strFiles = null;
        public string[] strAPIs = null;
        public bool bStopped = false;
        private Thread trdEnum = null;
        //private CountdownEvent trdFinished = new CountdownEvent(1);
        public frmMain frmMaster = null;
        static object objQueue = new object();
        static int intQueue;
        private bool bTestFilenames = Properties.Settings.Default.TestFilenames;
        private bool bTestFilepaths = Properties.Settings.Default.TestPath;
        

        /// <summary>
        /// Constructor
        /// </summary>
        public Scanner()
        {

        }

        public void LowerQueueCount(){
            lock (objQueue)
            {
                //Console.WriteLine(intQueue.ToString());
                --intQueue;
                //Monitor.PulseAll(objQueue);
            }
        }

        /// <summary>
        /// Enumerate the files in a given path
        /// </summary>
        /// <param name="strPath"></param>
        private void EnumerateFiles(string strPath, string strExts){
            string strFiles = strExts;
            //Console.WriteLine(strExts);

            try
            {
                foreach (string strFile in Directory.GetFiles(strPath, strFiles))
                {
                    if (bStopped == true) return;

                    if (bTestFilenames == true)
                    {
                        if (Path.GetFileName(strFile).ToLower().Contains("test"))
                        {
                            //Console.WriteLine("Exlcuded " + strFile + " due to test in name");
                            return;
                        }
                    }
                    
                    if (bTestFilepaths == true)
                    {
                        if (Path.GetDirectoryName(strFile).ToLower().Contains("test"))
                        {
                            //Console.WriteLine("Exlcuded " + strFile + " due to test in path");
                            return;
                        }
                    }

                    //Console.WriteLine(strFile);
                    FileToScan file2Scan = new FileToScan(strFile, this);
                    lock (objQueue) intQueue++;
                    //Console.WriteLine(intQueue.ToString());
                    ThreadPool.QueueUserWorkItem(file2Scan.ThreadPoolCallback);
                }

                foreach (string strDir in Directory.GetDirectories(strPath))
                {
                    EnumerateFiles(strDir,strExts);
                }
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                return;
            }
            catch (System.Exception)
            {
                return;
            }

            return;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strObjPath"></param>
        private void ThreadFunction(Object strObjParams)
        {
            //Thread.CurrentThread.Priority = ThreadPriority.BelowNormal;

            try
            {
                ScanParams scanParams = (ScanParams)strObjParams;
                foreach (string strExt in scanParams.strExts)
                {
                    //Console.WriteLine("searching for " + strExt);
                    EnumerateFiles(scanParams.strPath, strExt);
                }

                frmMaster.ScanStopping();

                while (intQueue > 0)
                {
                    //Console.WriteLine(intQueue.ToString());
                    Thread.Sleep(1000);
                }

                
                //Console.WriteLine("Queue empty in main scan");

                frmMaster.ScanStopped();
            }
            catch (ThreadAbortException)
            {
                frmMaster.bScanStopped = true;
                frmMaster.ScanStopping();
                while (intQueue > 0)
                {
                    Console.WriteLine(intQueue.ToString());
                    Thread.Sleep(1000);
                }
                //Console.WriteLine("Queue empty in abort");
                frmMaster.ScanStopped();
            }
        }

        /// <summary>
        /// Enumerate the files in a given path and tell us how many
        /// </summary>
        /// <param name="strPath"></param>
        /// <returns></returns>
        public int TotalFiles(string strPath)
        {
            return strFiles.Count();
        }

        /// <summary>
        /// Start a scan
        /// </summary>
        /// <param name="strAPIs"></param>
        /// <returns></returns>
        public bool Start(string [] strAPIs, string strPath, string[] strExts,frmMain frmMain){
            this.strAPIs = strAPIs;
            this.frmMaster = frmMain;
            ScanParams scanParams = new ScanParams(strPath, strExts);
            ThreadPool.SetMaxThreads(intMaxThreads,intMaxThreads * 2);
            trdEnum = new Thread(this.ThreadFunction);
            trdEnum.IsBackground = true;
            trdEnum.Start(scanParams);
            
            return true;
        }

        /// <summary>
        /// Stop a scan
        /// </summary>
        /// <returns></returns>
        public void Stop()
        {

            if ((trdEnum.ThreadState != ThreadState.Stopped) || (trdEnum.ThreadState != ThreadState.Aborted))
            {
                //trdEnum.Abort();                
                this.bStopped = true;
            }
            return;
        }

        /// <summary>
        /// Return the total number of hits
        /// </summary>
        /// <returns></returns>
        public int GetTotalhits()
        {
            return intTotalHits;
        }

        /// <summary>
        /// Get the maximum number of threads
        /// </summary>
        /// <returns></returns>
        public int GetMaxThreads()
        {
            return intMaxThreads;
        }

        /// <summary>
        /// Set the maxmimum number of threads
        /// </summary>
        /// <param name="intMaxTs"></param>
        /// <returns></returns>
        public bool SetMaxThread(int intMaxTs)
        {
            intMaxThreads = intMaxTs;

            if (intMaxThreads == intMaxTs) return true;

            return false;
        }

    }
}
