using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace ManagedSpy {
    /// <summary>
    /// This dialog allows the user to filter events.
    /// Note that this could be improved to actually show _all_ events.
    /// To do this, you would have to look at TypeDescriptor.GetEvents of
    /// the ComponentType property of the ControlProxy.
    /// </summary>
    public partial class EventFilterDialog : Form {
        EventFilterList eventlist = new EventFilterList();

        internal EventFilterList EventList {
            get { return eventlist; }
            set { eventlist = value; }
        }

        public EventFilterDialog() {
            InitializeComponent();
            this.dataGridView1.DataSource = EventList;
            this.dataGridView1.Columns[0].Width = 47;
            this.dataGridView1.Columns[1].Width = 170;
        }

        private void buttonOK_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)Keys.Space) {
                ToggleSelectedCells();
            }
        }
        private void ToggleSelectedCells() {
            if (dataGridView1.SelectedCells.Count > 0) {
                bool newValue = !EventList[dataGridView1.SelectedCells[0].RowIndex].Display;
                foreach (DataGridViewCell cell in dataGridView1.SelectedCells) {
                    if (cell.ColumnIndex == 0) {
                        cell.Value = newValue;
                    }
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e) {
            ToggleSelectedCells();
        }
    }

    class EventFilterList : List<EventFilterLine> {
        public EventFilterList() {
            EventDescriptorCollection edColl = TypeDescriptor.GetEvents(typeof(Control));
            edColl = edColl.Sort();
            Add(new EventFilterLine("Custom Events", true));
            for (int i =0; i < edColl.Count;i++) {
                Add(new EventFilterLine(edColl[i].Name, true));
            }
        }

        public EventFilterLine this[string eventName] {
            get {
                foreach (EventFilterLine line in this) {
                    if (line.EventName == eventName) {
                        return line;
                    }
                }
                return this[0]; //custom
            }
        }
    }

    class EventFilterLine {
        string eventName;
        bool isChecked;

        public EventFilterLine(string eventName, bool isChecked)  {
            this.eventName = eventName;
            this.isChecked = isChecked;
        }

        public string EventName {
            get {
                return eventName;
            }
        }

        public bool Display {
            get {
                return isChecked;
            }
            set {
                isChecked = value;
            }
        }
    }
}