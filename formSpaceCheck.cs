using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Collections;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Runtime.InteropServices;

namespace SpaceCheck
{
    
    
    public partial class formSpaceCheck : Form
    {
      int cutOff;
      Boolean userStop;
      Thread recurThread;
      Thread recurThreadFn;
      bool fileSearch = false;

      String startPhrase = String.Empty;
      String endPhrase = String.Empty;
      int maxDiff = 0;

      //private bool cancelled = false;

      delegate void StringParameterDelegate (string value, long dirSize);
      delegate void StringParameterDelegate2 (string filePath, string fileName);

      public delegate void AddToTV(String aDir);
      public AddToTV myDelegate;

      public formSpaceCheck()
      {
          InitializeComponent();
      }

        

        
      private void btnRefresh_Click(object sender, EventArgs e)
      {
          userStop = false;

          fileSearch = false;

          int cnt = lv.Items.Count;
          for (int i = 0; i < cnt; i++)
          {
              lv.Items[0].Remove();
              Thread.Sleep(5);
          }

          Application.DoEvents();
          (sender as Button).Enabled = false;
          try
          {
              cutOff = Convert.ToInt32(tbCutoff.Text);
              //Thread recurThread = new Thread(new ThreadStart(recur));
              //TRecur Recur = new TRecur();
              recurThread = new Thread(new ParameterizedThreadStart(recur));
              ThreadParamClass tpc = new ThreadParamClass();
              tpc.cutoff = Convert.ToInt32(tbCutoff.Text);
              tpc.dir = tbRootDir.Text;
              recurThread.Start(tpc);

              int i = 0;
              while ((recurThread.IsAlive) && (!userStop) )
              {
                  label1.Text = i.ToString(); ;
                  i++;
                  //tv.Refresh();
                  Application.DoEvents();
                  Thread.Sleep(200);
              }
              
              //lv.Sort();
               
          }
          finally
          {
              (sender as Button).Enabled = true;
              label1.Text = "Done";
          }
          /*
          while (recurThread.IsAlive)
          {
              //Here refresh screen with ThreadInfo data.
              //Add anything in ThreadInfo stringlist.
              TreeNode tn = new TreeNode();
              tn.Name = Convert.ToString(newDirSize);
              tn.Text = tn.Name + " : " + di.FullName;
              tv.Nodes.Insert(idx, tn);
              tv.Refresh();
          }
          */

          //Sort treeview.
          /*
          idx = 0;
          if (tv.Nodes.Count > 0)
          {
              while ((idx < tv.Nodes.Count) &&
                      (newDirSize < thisDirSize(tv.Nodes[idx].Name)))
              {
                  idx++;
              }
          }
          */
        
          /*
          Cursor.Current = Cursors.WaitCursor;
          tv.Nodes.Clear();
          btnRefresh.Enabled = false;
          try
          {
              recur(tbRootDir.Text);
          }
          finally
          {
              btnRefresh.Enabled = true;
              Cursor.Current = Cursors.Default;
              tv.ExpandAll();
              
          }
           */
      }

      private void btnFindFile_Click(object sender, EventArgs e)
      {
          fileSearch = true;
          
          userStop = false;

          label1.Text = String.Empty;

          int cnt = lv.Items.Count;
          for (int i = 0; i < cnt; i++)
          {
              lv.Items[0].Remove();
          }
          lv.Items.Clear();
          Application.DoEvents();
          
          (sender as Button).Enabled = false;
          try
          {

              recurThreadFn = new Thread(new ParameterizedThreadStart(recurFn));
              ThreadParamClass tpc = new ThreadParamClass();

              tpc.dir = tbRootDir.Text;
              tpc.fnToFind = tbFNToFind.Text;


              recurThreadFn.Start(tpc);

              while ((recurThreadFn.IsAlive) && (!userStop))
              {
                  //label1.Text = i.ToString();
                  //i++;
                  
                  Text = tpc.dir;
                  //tv.Refresh();
                  Application.DoEvents();
                  Thread.Sleep(200);
              }



          }
          finally
          {
              (sender as Button).Enabled = true;
              label1.Text = "File Search Done " + lv.Items.Count;
          }

      }

        
        
      private void tbRootDir_DoubleClick(object sender, EventArgs e)
      {
          folderBrowserDialog.RootFolder = Environment.SpecialFolder.MyComputer;
          folderBrowserDialog.ShowDialog();
          tbRootDir.Text = folderBrowserDialog.SelectedPath;
      }

      private long thisDirSize(string dirSize)
      {
          return (Convert.ToInt64(dirSize));
          
      }

    /*
        private void tv_DoubleClick(object sender, EventArgs e)
        {
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "explorer.exe";
            string dir = lv.SelectedItems[0].Text;
            int pos = dir.IndexOf(tbRootDir.Text);
            dir = dir.Substring(pos);
            psi.Arguments = dir; //@"c:\";
            Process.Start(psi);
        }
    */

      private Int64 mb = 1024000;

      private long DirSize(DirectoryInfo aDi)
      {
          long sum = 0;
          try
          {
              FileInfo[] files = aDi.GetFiles();
              foreach (FileInfo fi in files)
              {
                  sum = sum + fi.Length;
              }
          }
          catch
          {

          }

          return (sum);
      }

			public int FolderDepth(string path)
			{
				string[] slash = new string[]{"\\"};

				return path.Split(slash, StringSplitOptions.None).Length;

			}

      public void recur(Object aDirObject)
      {
          
          ThreadParamClass tpc;
          tpc = (aDirObject as ThreadParamClass);
          string dirStr = tpc.dir;
          
          //Skip directories unauthorized to view.
          //if (dirStr.Contains("Documents and Settings"))
          //    return;

          //if (dirStr.Contains("System Volume Information"))
          //    return;

          //if (dirStr.Contains("ProgramData"))
          //    return;

          try
          {
              DirectoryInfo di = new DirectoryInfo(dirStr);
              long newDirSize = DirSize(di);
              if ((newDirSize) > (tpc.cutoff * mb))
              {
                  UpdateTV(dirStr, newDirSize/mb);
              }
              
              //DirectoryInfo di = new DirectoryInfo(tbRootDir.Text);
          
          
              string[] dirs = Directory.GetDirectories(dirStr);
              foreach (string dir in dirs)
              {
                  tpc.dir = dir;
                  if (!userStop)
                  {
										recur(tpc);
                  }
              }
          }
          catch (Exception E)
          {
              //UpdateTV("Cant access " + dirStr +" "+ E.Message, 0);

          }
          
      }

      public void recurFn(Object aDirObject)
      {

          ThreadParamClass tpc;
          tpc = (aDirObject as ThreadParamClass);
          string dirStr = tpc.dir;
          string fnToFind = tpc.fnToFind;
					int howDeep = (int)numericUpDownFolderDepth.Value;


          try
          {
              //Search inside root directory first
              DirectoryInfo di = new DirectoryInfo(dirStr);
              FileInfo[] fiList = di.GetFiles(fnToFind, SearchOption.TopDirectoryOnly);

            
              foreach (FileInfo fi in fiList)
              {
                  UpdateTV(fi.DirectoryName, fi.Name);
                  //RenameTaxID(fi);

              }
            
            /*
              foreach (FileInfo fi in fiList)
              {
                  FileSecurity fileSecurity = fi.GetAccessControl();
                  IdentityReference identityReference = fileSecurity.GetOwner(typeof(NTAccount));
                  if (identityReference.Value.Contains("abutler"))
                  {
                  UpdateTV(fi.DirectoryName, fi.Name);
                  UpdateTV(fi.Name, identityReference.Value);
                  }
              }
              */




              //Now search all subdirectories
              DirectoryInfo[] diList = di.GetDirectories();
              foreach (DirectoryInfo dir in diList)
              {
                  try
                  {
                   
                      tpc.dir = dir.FullName;
                      if (!userStop)
                      {
													if (FolderDepth(dir.FullName) < howDeep)
														recurFn(tpc);
                      }
                  }
                  catch (Exception E)
                  {
                      UpdateTV(E.Message, 0);
                  }
              }
          }
          catch (Exception E)
          {
              if (!E.Message.Contains("is denied"))
              {
              UpdateTV(E.Message, 0);
              }

          }

      }


      void UpdateTV(string aDir, long aNewDirSize)
      {
          if (InvokeRequired)
          {
            // We're not in the UI thread, so we need to call BeginInvoke
            lv.Invoke(new StringParameterDelegate(UpdateTV), new object[] { aDir, aNewDirSize });
            //BeginInvoke(new StringParameterDelegate(UpdateTV), new object[] { aDir, aNewDirSize });
            return;
          }
          // Must be on the UI thread if we've got this far
          ListViewItem li = new ListViewItem();
          li.Text = aDir;
          ListViewItem.ListViewSubItem liSub = new ListViewItem.ListViewSubItem(li,  Convert.ToString(aNewDirSize));
          li.SubItems.Add(liSub);
          lv.Items.Add(li);
          


      }

      void UpdateTV(string aDir, string aFN)
      {
          if (InvokeRequired)
          {
              // We're not in the UI thread, so we need to call BeginInvoke
              lv.Invoke(new StringParameterDelegate2(UpdateTV), new object[] { aDir, aFN });
              //BeginInvoke(new StringParameterDelegate(UpdateTV), new object[] { aDir, aNewDirSize });
              return;
          }
          // Must be on the UI thread if we've got this far
          ListViewItem li = new ListViewItem();
          li.Text = aDir;
          ListViewItem.ListViewSubItem liSub = new ListViewItem.ListViewSubItem(li, aFN);
          li.SubItems.Add(liSub);
          lv.Items.Add(li);



      }

      private void RenameTaxID(FileInfo fi)
      {
          string oldTaxID = "221775306";
          string oldTaxIDWithP = "221775306P";
          string newTaxID = "221775555";

          string nameNoExt = Path.GetFileNameWithoutExtension(fi.Name);
          if ((nameNoExt == oldTaxID) || (nameNoExt == oldTaxIDWithP))
          {
              string dir = Path.GetDirectoryName(fi.FullName);
              string ext = Path.GetExtension(fi.FullName);
              string newName = Path.Combine(dir, newTaxID + ext);
              fi.MoveTo(newName);
          }

      }


      private void lv_SelectedIndexChanged(object sender, EventArgs e)
      {
          
      }

      private void lv_ColumnClick(object sender, ColumnClickEventArgs e)
      {
          // Set the ListViewItemSorter property to a new ListViewItemComparer 
          // object. Setting this property immediately sorts the 
          // ListView using the ListViewItemComparer object.
          if (e.Column == 0)
          {

              this.lv.ListViewItemSorter = new ListViewItemComparer(e.Column);
          }
          else
          {
              
			  if (this.lv.ListViewItemSorter is ListViewItemComparer)
			  {
				  this.lv.ListViewItemSorter = new ListViewItemComparerInt(e.Column);
			  }
			  else
			  {
				  this.lv.ListViewItemSorter = new ListViewItemComparer(e.Column);
			  }
          }

              
      }

      private void lv_DoubleClick(object sender, EventArgs e)
      {
          ProcessStartInfo psi = new ProcessStartInfo();
          psi.FileName = "explorer.exe";
          string dir = lv.SelectedItems[0].SubItems[0].Text;
          int pos = dir.IndexOf(tbRootDir.Text);
          dir = dir.Substring(pos);
          psi.Arguments = dir; //@"c:\";

          //Backspace an

          Process.Start(psi);

      }

      private void formSpaceCheck_FormClosing(object sender, FormClosingEventArgs e)
      {
          userStop = true;
      }

      private void btnStop_Click(object sender, EventArgs e)
      {
          
          userStop = true;

      }

			private void formSpaceCheck_Load(object sender, EventArgs e)
			{
				tbRootDir.Text = String.Empty;
				/*
          string[] driveList = Environment.GetLogicalDrives();
          foreach (string drive in driveList)
          {
              tbRootDir.Text = tbRootDir.Text + drive+";";
          }
        */

				/* First add local drive letters and then shares */
				DriveInfo[] drives = DriveInfo.GetDrives();
				foreach (DriveInfo di in drives)
				{
					listBox1.Items.Add(di.Name);
				}
				//listBox1.Items.Add("********END local drives**********");
				listBox1.Items.Add(@"R:\Salesforce Attachments");
				listBox1.Items.Add(@"R:\Team Support Attachments");

				Boolean uncAlreadyConnected = false;

				// Next, attempt to open an enumeration of connected network resources.
				// If unable, return with reason. Values from http://www.math.uiuc.edu/~gfrancis/illimath/windows/aszgard_mini/bin/MinGW/include/winnetwk.h

				toolTip1.SetToolTip(numericUpDownFolderDepth, "Folder Depth");


			}	//FormSpaceCheck_Load

			void RecurNWResources(WNetWrapper.NetResource netResource)
			{
				int returnValue;
				IntPtr ptrHandle = new IntPtr();
				Int64 enumHandle = 0;
				//object resource = null;

				returnValue = WNetWrapper.WNetOpenEnum(WNetWrapper.RESOURCE_SCOPE.RESOURCE_CONNECTED,
																							 WNetWrapper.RESOURCE_TYPE.RESOURCETYPE_ANY,
																							 WNetWrapper.RESOURCE_USAGE.RESOURCEUSAGE_ALL,
																							 ref netResource,
																							 out ptrHandle); //ref enumHandle); //out ptrHandle); 

				//listBox1.Items.Add("PTRhandle " + ptrHandle);
				enumHandle = ptrHandle.ToInt64();
				//listBox1.Items.Add("OpenEnum Handle " + enumHandle + " returnValue " + returnValue);


				if (returnValue == 0)
				{
					int entries = -1;
					Int32 bufferSize = 65535; // 32768; // 16384; 
					IntPtr ptrBuffer = Marshal.AllocHGlobal(bufferSize);
					//WNetWrapper.NetResource netResource;

					
					/*
					returnValue = WNetWrapper.WNetEnumResource(enumHandle, ref entries, ptrBuffer, ref bufferSize);
																		//WNetEnumResource(enumHandle, ref structCount, buffer, ref bufferSize)) == 0)
					while ((returnValue == 0) || (entries > 0))
					{
						Int32 ptr = ptrBuffer.ToInt32();
						for (int i = 0; i < entries; i++)
						{
							netResource = (WNetWrapper.NetResource)Marshal.PtrToStructure(new IntPtr(ptr), typeof(WNetWrapper.NetResource));  //try marshall like UNC
							//netResource = new WNetWrapper.NetResource();


							if (WNetWrapper.RESOURCE_USAGE.RESOURCEUSAGE_CONTAINER == (netResource.dwUsage & WNetWrapper.RESOURCE_USAGE.RESOURCEUSAGE_CONTAINER))
							{
									//call recursively to get all entries in a container

								//RecurNWResources(netResource);
							}

							ptr += Marshal.SizeOf(netResource);
							//result.Add(netResource.lpLocalName, netResource);

							listBox1.Items.Add(netResource.lpRemoteName); //netResource.lpLocalName + " " + netResource.lpRemoteName.Substring(0, netResource.lpRemoteName.Length));
							listBox1.Invalidate();
							Application.DoEvents();
							
						}
						entries = -1;
						bufferSize = 65535; // 16384;
						returnValue = WNetWrapper.WNetEnumResource(enumHandle, ref entries, ptrBuffer, ref bufferSize);
					}
					*/

					while ((returnValue = WNetWrapper.WNetEnumResource(enumHandle, ref entries, ptrBuffer, ref bufferSize)) == 0)
					{
						Int64 ptr = ptrBuffer.ToInt64();
						for (int i = 0; i < entries; i++)
						{
							netResource = (WNetWrapper.NetResource)Marshal.PtrToStructure(new IntPtr(ptr), typeof(WNetWrapper.NetResource));
							//Marshal.StringToBSTR(netResource.lpRemoteName)
							listBox1.Items.Add(netResource.lpRemoteName); //netResource.lpLocalName + " " + netResource.lpRemoteName.Substring(0, netResource.lpRemoteName.Length));
							//listBox1.Invalidate(); 		Application.DoEvents();
							ptr += Marshal.SizeOf(netResource);  //Is necessary to increase size of ptr, else shows first entry for entires number of times.
						}

					}

					if (returnValue != 0)
					{
						if (returnValue == 259)
						{
							//listBox1.Items.Add("No more entries");
						}
						else
						{
						listBox1.Items.Add("WnetEnumResource RC = "  + returnValue);
						}
					}

					Marshal.FreeHGlobal(ptrBuffer);
					returnValue = WNetWrapper.WNetCloseEnum(ptrHandle);


					////////////////////////////////////////////////////////////////////////////////////////////////////

					// Call the GlobalAlloc function to allocate resources
					//buffer = Marshal.AllocHGlobal(bufferSize);


					//WNetWrapper.NetResource netres = new WNetWrapper.NetResource();
					//int cResourceTypeDisk = 1;
					//netRes.dwType = cResourceTypeDisk; // Disk Resource
					//netRes.lpLocalName = "J:";


					//string unc = @"\\fs1.gaffeycolo.com\ConfirmationReportsConcatLate\EmdeonReports\RcptAck";
					//unc = @"\\fs1.gaffeycolo.com\ConfirmationReports\";
					//netRes.RemoteName = unc;

					string userName = @"gemsedi\abutler"; //@"gaffeycolo.com\autoprod";
					string password = "lllKKK123";

					

					//returnValue = WNetWrapper.WNetAddConnection2A(ref prSrc, null, null, 0);
					
					//returnValue = WNetWrapper.WNetAddConnection2(ref netResource, password, userName, 0);  //Last param = Connect Interactive
					/*
					if (returnValue != 0)
					{

						throw new Exception("WNetAddConnection2 failed with return value " + returnValue);
					}
					 */ 

					/*
					returnValue = WNetWrapper.WNetAddConnection2A(ref netRes, password, userName, 0);
					if ((returnValue != 0))
					{

						throw new Exception("WNetAddConnection2A failed with return value " + returnValue);
					}
					*/

					/*
							while ((returnValue = WNetWrapper.WNetEnumResource(handle, ref cEntries, buffer, ref bufferSize)) == 0)
							{

								Marshal.PtrToStructure(buffer, netRes);
								listBox1.Items.Add(netRes.RemoteName);

								//netResource = (WNetWrapper.NetResource)Marshal.PtrToStructure(buffer, typeof(WNetWrapper.NetResource));
								//listBox1.Items.Add(netResource.lpRemoteName);
				
								}
								catch (Exception E)
								{
									throw new Exception(E.Message + " " + netResource.lpRemoteName);
								}
				
							}
				*/

					//		Marshal.FreeHGlobal((IntPtr)buffer);

					/*
							finally
							{
								// Next, attempt to close the enumeration.
								// If unable, return with reason.
								returnValue = WNetWrapper.WNetCloseEnum(handle);
								if (returnValue != 0)
									throw new Exception("WNetCloseEnum failed with error " + returnValue);
							}
						}
					 */
				}
				else
				{

					listBox1.Items.Add("WNetOpenEnum failed with error " + returnValue);

				}
				

			}  //RecurNWResources

			void AddNetworkConnection()   //   (WNetWrapper.NetResource netResource)
			{
				int returnValue;
				//netResource.dwScope = WNetWrapper.RESOURCE_SCOPE.RESOURCE_GLOBALNET;
				//netResource.dwType = WNetWrapper.RESOURCE_TYPE.RESOURCETYPE_ANY;
				//netResource.dwDisplayType = WNetWrapper.RESOURCE_DISPLAYTYPE.RESOURCEDISPLAYTYPE_GENERIC;
				//netResource.dwUsage = WNetWrapper.RESOURCE_USAGE.RESOURCEUSAGE_CONNECTABLE;
				//netResource.lpLocalName = null; // "Z:";

				//unc = "\\\\netfiles\\Dept\\Technology\\Time Tracking Workshet";
				//netResource.lpProvider = null;
				//netResource.lpRemoteName = @"\\dataminer\GRE\log";


				//string userName = @"gaffeycolo.com\abutler";
				//string password = "Yodaswif2";
				//string userName = "autoprod@";
				//string password = "autoprod";
				//string userName = @"abutler@gemsedi.com";
				string userName = @"gemsedi\abutler";
				string password = "lllKKK123";
				/* Marshalling
				Int32 bufferSize = 32768; // 16384; 
				IntPtr ptrBuffer = Marshal.AllocHGlobal(bufferSize);
				Int32 ptr = ptrBuffer.ToInt32();
				 */ 

				//if marshal here not knowing ptr size from return call it sets Provider to nonsense value.
				
				//Int32 ptr	= 462113776;
				//Int32 ptr;
				//ptr = Marshal.SizeOf(netResource);
				//ptr += Marshal.SizeOf(netResource);
				//Int32 ptr += Marshal.SizeOf(NetResource);
				//Int32 bufferSize = 32768; // 16384; 
				//IntPtr ptrBuffer = Marshal.AllocHGlobal(bufferSize);
				//Int32 ptr = ptrBuffer.ToInt32();
				
				//netResource = (WNetWrapper.NetResource)Marshal.PtrToStructure(new IntPtr(ptr), typeof(WNetWrapper.NetResource));  //try marshall like UNC
				WNetWrapper.NetResource netResource = new WNetWrapper.NetResource();
				
				netResource.dwType = WNetWrapper.RESOURCE_TYPE.RESOURCETYPE_ANY;
				//string unc = @"fs1.gaffeycolo.com/support";  //\EmdeonReports\RcptAck";
				//String unc = @"\\fs1.gaffeycolo.com\support";
				String unc = @"\\10.129.3.55\support";
				netResource.lpRemoteName = unc; // +"\0";				
				//StringBuilder unc = new StringBuilder(32); 	//unc.AppendLine(@"\\10.129.3.55\support");
				netResource.lpProvider = null;

				//netResource = (WNetWrapper.NetResource)Marshal.PtrToStructure(new IntPtr(ptr), typeof(WNetWrapper.NetResource));  //try marshall like UNC

				//netResource.lpRemoteName = Marshal.StringToBSTR(netResource.lpProvider);
				//returnValue = WNetAddConnection2(ref netResource, null, null, 0);
				//if ((returnValue != 0) && (userName.Length > 0))
				returnValue = WNetWrapper.WNetAddConnection2(ref netResource, null, null, 0);
				

				if (returnValue != 0)
				{
					returnValue = WNetWrapper.WNetAddConnection2(ref netResource, password, userName, 0);
					listBox1.Items.Add("WNetAddConn2-2: "  + returnValue);
				}

			}

		

			private void tbFNToFind_Leave(object sender, EventArgs e)
			{
			}

			private void tbFNToFind_Validated(object sender, EventArgs e)
			{
          
			}

			private void tbFNToFind_KeyPress(object sender, KeyPressEventArgs e)
			{

			}


			private void btnSF_Click(object sender, EventArgs e)
			{
					tbRootDir.Text = @"R:\salesforce attachments\";
			}

			private void btnE_Click(object sender, EventArgs e)
			{
					tbRootDir.Text = @"E:\";

			}

			private void tbFNToFind_KeyUp(object sender, KeyEventArgs e)
			{
						/*
								ListViewItem li = new ListViewItem();
								li.Text = e.KeyCode + " " + e.KeyData + " " + e.KeyValue;
								//ListViewItem.ListViewSubItem liSub = new ListViewItem.ListViewSubItem(li, Convert.ToString(aNewDirSize));
								//li.SubItems.Add(liSub);
								lv.Items.Add(li);
						*/
					if (e.KeyValue == (char)Keys.Return)
          {

              btnFindFile.PerformClick();

          }
      }

      private void tbCutoff_KeyUp(object sender, KeyEventArgs e)
      {
          if (e.KeyValue == (char)Keys.Return)
          {
              btnRefresh.PerformClick();

          }

      }

      

      private void lv_Click(object sender, EventArgs e)
      {
       
      }

      private void lv_MouseClick(object sender, MouseEventArgs e)
      {
       
      }

      private void lv_MouseDown(object sender, MouseEventArgs e)
      {
        if (e.Button == MouseButtons.Right)
        {
          StreamWriter sw = new StreamWriter("SpaceCheck.txt");

          for (int i = 0; i < (sender as ListView).Items.Count; i++)
          {
            ListViewItem item = (sender as ListView).Items[i];
            sw.WriteLine(item.SubItems[1].Text);
            
          }

                 
          sw.Flush();
          sw.Close();
        }

        //Blink
        /*
        Opacity = 0.5;
        
        Refresh();
        Update();
        //Thread.Sleep(10);
        
        Opacity = 1.0;
        
        Refresh();
        Update();
         */ 
      }


      private class ListViewItemCheckboxComparer : IComparer<ListViewItem>, System.Collections.IComparer
      {
        public int Compare(ListViewItem x, ListViewItem y)
        {
          // return the negative of the compare to put 1 (true) at the top;   
          return -(x.Checked ? 1 : 0).CompareTo(y.Checked ? 1 : 0);
        }

        public int Compare(object x, object y)
        {
          return Compare(x as ListViewItem, y as ListViewItem);
        }
      }   
  




      private void brnRE_Click(object sender, EventArgs e)
      {
        //Application.Run(new formRegEx());
        formRegEx fRegEx = new formRegEx(startPhrase, endPhrase, maxDiff);

        fRegEx.ShowDialog();

        startPhrase = fRegEx.startPhrase;
        endPhrase = fRegEx.endPhrase;
        maxDiff = fRegEx.maxDiff;

        lv.CheckBoxes = true;

        label1.Text = String.Empty;

        StreamReader file;

        ListView lvRe = new ListView();
        int spLoc;
        int epLoc;
        string fn = String.Empty;
        string fileStr = String.Empty;
        ListViewItem lviClone = null;

        int cnt = lv.Items.Count;
        for (int i = 0; i < cnt; i++)
        {

          fn = lv.Items[i].Text + @"\" + lv.Items[i].SubItems[1].Text;
          this.Text = fn;
          Application.DoEvents();

          file = new StreamReader(fn);
          fileStr = file.ReadToEnd();
          //file.Read(Buffer, 0, file.ReadToEnd)

          spLoc = fileStr.IndexOf(startPhrase, StringComparison.CurrentCultureIgnoreCase);
          if (spLoc >= 0)
          {
            epLoc = fileStr.IndexOf(endPhrase, spLoc, StringComparison.CurrentCultureIgnoreCase);
            if (epLoc > spLoc)
            {
              if ((epLoc-spLoc) < maxDiff)
              {
                lviClone = (ListViewItem)lv.Items[i].Clone();
                lvRe.Items.Add(lviClone);
              }
            }
          }
        }


				this.Text = "RegEx found " + lvRe.Items.Count + " instances of " + startPhrase + endPhrase;

        string fnReal;
        string fnClone;

        //List<int> removeList = new List<int>();
        for (int i = 0; i < lv.Items.Count; i++)
        {
          int j = 0;
          bool found = false;
          while ((j < lvRe.Items.Count) && (!found))
          {
            fnReal = lv.Items[i].Text + @"\" + lv.Items[i].SubItems[1].Text;
            fnClone = lvRe.Items[j].Text + @"\" + lvRe.Items[j].SubItems[1].Text;
            found = (fnReal == fnClone);
            j++;
          }

          if (found)
          {
            lv.Focus();
            lv.Items[i].Selected = true;
            lv.Items[i].Checked = true;
          }
          /*
          if (!found)  //Remove from original list
          {
            removeList.Add(i);

          }
           */ 
        }

        /*
        int removeOffset = 0;
        cnt = removeList.Count;
        for (int i = 0; i < cnt; i++)
        {
          lv.Items[removeList[i]-removeOffset].Remove();
          removeOffset++;
        }
        */
        lv.ListViewItemSorter = new ListViewItemCheckboxComparer();
        lv.Sort();  //Sort check marks up top

        lv.Refresh();
        Application.DoEvents();
        
        
        label1.Text = "RegEx done";

      }

			private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
			{

			}



			private void listBox1_Click(object sender, EventArgs e)
			{
				tbRootDir.Text = (sender as ListBox).SelectedItem.ToString();
			}

			private void formSpaceCheck_Shown(object sender, EventArgs e)
			{
				
				//object nwResourceObject = null;
				//RecurNWResources(nwResourceObject);
				WNetWrapper.NetResource netResource;
				netResource = new WNetWrapper.NetResource();
				RecurNWResources(netResource);
				AddNetworkConnection();  // (netResource);
				RecurNWResources(netResource);

			}


    }

    public class ThreadParamClass
    {
        public string dir;
        public int cutoff;
        public string fnToFind;
    }

    // Implements the manual sorting of items by columns.
    class ListViewItemComparer : IComparer
    {
        private int col;
        public ListViewItemComparer()
        {
            col = 0;
        }
        public ListViewItemComparer(int column)
        {
            col = column;
        }
        public int Compare(object x, object y)
        {
            return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
        }
    }

    // Implements the manual sorting of items by columns with int values.
    class ListViewItemComparerInt : IComparer
    {
        private int col;
        public ListViewItemComparerInt()
        {
            col = 0;
        }
        public ListViewItemComparerInt(int column)
        {
            col = column;
        }
        public int Compare(object x, object y)
        {
            Int64 cx = Convert.ToInt64(((ListViewItem)x).SubItems[col].Text);
            Int64 cy = Convert.ToInt64(((ListViewItem)y).SubItems[col].Text);
            if (cx > cy)
                return 0;
            else
                return 1;
            //return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
        }
    }

    
    
}