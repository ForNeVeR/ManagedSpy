using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Microsoft.ManagedSpy;

namespace ManagedSpy {
	/// <summary>
	/// This is the main window of ManagedSpy.
	/// Its a fairly simple Form containing a TreeView and TabControl.
	/// The TreeView contains processes and thier windows
	/// The TabControl contains properties and events.
	/// </summary>
	public partial class MainForm : Form
	{
		/// <summary>
		/// Currently selected proxy -- used for event logging.
		/// </summary>
		private ControlProxy currentProxy = null;
		EventFilterDialog dialog = new EventFilterDialog();

        public MainForm() {
			InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
			Application.Exit();
		}

		private void MainForm_Load(object sender, EventArgs e) {
			RefreshWindows();
		}

		private void refreshToolStripMenuItem_Click(object sender, EventArgs e) {
			RefreshWindows();
		}

		/// <summary>
		/// This rebuilds the window hierarchy
		/// </summary>
		private void RefreshWindows() {
			this.treeWindow.BeginUpdate();
			this.treeWindow.Nodes.Clear();
			ControlProxy[] topWindows = Microsoft.ManagedSpy.ControlProxy.TopLevelWindows;
			if (topWindows != null && topWindows.Length > 0) {
				foreach (ControlProxy cproxy in topWindows) {
					TreeNode procnode;

					//only showing managed windows
					if (this.ShowNative.Checked || cproxy.IsManaged) {
						Process proc = cproxy.OwningProcess;
						if (proc != null && proc.Id != Process.GetCurrentProcess().Id) {
							procnode = treeWindow.Nodes[proc.Id.ToString()];
							if (procnode == null) {
								procnode = treeWindow.Nodes.Add(proc.Id.ToString(),
									proc.ProcessName +
									"  " + proc.MainWindowTitle +
									" [" + proc.Id.ToString() + "]");
								procnode.Tag = proc;
							}
							string name = String.IsNullOrEmpty(cproxy.GetComponentName()) ?
								"<noname>" : cproxy.GetComponentName();
							TreeNode node = procnode.Nodes.Add(cproxy.Handle.ToString(),
								name +
								"     [" +
								cproxy.GetClassName() +
								"]");
							node.Tag = cproxy;
						}
					}
				}
			}
			if (treeWindow.Nodes.Count == 0) {
				treeWindow.Nodes.Add("No managed processes running.");
				treeWindow.Nodes.Add("Select View->Refresh.");
			}
			this.treeWindow.EndUpdate();
		}

		/// <summary>
		/// Called when the user selects a control in the treeview
		/// </summary>
		private void treeWindow_AfterSelect(object sender, TreeViewEventArgs e) {
			this.propertyGrid.SelectedObject = this.treeWindow.SelectedNode.Tag;
			this.toolStripStatusLabel1.Text = treeWindow.SelectedNode.Text;
			StopLogging();
			this.eventGrid.Rows.Clear();
			StartLogging();
		}

		/// <summary>
		/// This is called when the selected ControlProxy raises an event
		/// </summary>
		private void ProxyEventFired(object sender, ProxyEventArgs args) {
			eventGrid.FirstDisplayedScrollingRowIndex = this.eventGrid.Rows.Add(new object[] { args.eventDescriptor.Name, args.eventArgs.ToString() });
		}

		/// <summary>
		/// Used to build the treeview as the user expands nodes.
		/// We always stay one step ahead of the user to get the expand state set correctly.
		/// So, for instance, when we just show processes, we have already calculated all the top level windows.
		/// When the user expands a process -- we calculate the children of all top level windows
		/// And so on...
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void treeWindow_BeforeExpand(object sender, TreeViewCancelEventArgs e) {
			foreach (TreeNode child in e.Node.Nodes) {
				child.Nodes.Clear();
				ControlProxy proxy = child.Tag as ControlProxy;
				if (proxy != null) {
					foreach (ControlProxy proxychild in proxy.Children) {
						string name = String.IsNullOrEmpty(proxychild.GetComponentName()) ?
							"<noname>" : proxychild.GetComponentName();
						TreeNode node = child.Nodes.Add(proxychild.Handle.ToString(), name + "     [" +
							proxychild.GetClassName() + "]");
						node.Tag = proxychild;
					}
				}
			}
		}

		private void flashWindow_Click(object sender, EventArgs e) {
			FlashCurrentWindow();
		}
		private void showWindowToolStripMenuItem_Click(object sender, EventArgs e) {
			FlashCurrentWindow();
		}

		/// <summary>
		/// This uses ControlPaint.DrawReversibleFrame to highlight the given window
		/// </summary>
		private void FlashCurrentWindow()
		{
			var proxy = treeWindow.SelectedNode.Tag as ControlProxy;
			if (proxy != null && proxy.IsManaged && proxy.GetValue("Location") != null)
			{
				IntPtr handle = proxy.Handle;
				Point topleft = (Point)proxy.GetValue("Location");
				if (proxy.Parent != null)
				{
					topleft = (Point)proxy.Parent.PointToScreen(topleft);
				}
				Size size = (Size)proxy.GetValue("Size");
				Rectangle r = new Rectangle(topleft, size);

				for (int i = 1; i <= 7; i++)
				{
					ControlPaint.DrawReversibleFrame(r, Color.Red, FrameStyle.Thick);
					Thread.Sleep(100);
				}
				Thread.Sleep(250); //extra delay at the end.
				ControlPaint.DrawReversibleFrame(r, Color.Red, FrameStyle.Thick);
			}
		}

		/// <summary>
		/// Starts event logging
		/// </summary>
		private void StartLogging() {
			if (tsButtonStartStop.Checked) {
				currentProxy = propertyGrid.SelectedObject as ControlProxy;
				if (currentProxy != null) {
					//unsubscribe from events.
					foreach (EventDescriptor ed in currentProxy.GetEvents()) {
						if (dialog.EventList[ed.Name].Display) {
							currentProxy.SubscribeEvent(ed);
						}
					}
					currentProxy.EventFired += new ControlProxyEventHandler(ProxyEventFired);
				}
			}
		}

		/// <summary>
		/// Stops event Logging
		/// </summary>
		private void StopLogging() {
			if (currentProxy != null) {
				//unsubscribe from events.
				foreach (EventDescriptor ed in currentProxy.GetEvents()) {
					currentProxy.UnsubscribeEvent(ed);
				}
				currentProxy.EventFired -= new ControlProxyEventHandler(ProxyEventFired);
			}
		}

		private void tsButtonStartStop_Click(object sender, EventArgs e) {
			StopLogging();
			StartLogging();
			if (tsButtonStartStop.Checked) {
				tsButtonStartStop.Image = ManagedSpy.Properties.Resources.Stop;
			}
			else {
				tsButtonStartStop.Image = ManagedSpy.Properties.Resources.Play;
			}
		}

		private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
			StopLogging();
		}

		private void tsbuttonRefresh_Click(object sender, EventArgs e) {
			RefreshWindows();
		}

		private void tsButtonClear_Click(object sender, EventArgs e) {
			this.eventGrid.Rows.Clear();
		}

		private void tsbuttonFilterEvents_Click(object sender, EventArgs e) {
			dialog.ShowDialog();
			StopLogging();
			StartLogging();
		}

		private void filterEventsToolStripMenuItem_Click(object sender, EventArgs e) {
			dialog.ShowDialog();
			StopLogging();
			StartLogging();
		}

		private void aboutManagedSpyToolStripMenuItem_Click(object sender, EventArgs e) {
			HelpAbout about = new HelpAbout();
			about.ShowDialog();
		}

		private void treeWindow_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				treeWindow.SelectedNode = e.Node;
				treeMenuStrip.Show(treeWindow, e.Location);
			}
		}
	}

	/// <summary>
	/// This is to ensure when you click on the toolstrip, our application doesn't have to be
	/// active for the click to register.
	/// </summary>
	class ClickToolStrip : ToolStrip {
		const int WM_MOUSEACTIVATE = 0x0021;
		const int MA_ACTIVATE = 0x0001;

		protected override void WndProc(ref Message m) {
			if (m.Msg == WM_MOUSEACTIVATE) {
				m.Result = (IntPtr)MA_ACTIVATE;
			}
			else {
				base.WndProc(ref m);
			}
		}
	}
}
